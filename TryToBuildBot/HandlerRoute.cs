using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TryToBuildBot
{
    class HandlerRoute:Handler
    {
        public override Handler ProccessMessage(Message message)
        {
            return base.ProccessMessage(message);
        }
        public override void SendMessage(TelegramBotClient Bot)
        {
            base.SendMessage(Bot);
        }

    }
}
