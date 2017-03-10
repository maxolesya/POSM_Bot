using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TryToBuildBot
{
    class HandlerPassword : Handler
    {
        HandlerLogin hl;
        public override void SendMessage(TelegramBotClient Bot)
        {
            base.SendMessage(Bot);
        }
        public override Handler ProccessMessage(Message message)
        {
            return base.ProccessMessage(message);
        }
        public HandlerPassword(HandlerLogin hl)
        {
            this.hl = hl;
        }
    }
}
