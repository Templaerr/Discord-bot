using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyFirstBot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "ODQwOTE2Mjk5NDU0MDg3MTg4.YJfKVQ.AKev6mGi0UP0SnrzmlanwtaFSeE",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            });
            commands.RegisterCommands<MyFirstModule>();

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Author != s.CurrentUser)
                {
                    if (e.Message.Content.StartsWith("Templaer is cool"))
                    {
                        await e.Message.RespondAsync("Dat klopt!");
                        return;
                    }

                    if (e.Message.Content.StartsWith("Templaer is noob"))
                    {
                        await e.Message.RespondAsync("Nee je bent zelf noob");
                        await e.Message.Channel.SendMessageAsync("https://cdn.discordapp.com/emojis/840888950377545738.png?v=1");
                        return;
                    }

                    if (e.Message.Content.StartsWith("ping"))
                    {
                        await e.Message.Channel.SendMessageAsync("pong");
                        return;
                    }
                    if (e.Message.Content.StartsWith("ez"))
                    {
                        await e.Message.Channel.SendMessageAsync("https://www.youtube.com/watch?v=GsQXadrmhws");
                        return;
                    }
  
                }
            };
            
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }

    public class MyFirstModule : BaseCommandModule
    {
        [Command("makememe")]
        public async Task MakeMeme(CommandContext ctx, [RemainingText] string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                await ctx.RespondAsync("Type !makememe (your meme) to get a meme!");
                return;
            }

            if (input != "")
            {
                await ctx.RespondAsync($"http://62.171.166.208:82/Meme/pepesign?text={HttpUtility.UrlEncode($"{input}")}");
                return;
            }    
        }
    }
}
