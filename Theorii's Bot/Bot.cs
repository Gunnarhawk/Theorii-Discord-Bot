using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace Theorii_s_Bot
{
    public class Bot
    {
        public DiscordClient client { get; private set; }

        public CommandsNextExtension commands { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            client = new DiscordClient(config);

            client.Ready += Client_Ready;
            client.Heartbeated += Client_HeartBeat;
            client.MessageCreated += Client_MessageCreated;
            

            client.GuildMemberAdded += Client_GuildMemberAdded;

            client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(2)
            });

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true
            };

            commands = client.UseCommandsNext(commandsConfig);

            commands.RegisterCommands<Commands>();

            await client.ConnectAsync();

            await Task.Delay(-1); // Wait forever
        }

        private async Task Client_MessageCreated(MessageCreateEventArgs e)
        {
            DiscordMember Theo = await e.Guild.GetMemberAsync(441799785545072661).ConfigureAwait(false);

            if(e.Author == Theo)
            {
                await e.Message.DeleteAsync();
            }
        }

        private async Task Client_HeartBeat(HeartbeatEventArgs e)
        {
            var client = e.Client;
            DiscordGuild guild = await client.GetGuildAsync(646523642381074433).ConfigureAwait(false);
            DiscordChannel channel = guild.GetChannel(713429093160452167);
            DiscordMember Rhyoa = await guild.GetMemberAsync(313476517495570437).ConfigureAwait(false);
            DiscordMember Theo = await guild.GetMemberAsync(441799785545072661).ConfigureAwait(false);
            DiscordMember Jag = await guild.GetMemberAsync(230502685789388801).ConfigureAwait(false);
            DiscordMember Gunnar = await guild.GetMemberAsync(169277776161931265).ConfigureAwait(false);
            DiscordMember Crimson = await guild.GetMemberAsync(316355016548024320).ConfigureAwait(false);
            DiscordMember coco = await guild.GetMemberAsync(382621114511261696).ConfigureAwait(false);

            await MuteMembers(client);
            await channel.SendMessageAsync(Theo.Mention + " get on");
            await Theo.SendMessageAsync(Theo.Mention + " get on");

           
            
            string path = "C:\\Users\\Karl Lindahl\\Desktop\\keyloggs_lmao.txt";
            bool fileActive = false;
            using (StreamReader sr = new StreamReader(path)) 
            {
                string x = await sr.ReadToEndAsync();
                if(x.ToLower() == "remind")
                { 
                    await Jag.SendMessageAsync(Jag.Mention + " are you on Well?");
                    fileActive = true;
                }
            }

            if(fileActive == true)
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    await sw.WriteAsync("");
                }
            }
            
        }
        
        public async Task MuteMembers(DiscordClient client)
        {
            DiscordGuild guild = await client.GetGuildAsync(646523642381074433).ConfigureAwait(false);
            DiscordChannel channel = guild.GetChannel(692232391707721728);
            DiscordMember Rhyoa = await guild.GetMemberAsync(313476517495570437).ConfigureAwait(false);
            DiscordMember Theo = await guild.GetMemberAsync(441799785545072661).ConfigureAwait(false);
            DiscordMember Jag = await guild.GetMemberAsync(230502685789388801).ConfigureAwait(false);
            DiscordMember Crimson = await guild.GetMemberAsync(316355016548024320).ConfigureAwait(false);
            DiscordMember coco = await guild.GetMemberAsync(382621114511261696).ConfigureAwait(false);

            List<DiscordMember> WishTeam = new List<DiscordMember>();
            WishTeam.Add(Rhyoa);
            WishTeam.Add(Theo);
            WishTeam.Add(Jag);
            WishTeam.Add(Crimson);
            WishTeam.Add(coco);

            DiscordChannel fullWish = guild.GetChannel(713429774931853326);

            foreach (DiscordMember member in fullWish.Users)
            {
                bool found = false;
                foreach (DiscordMember wishMember in WishTeam)
                {
                    //Debug.WriteLine(member.Nickname);
                    if (member.Id != wishMember.Id)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    await channel.SendMessageAsync(""+member.Id);
                }
            }
        }
        

        private async Task Client_GuildMemberAdded(GuildMemberAddEventArgs e)
        {
            try
            {
                Random rand2 = new Random();
                int x = rand2.Next(0, 2);
                WebClient _client = new WebClient();
                string[] names = _client.DownloadString("https://www.wordgenerator.net/application/p.php?id=adjectives&type=1&spaceflag=false").Split(",");
                Random rand = new Random();
                string name = names[rand.Next(0, names.Length - 1)];
                DiscordMember member = e.Member;
                await member.ModifyAsync(x => x.Nickname = $"Theorii, but {name}");

                await e.Guild.GetChannel(646523642381074436).SendMessageAsync($"{member.Mention} Go check the {e.Guild.GetChannel(691522435002138695).Mention} channel").ConfigureAwait(false);
                var role = e.Guild.GetRole(691527417730433035);
                await member.GrantRoleAsync(role).ConfigureAwait(false);

                IEnumerable<DiscordMember> members = e.Guild.GetChannel(692232391707721728).Users;
                foreach (DiscordMember mem in members)
                {
                    if(mem.Id == 441799785545072661)
                    {
                        await e.Guild.GetChannel(646523642381074436).SendMessageAsync($"{mem.Mention} someone has joined your server!!!").ConfigureAwait(false);
                    }
                }

                IEnumerable<DiscordMember> members2 = e.Guild.GetChannel(692232391707721728).Users;
                foreach (DiscordMember mems in members2)
                {
                    if (mems.Id == 713595650096365640)
                    {
                        await e.Guild.GetChannel(646523642381074436).SendMessageAsync($"{mems.Mention} someone has joined your server!!!").ConfigureAwait(false);
                    }
                }

                IEnumerable<DiscordMember> members3 = e.Guild.GetChannel(692232391707721728).Users;
                foreach (DiscordMember mems in members3)
                {
                    if (mems.Id == 720441029375033364)
                    {
                        await e.Guild.GetChannel(646523642381074436).SendMessageAsync($"{mems.Mention} someone has joined your server!!!").ConfigureAwait(false);
                    }
                }
            }
            catch (Exception z)
            {
                await e.Guild.GetChannel(662132852925923328).SendMessageAsync($"Another Stupid error ::::: {z.Message}").ConfigureAwait(false);
            }
        }

        private Task Client_Ready(ReadyEventArgs e)
        {

            return Task.CompletedTask;
        }
    }
}
