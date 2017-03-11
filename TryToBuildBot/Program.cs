using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TryToBuildBot
{
    class Program
    {
        static void Main(string[] args)
        {
        
            PosmBot bot = new PosmBot();
            bot.testApiAsync();
            BotManager manager = new BotManager(bot);
            Console.ReadLine();
            

        }

    }
    
}
