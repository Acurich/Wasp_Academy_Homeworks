using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Net;
using Discord.Commands;
using Bot;
using Discord.Net.WebSockets;
using Discord.WebSocket;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Bot.Modules
{
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        [Command("plus")]
        public async Task Plus(string num1, string num2)
        {
            if (int.TryParse(num1, out int number1) && int.TryParse(num2, out int number2))
                await Context.Channel.SendMessageAsync($"{num1} + {num2} = {number1 + number2}");
            else
                await Context.Channel.SendMessageAsync("Вы ввели строки, вместо чисел");

        }
        [Command("minus")]
        public async Task minus(string num1, string num2)
        {
            if (int.TryParse(num1, out int number1) && int.TryParse(num2, out int number2))
                await Context.Channel.SendMessageAsync($"{num1} - {num2} = {number1 - number2}");
            else
                await Context.Channel.SendMessageAsync("Вы ввели строки, вместо чисел");

        }
        [Command("divide")]
        public async Task divide(string num1, string num2)
        {
            if (int.TryParse(num1, out int number1) && int.TryParse(num2, out int number2))
                await Context.Channel.SendMessageAsync($"{num1} / {num2} = {number1 / number2}");
            else
                await Context.Channel.SendMessageAsync("Вы ввели строки, вместо чисел");

        }
        [Command("multiply")]
        public async Task multiply(string num1, string num2)
        {
            if (int.TryParse(num1, out int number1) && int.TryParse(num2, out int number2))
                await Context.Channel.SendMessageAsync($"{num1} * {num2} = {number1 * number2}");
            else
                await Context.Channel.SendMessageAsync("Вы ввели строки, вместо чисел");

        }
        [Command("scream")]
        public async Task multiply(string word)
        {
            string answer = "";
            for (int i = 0; i < word.Length; i++)
            {
                answer += char.ToUpper(word[i]);
            }
            await Context.Channel.SendMessageAsync($"{word} >> {answer}");
        }
        [Command("purge")]
        public async Task Purge(int amount)
        {
            var mes = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
            await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(mes);
        }
        [Command("destroy")]
        public async Task Destroy()
        {
            SocketGuildChannel Channel = Context.Channel as SocketGuildChannel;
            await Channel.DeleteAsync();
        }
        /*       [Command("info")]
               public async Task Info()
               {
                    string user = Context.User.Id.ToString();

                   await Context.Message.ReplyAsync($":crown:Создатель бота: <@770189539636412416>\n#️⃣Канал: <#912750512548479010>\n⚾Команду вызвал: <@{user}>");
               }
        */
        [Command("connect")]
        public async Task Connect()
        {
            string username = Context.Message.Author.Username;
            string discriminator = Context.Message.Author.Discriminator;
            await Context.Channel.SendMessageAsync($"С подключением, {username}#{discriminator}");
        }
        [Command("time")]
        public async Task Time()
        {
            DateTime time = DateTime.Now;
            await Context.Channel.SendMessageAsync($"{time}");
        }
        [Command("info")]
        public async Task Info(SocketUser user = null)
        {
            string avatarurl = "", usname;
            int days = 0, daysdis = 0;
            string[] datejoin, date, time = DateTime.Now.ToString().Split(" ");
            string textbox1 = time[0];
            if (user == null)
            {
                user = Context.Message.Author;
                avatarurl = Context.Message.Author.GetAvatarUrl();
                date = Context.Message.Author.CreatedAt.ToString().Split(" ");
                datejoin = Context.Guild.GetUser(user.Id).JoinedAt.ToString().Split(" ");
            }
            else
            {
                avatarurl = user.GetAvatarUrl();
                date = user.CreatedAt.ToString().Split(" ");
                datejoin = Context.Guild.GetUser(user.Id).JoinedAt.ToString().Split(" ");
            }
            usname = Context.Guild.GetUser(user.Id).Nickname;
            if (usname == null)
            {
                usname = user.Username;
            }
            List<SocketRole> list_roles = Context.Guild.GetUser(user.Id).Roles.ToList();
            string roles = "";
            for (int i = 0; i < list_roles.Count; i++)
            {
                if (i % 2 == 1 && i != 0)
                {
                    roles += list_roles[i].Mention + "\n";
                }
                else
                {
                    roles += list_roles[i].Mention + ", ";
                }
            }
            string textbox2 = datejoin[0], textbox3 = date[0];
            DateTime date1 = DateTime.Parse(textbox1);
            DateTime date2 = DateTime.Parse(textbox2);
            DateTime date3 = DateTime.Parse(textbox3);
            days = (date1 - date2).Days;
            daysdis = (date1 - date3).Days;
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithColor(Color.Green);
            builder.WithFooter("wasp-naydenko", avatarurl);
            builder.WithAuthor(user);
            builder.WithTitle("INFORMATION" + "\n");
            builder.WithThumbnailUrl(avatarurl);
            builder.AddField(
                "Server:",
                "*Server nickname:* " + "`" + usname + "`" +
                "\n*Join date:* " + datejoin[0] +
                "\n*Join time:* " + datejoin[1] +
                "\n*Days on server:* " + days.ToString(), false);
            builder.AddField(
                "Discord:",
                "*Discord Username:* " + "`" + user.ToString() + "`" +
                "\n*Join date:* " + date[0] +
                "\n*Join time:* " + date[1] +
                "\n*Days in Discord:* " + daysdis.ToString(), false);
            builder.AddField(
                "Roles: ",
                roles, false);
            builder.WithCurrentTimestamp();
            await ReplyAsync(embed: builder.Build());
        }

    }
}
