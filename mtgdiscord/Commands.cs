﻿using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using mtgdiscord.Cards;
using mtgdiscord.MultiFacedCards;

namespace csharpi.Services
{
    // interation modules must be public and inherit from an IInterationModuleBase
    public class ExampleCommands : InteractionModuleBase<SocketInteractionContext>
    {
        // dependencies can be accessed through Property injection, public properties with public setters will be set by the service provider
        public InteractionService Commands { get; set; }
        private CommandHandler _handler;

        // constructor injection is also a valid way to access the dependecies
        public ExampleCommands(CommandHandler handler)
        {
            _handler = handler;
        }

        // our first /command!
        [SlashCommand("card", "Enter a card name and I'll paste an image of it here.")]
        public async Task EightBall(string name)
        {
            //give us some time to come up with a response
            await DeferAsync();
            try
            {
                var card = await CardFactory.getCardByName(name);
                await ModifyOriginalResponseAsync(m => m.Content = new Optional<String>(card.getCardName()));

                foreach (var uri in card.getCardImageURIs())
                {
                    await FollowupAsync(uri);
                }
            }
            catch(Exception ex) 
            {
                await ModifyOriginalResponseAsync(m => m.Content = new Optional<String>(ex.ToString()));
            }
        }
    }
}