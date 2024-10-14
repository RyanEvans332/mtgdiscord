using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgdiscord.Cards
{
    public static class CardFactory
    {
        public async static Task<ICard> getCardByName(string name)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("User-Agent", "mtgdiscordapp/1.0");
            var request = await client.GetAsync($"https://api.scryfall.com/cards/named?fuzzy={name}");
            var response = await request.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<dynamic>(response);

            if (request.IsSuccessStatusCode)
            {
                var cardName = deserialized.name;
                bool isSingleFacedCard = true;
                ConsoleEx.WriteLine($"Found {cardName}");
                
                //Determine if card is single or multifaced
                try
                {
                    //this property only exists in single faced cards.
                    //exception is thrown when nonexistent property is accessed.
                    _ = deserialized.image_uris.normal;
                }
                catch (Exception ex)
                {
                    //multifaced
                    ConsoleEx.WriteLine(ex.Message);
                    isSingleFacedCard = false;
                }

                if (isSingleFacedCard)
                {
                    return JsonConvert.DeserializeObject<SingleFacedCards.SingleFacedCard>(response);
                }
                else
                {
                    //multifaced card
                    return JsonConvert.DeserializeObject<MultiFacedCards.MultiFacedCard>(response);
                }
            }
            else
            {
                throw new UserFriendlyError((string)deserialized.details);
            }
        }
    }
}
