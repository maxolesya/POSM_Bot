using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TryToBuildBot
{
    class Handler
    {
        public virtual Handler ProccessMessage (Message message)
        {
            return null;
        }
        public virtual void SendMessage (Telegram.Bot.TelegramBotClient Bot)
        {
           
        }
    }
}
