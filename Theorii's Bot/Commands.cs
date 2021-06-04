using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Net;

namespace Theorii_s_Bot
{
    class Commands : BaseCommandModule
    {
        [Command("changeEverything")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "WEEB" })]
        public async Task ChangeName(CommandContext ctx)
        {

            IEnumerable<DiscordMember> members = ctx.Channel.Users;

            foreach (DiscordMember member in members)
            {
                try
                {
                    WebClient _client = new WebClient();
                    string[] names = _client.DownloadString("https://www.wordgenerator.net/application/p.php?id=adjectives&type=1&spaceflag=false").Split(",");
                    Random rand = new Random();
                    string name = names[rand.Next(0, names.Length - 1)];
                    await member.ModifyAsync(x => x.Nickname = $"Theorii, but {name}");


                    var newNameEmbed = new DiscordEmbedBuilder
                    {
                        Title = $"You have been granted a name!",
                        Color = DiscordColor.Blue
                    };

                    newNameEmbed.AddField("Name:", $"\"Theorii, but {name}\"");

                    await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"{member.Mention}").ConfigureAwait(false);
                    var newNameMessage = await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync(embed: newNameEmbed).ConfigureAwait(false);
                }
                catch (Exception z)
                {
                    await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"Another Stupid error ::::: {z.Message}").ConfigureAwait(false);
                }
            }
        }

        [Command("giveRoleBack")]
        public async Task GiveRoleBack(CommandContext ctx)
        {
            var role = ctx.Guild.GetRole(693201204309786625);
            var role2 = ctx.Guild.GetRole(691522870517694505);
            await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
            await ctx.Member.GrantRoleAsync(role2).ConfigureAwait(false);

        }

        [Command("giveGod")]
        public async Task GiveGod(CommandContext ctx)
        {
            if(ctx.Member.Id == 169277776161931265)
            {
                var role = ctx.Guild.GetRole(691522870517694505);
                await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
            }
        }

        [Command("changeRoleAll")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "Deity" })]
        public async Task ChangeRoleAll(CommandContext ctx)
        {

            IEnumerable<DiscordMember> members = ctx.Channel.Users;

            foreach (DiscordMember member in members)
            {
                try
                {
                    var role = ctx.Guild.GetRole(691527417730433035);
                    await member.GrantRoleAsync(role).ConfigureAwait(false);
                }
                catch (Exception z)
                {
                    await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"Another error ::::: {z.Message}").ConfigureAwait(false);
                }
            }
        }

        [Command("listMembers")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "Deity" })]
        private async Task ListMembers(CommandContext ctx)
        {
            IReadOnlyCollection<DiscordMember> members = await ctx.Guild.GetAllMembersAsync();
            foreach(DiscordMember member in members)
            {
                await ctx.Channel.SendMessageAsync(member.Nickname);
            }
        }

        [Command("changeToTheorii")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "Deity" })]
        private async Task ChangeToTheorii(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("1");
            IEnumerable<DiscordMember> members = ctx.Channel.Users;
            await ctx.Channel.SendMessageAsync("2");
            foreach (DiscordMember member in members)
            {
                await ctx.Channel.SendMessageAsync("3");
                
                try
                {
                

                if (member.Nickname.Contains("T") == false)
                    {
                    await ctx.Channel.SendMessageAsync("4");
                    
                    WebClient _client = new WebClient();
                    string[] names = _client.DownloadString("https://www.wordgenerator.net/application/p.php?id=adjectives&type=1&spaceflag=false").Split(",");
                    Random rand = new Random();
                    string name = names[rand.Next(0, names.Length - 1)];

                
                    await ctx.Channel.SendMessageAsync($"{member.Nickname} does not have a theorii name");
                    await ctx.Channel.SendMessageAsync("5");

                    await member.ModifyAsync(x => x.Nickname = $"Theorii, but {name}");

                    
                    var newNameEmbed = new DiscordEmbedBuilder
                    {
                        Title = $"You have been granted a name!",
                        Color = DiscordColor.Blue
                    };

                    newNameEmbed.AddField("Name:", $"\"Theorii, but {name}\"");

                    await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"{member.Mention}").ConfigureAwait(false);
                    var newNameMessage = await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync(embed: newNameEmbed).ConfigureAwait(false);
                    
                }

                }
                catch (Exception z)
                {
                    await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"Another Stupid error ::::: {z.Message}").ConfigureAwait(false);
                }
                
            }
        }

        [Command("changeName")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "Deity" })]
        private async Task ChangeName(CommandContext ctx, DiscordMember member)
        {
            try
            {
                WebClient _client = new WebClient();
                string[] names = _client.DownloadString("https://www.wordgenerator.net/application/p.php?id=adjectives&type=1&spaceflag=false").Split(",");
                Random rand = new Random();
                string name = names[rand.Next(0, names.Length - 1)];
                await member.ModifyAsync(x => x.Nickname = $"Theorii, but {name}");


                var newNameEmbed = new DiscordEmbedBuilder
                {
                    Title = $"You have been granted a name!",
                    Color = DiscordColor.Blue
                };

                newNameEmbed.AddField("Name:", $"\"Theorii, but {name}\"");

                await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"{member.Mention}").ConfigureAwait(false);
                var newNameMessage = await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync(embed: newNameEmbed).ConfigureAwait(false);



            }
            catch (Exception z)
            {
                await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"Another error ::::: {z.Message}").ConfigureAwait(false);
            }
        }

        [Command("changeName2")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "Deity" })]
        private async Task ChangeNameID(CommandContext ctx, DiscordMember member3, string name)
        {
            try
            {
                DiscordMember member = member3;

               
                await member.ModifyAsync(x => x.Nickname = $"Theorii, but {name}");

            }
            catch (Exception z)
            {
                await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"Another Stupid error ::::: {z.Message}").ConfigureAwait(false);
            }
        }

        [Command("changeMyOwnName")]

        private async Task ChangeMyOwnName(CommandContext ctx, string name)
        {
            try
            {
                DiscordMember member = ctx.Guild.GetMemberAsync(691887693029703682).Result;
                await member.ModifyAsync(x => x.Nickname = $"Theorii, but {name}");

            }
            catch (Exception z)
            {
                await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"Another Stupid error ::::: {z.Message}").ConfigureAwait(false);
            }
        }

        [Command("changeTheoriisName")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "Deity" })]
        private async Task ChangeTheoriisName(CommandContext ctx, string name)
        {
            try
            {
                await ctx.Guild.GetMemberAsync(441799785545072661).Result.ModifyAsync(x => x.Nickname = $"Theorii, but {name}");
            }
            catch (Exception z)
            {
                await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"Another Stupid error ::::: {z.Message}").ConfigureAwait(false);
            }
        }

        [Command("ban")]
        [RequireRoles(RoleCheckMode.Any, new string[] { "Deity" })]
        private async Task BanUser(CommandContext ctx, DiscordMember member, string reason)
        {
            try
            {
                string memberName = member.Username;
                await ctx.Guild.BanMemberAsync(member, 0, reason);

                var newNameEmbed = new DiscordEmbedBuilder
                {
                    Title = $"Someone has been banned!",
                    Color = DiscordColor.Red
                };

                newNameEmbed.AddField("Name: " + memberName, "Reason: " + reason);


                var newNameMessage = await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync(embed: newNameEmbed).ConfigureAwait(false);
            }
            catch(Exception e)
            {
                await ctx.Guild.GetChannel(692232391707721728).SendMessageAsync($"Another Stupid error ::::: {e.Message}").ConfigureAwait(false);
            }
        }
    }
}
