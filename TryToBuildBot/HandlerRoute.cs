using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TryToBuildBot
{
    class HandlerRoute : Handler
    {

        Message m;
        public override Route returnCurrentRoute()
        {
            return routeCurrent;
        }
        public override Handler ProccessMessage(Message message, Route r)
        {
            m = message;
            if (message.Text == "Вернуться назад")
            {

                Console.WriteLine("Вернуться назад");
                Console.WriteLine(r.Name);
                if (r.Parent==null)
                {
                    Console.WriteLine("ДААА");
                }
                routeCurrent = r.Parent;
                Console.WriteLine(routeCurrent.Name);
            }
            else
            {
                routeCurrent = r.Children.Find(e => e.Name.Equals(message.Text));
                if (routeCurrent==null)
                {
                    routeCurrent = r;
                }

            }
           
            return new HandlerRoute();
        }
        public async override void SendMessage(TelegramBotClient Bot)
        {
           
            await Bot.SendTextMessageAsync(m.Chat.Id, "Выберите действие", false, false, 0, getKeyBoard());
        }
        private ReplyKeyboardMarkup getKeyBoard()
        {
            var rkm = new ReplyKeyboardMarkup();
            if (routeCurrent.Parent != null)
            {
                rkm.Keyboard = new KeyboardButton[routeCurrent.Children.Count + 1][];
                for (int i = 0; i < routeCurrent.Children.Count; i++)
                {
                    rkm.Keyboard[i] = new KeyboardButton[] { new KeyboardButton(routeCurrent.Children[i].Name) };
                }
                rkm.Keyboard[routeCurrent.Children.Count] = new KeyboardButton[] { new KeyboardButton("Вернуться назад") };
            }
            else
            {
                // rkm.Keyboard = new KeyboardButton[1][];
                //rkm.Keyboard[0] = new KeyboardButton[] { new KeyboardButton("C ' 2 POSM & Placement") };
                rkm.Keyboard = new KeyboardButton[routeCurrent.Children.Count][];
                for (int i = 0; i < routeCurrent.Children.Count; i++)
                {
                    rkm.Keyboard[i] = new KeyboardButton[] { new KeyboardButton(routeCurrent.Children[i].Name) };
                }

            }
            return rkm;

        }

    }
}
