using mtgdiscord.Rules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgdiscord.SingleFacedCards
{
    public class SingleFacedCard : mtgdiscord.Cards.ICard
    {
        public SingleFacedCard() {}
        public override List<string> getCardImageURIs()
        {
            return new List<string>() { this.image_uris.normal };
        }

        public override string getCardName()
        {
            return this.name;
        }

        public override RuleSet getCardRules()
        {
            return RuleService.Instance.getRules(keywords);
        }

        public override string getCardPrice()
        {
            if (string.IsNullOrEmpty(prices.usd))
            {
                return "N/A";
            }
            return $"${prices.usd}";
        }

        #region serialized data
        [JsonProperty("object")]
        public string @object { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("oracle_id")]
        public string oracle_id { get; set; }

        [JsonProperty("multiverse_ids")]
        public List<int> multiverse_ids { get; set; }

        [JsonProperty("mtgo_id")]
        public int mtgo_id { get; set; }

        [JsonProperty("tcgplayer_id")]
        public int tcgplayer_id { get; set; }

        [JsonProperty("cardmarket_id")]
        public int cardmarket_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("lang")]
        public string lang { get; set; }

        [JsonProperty("released_at")]
        public string released_at { get; set; }

        [JsonProperty("uri")]
        public string uri { get; set; }

        [JsonProperty("scryfall_uri")]
        public string scryfall_uri { get; set; }

        [JsonProperty("layout")]
        public string layout { get; set; }

        [JsonProperty("highres_image")]
        public bool highres_image { get; set; }

        [JsonProperty("image_status")]
        public string image_status { get; set; }

        [JsonProperty("image_uris")]
        public ImageUris image_uris { get; set; }

        [JsonProperty("mana_cost")]
        public string mana_cost { get; set; }

        [JsonProperty("cmc")]
        public double cmc { get; set; }

        [JsonProperty("type_line")]
        public string type_line { get; set; }

        [JsonProperty("oracle_text")]
        public string oracle_text { get; set; }

        [JsonProperty("power")]
        public string power { get; set; }

        [JsonProperty("toughness")]
        public string toughness { get; set; }

        [JsonProperty("colors")]
        public List<string> colors { get; set; }

        [JsonProperty("color_identity")]
        public List<string> color_identity { get; set; }

        [JsonProperty("keywords")]
        public List<string> keywords { get; set; }

        [JsonProperty("all_parts")]
        public List<AllPart> all_parts { get; set; }

        [JsonProperty("legalities")]
        public Legalities legalities { get; set; }

        [JsonProperty("games")]
        public List<string> games { get; set; }

        [JsonProperty("reserved")]
        public bool reserved { get; set; }

        [JsonProperty("foil")]
        public bool foil { get; set; }

        [JsonProperty("nonfoil")]
        public bool nonfoil { get; set; }

        [JsonProperty("finishes")]
        public List<string> finishes { get; set; }

        [JsonProperty("oversized")]
        public bool oversized { get; set; }

        [JsonProperty("promo")]
        public bool promo { get; set; }

        [JsonProperty("reprint")]
        public bool reprint { get; set; }

        [JsonProperty("variation")]
        public bool variation { get; set; }

        [JsonProperty("set_id")]
        public string setid { get; set; }

        [JsonProperty("set")]
        public string set { get; set; }

        [JsonProperty("set_name")]
        public string setname { get; set; }

        [JsonProperty("set_type")]
        public string settype { get; set; }

        [JsonProperty("set_uri")]
        public string seturi { get; set; }

        [JsonProperty("set_search_uri")]
        public string set_search_uri { get; set; }

        [JsonProperty("scryfall_set_uri")]
        public string scryfall_set_uri { get; set; }

        [JsonProperty("rulings_uri")]
        public string rulings_uri { get; set; }

        [JsonProperty("prints_search_uri")]
        public string prints_search_uri { get; set; }

        [JsonProperty("collector_number")]
        public string collector_number { get; set; }

        [JsonProperty("digital")]
        public bool digital { get; set; }

        [JsonProperty("rarity")]
        public string rarity { get; set; }

        [JsonProperty("card_back_id")]
        public string card_back_id { get; set; }

        [JsonProperty("artist")]
        public string artist { get; set; }

        [JsonProperty("artist_ids")]
        public List<string> artist_ids { get; set; }

        [JsonProperty("illustration_id")]
        public string illustration_id { get; set; }

        [JsonProperty("border_color")]
        public string border_color { get; set; }

        [JsonProperty("frame")]
        public string frame { get; set; }

        [JsonProperty("frame_effects")]
        public List<string> frame_effects { get; set; }

        [JsonProperty("security_stamp")]
        public string security_stamp { get; set; }

        [JsonProperty("full_art")]
        public bool full_art { get; set; }

        [JsonProperty("textless")]
        public bool textless { get; set; }

        [JsonProperty("booster")]
        public bool booster { get; set; }

        [JsonProperty("story_spotlight")]
        public bool story_spotlight { get; set; }

        [JsonProperty("edhrec_rank")]
        public int edhrec_rank { get; set; }

        [JsonProperty("preview")]
        public Preview preview { get; set; }

        [JsonProperty("prices")]
        public Prices prices { get; set; }

        [JsonProperty("related_uris")]
        public RelatedUris related_uris { get; set; }

        [JsonProperty("purchase_uris")]
        public PurchaseUris purchase_uris { get; set; }
        #endregion
    }

    #region serialized data
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AllPart
    {
        [JsonProperty("object")]
        public string @object { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("component")]
        public string component { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("type_line")]
        public string type_line { get; set; }

        [JsonProperty("uri")]
        public string uri { get; set; }
    }

    public class ImageUris
    {
        [JsonProperty("small")]
        public string small { get; set; }

        [JsonProperty("normal")]
        public string normal { get; set; }

        [JsonProperty("large")]
        public string large { get; set; }

        [JsonProperty("png")]
        public string png { get; set; }

        [JsonProperty("art_crop")]
        public string art_crop { get; set; }

        [JsonProperty("border_crop")]
        public string border_crop { get; set; }
    }

    public class Legalities
    {
        [JsonProperty("standard")]
        public string standard { get; set; }

        [JsonProperty("future")]
        public string future { get; set; }

        [JsonProperty("historic")]
        public string historic { get; set; }

        [JsonProperty("gladiator")]
        public string gladiator { get; set; }

        [JsonProperty("pioneer")]
        public string pioneer { get; set; }

        [JsonProperty("explorer")]
        public string explorer { get; set; }

        [JsonProperty("modern")]
        public string modern { get; set; }

        [JsonProperty("legacy")]
        public string legacy { get; set; }

        [JsonProperty("pauper")]
        public string pauper { get; set; }

        [JsonProperty("vintage")]
        public string vintage { get; set; }

        [JsonProperty("penny")]
        public string penny { get; set; }

        [JsonProperty("commander")]
        public string commander { get; set; }

        [JsonProperty("oathbreaker")]
        public string oathbreaker { get; set; }

        [JsonProperty("brawl")]
        public string brawl { get; set; }

        [JsonProperty("historicbrawl")]
        public string historicbrawl { get; set; }

        [JsonProperty("alchemy")]
        public string alchemy { get; set; }

        [JsonProperty("paupercommander")]
        public string paupercommander { get; set; }

        [JsonProperty("duel")]
        public string duel { get; set; }

        [JsonProperty("oldschool")]
        public string oldschool { get; set; }

        [JsonProperty("premodern")]
        public string premodern { get; set; }

        [JsonProperty("predh")]
        public string predh { get; set; }
    }

    public class Preview
    {
        [JsonProperty("source")]
        public string source { get; set; }

        [JsonProperty("source_uri")]
        public string source_uri { get; set; }

        [JsonProperty("previewed_at")]
        public string previewed_at { get; set; }
    }

    public class Prices
    {
        [JsonProperty("usd")]
        public string usd { get; set; }

        [JsonProperty("usd_foil")]
        public string usd_foil { get; set; }

        [JsonProperty("usd_etched")]
        public object usd_etched { get; set; }

        [JsonProperty("eur")]
        public string eur { get; set; }

        [JsonProperty("eur_foil")]
        public string eur_foil { get; set; }

        [JsonProperty("tix")]
        public string tix { get; set; }
    }

    public class PurchaseUris
    {
        [JsonProperty("tcgplayer")]
        public string tcgplayer { get; set; }

        [JsonProperty("cardmarket")]
        public string cardmarket { get; set; }

        [JsonProperty("cardhoarder")]
        public string cardhoarder { get; set; }
    }

    public class RelatedUris
    {
        [JsonProperty("gatherer")]
        public string gatherer { get; set; }

        [JsonProperty("tcgplayer_infinite_articles")]
        public string tcgplayer_infinite_articles { get; set; }

        [JsonProperty("tcgplayer_infinite_decks")]
        public string tcgplayer_infinite_decks { get; set; }

        [JsonProperty("edhrec")]
        public string edhrec { get; set; }
    }
    #endregion

}
