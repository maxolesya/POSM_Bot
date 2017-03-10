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
        public override Handler ProccessMessage(Message message,Route r)
        {
            m = message;
            if (message.Text == "12345" && h.m.Text == "olesya")
            {
                flag = true;
                return new HandlerRoute();
            }
            else
            {
                return new HandlerLogin();
            }


        }
        public HandlerPassword(HandlerLogin hl)
        {
            h = hl;
        }

    }
}
