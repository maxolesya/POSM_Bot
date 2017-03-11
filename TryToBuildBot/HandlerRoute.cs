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
        bool flag = false;
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
                if (r.Parent != null)
                {
                    routeCurrent = r.Parent;
                }
                else
                {
                    flag = true;
                    Console.WriteLine("tru");
                }


            }
            else
            {
                if (routeCurrent.Children != null)
                {
                    routeCurrent = r.Children.Find(e => e.Name.Equals(message.Text));
                    if (routeCurrent == null)
                    {
                        routeCurrent = r;
                    }
                }
            }

            return new HandlerRoute();
        }
        public async override void SendMessage(TelegramBotClient Bot)
        {
            if (routeCurrent.Children != null)
            {
                await Bot.SendTextMessageAsync(m.Chat.Id, "Выберите действие", false, false, 0, getKeyBoard());
            }

            else
            {
                Final f = (Final)routeCurrent;
                for (int i = 0; i < 2; i++)
                {
                    await Bot.SendPhotoAsync(m.Chat.Id, @"http://www.weather7forecast.com/TI/rc-4-17739.jpg", "", false, 0, getKeyBoard());

                }
            }


        }
        private ReplyKeyboardMarkup getKeyBoard()
        {

            var rkm = new ReplyKeyboardMarkup();
            if (!flag &&/*routeCurrent.Parent != null &&*/ routeCurrent.Children != null)
            {
                rkm.Keyboard = new KeyboardButton[routeCurrent.Children.Count + 1][];
                for (int i = 0; i < routeCurrent.Children.Count; i++)
                {
                    rkm.Keyboard[i] = new KeyboardButton[] { new KeyboardButton(routeCurrent.Children[i].Name) };
                }
                rkm.Keyboard[routeCurrent.Children.Count] = new KeyboardButton[] { new KeyboardButton("Вернуться назад") };
            }
            else if (flag)
            {
                rkm.Keyboard = new KeyboardButton[1][];
                rkm.Keyboard[0] = new KeyboardButton[] { new KeyboardButton("C ' 2 POSM & Placement") };
            }

            else
            {
                rkm.Keyboard = new KeyboardButton[1][];
                rkm.Keyboard[0] = new KeyboardButton[] { new KeyboardButton("Вернуться назад") };
            }
            return rkm;

        }

    }
}
