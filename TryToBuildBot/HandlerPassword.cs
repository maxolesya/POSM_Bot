using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TryToBuildBot
{
    class HandlerPassword : Handler
    {

        public bool flag = false;
     
        HandlerLogin h;
        Message m;
        public async override void SendMessage(TelegramBotClient Bot)
        {
            if (flag)
            {
                var rkm = new ReplyKeyboardMarkup();

                rkm.Keyboard =
                    new KeyboardButton[][]
                    {
                      new KeyboardButton[]
                      {
                         new KeyboardButton("C ' 2 POSM & Placement"),
                      }
                    };

                await Bot.SendTextMessageAsync(m.Chat.Id, "Выберите действие", false, false, 0, rkm);
            }
            else
            {
                await Bot.SendTextMessageAsync(m.Chat.Id, "Логин или пароль неверны. Введите логин", false, false, 0);
            }


        }
        public override Handler ProccessMessage(Message message, Route r)
        { m = message;
            using (Context c = new Context())
            {
                
                Console.WriteLine(  c.Users.Count() );
                User user = c.Users.FirstOrDefault(u => u.Login == h.m.Text);
                if (user == null || string.IsNullOrEmpty(message.Text) || getMd5Hash( message.Text) != user.Password)
                {
                    return new HandlerLogin();
                }
                else
                {
                    flag = true;
                    return new HandlerRoute();
                }
            }
        }
        public HandlerPassword(HandlerLogin hl)
        {
            h = hl;
        }
        public static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
