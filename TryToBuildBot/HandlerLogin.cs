using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TryToBuildBot
{
    class HandlerLogin : Handler
    {
        public bool flag = false;
        public Message m;
        public override Handler ProccessMessage(Message message, Route r)
        {
            m = message;
            flag = true;
            
            return new HandlerPassword(this);
        }
        public async override void SendMessage(TelegramBotClient Bot)
        {
            await Bot.SendTextMessageAsync(m.Chat.Id, "Введите пароль", false, false, 0);
        }
       
    }
}
