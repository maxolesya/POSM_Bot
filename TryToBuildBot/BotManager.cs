using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TryToBuildBot
{//https://github.com/cyrilq/WalletKeeper
    //https://github.com/MrRoundRobin/telegram.bot.examples/blob/master/Telegram.Bot.Examples.Echo/Program.cs
    class BotManager
    {
        PosmBot client;
        Route r;
        Handler handler;
        Dictionary<long, ChatInfo> chatDictionary;
        public BotManager(PosmBot _client)
        {   

            chatDictionary = new Dictionary<long, ChatInfo>();
            Middle C2PosmAndPlacement = new Middle(null, null, "C ' 2 POSM & Placement");
            Middle BWD = new Middle(C2PosmAndPlacement, null, "BWD оборудование");
            Middle RKA = new Middle(C2PosmAndPlacement, null, "RKA");
            Middle RRKA = new Middle(RKA, null, "RRKA");
            Final Space = new Final("Простор", "stark.png", RRKA);
            Middle NRKA = new Middle(RKA, null, "NRKA");
            Middle Vict = new Middle(NRKA, null, "Дикси/Виктория");
            Final JUDO = new Final("JUDO", "stark.png", Vict);
            Final OLD_OHD = new Final("OLD OHD", "stark.png", Vict);
            Final OHD = new Final("OHD оборудование", "stark.png", C2PosmAndPlacement);
            Final MasterPlano = new Final("Master Plano", "stark.png", C2PosmAndPlacement);
            Middle Prem_Black_11x15 = new Middle(BWD, null, "Premium Black 11x15 SS");
            Middle Prem_Black_11x12 = new Middle(BWD, null, "Premium Black 11x12 SS");
            Middle A2SS = new Middle(BWD, null, "A2 SS/Non SS");
            Middle Prem_Grey_9x15 = new Middle(BWD, null, "Premium Grey 9x15");
            Middle Prem_Grey_9x12 = new Middle(BWD, null, "Premium Grey 9x12");
            Middle DoorSlim_12x15 = new Middle(BWD, null, "Door Slim 12x15 SS");
            Middle DoorSlim_12x12 = new Middle(BWD, null, "Door Slim 12x12 SS");
            Middle Flap_11x15 = new Middle(BWD, null, "Flap 11x15 SS");
            Middle Flap_11x12 = new Middle(BWD, null, "Flap 11x15 SS");
            Final VFM_ROW_Prem_Black_11x15 = new Final("VFM-", "stark.png", Prem_Black_11x15);
            Final VFM_ROW_Prem_Black_11x12 = new Final("VFM-", "stark.png", Prem_Black_11x12);
            Middle SS = new Middle(A2SS, null, "SS");
            Middle NONSS = new Middle(A2SS, null, "Non SS");
            Final AP_SS = new Final("AP+", "stark.png", SS);
            Final VFM_SS = new Final("VFM-", "stark.png", SS);
            Final AP_NONSS = new Final("AP+", "stark.png", NONSS);
            Final VFM_NON = new Final("VFM-", "stark.png", NONSS);
            Final VFM_ROW_Prem_Grey_9x12 = new Final("VFM-", "stark.png", Prem_Grey_9x12);
            Final VFM_ROW_Prem_Grey_15 = new Final("VFM-", "stark.png", Prem_Grey_9x15);
            Final VFM_ROW_DoorSlim_12x15 = new Final("VFM-", "stark.png", DoorSlim_12x15);
            Final VFM_ROW_DoorSlim_12x12 = new Final("VFM-", "stark.png", DoorSlim_12x12);
            Final VFM_ROW_Flap_11x15 = new Final("VFM-", "stark.png", Flap_11x15);
            Final VFM_ROW_Flap_11x12 = new Final("VFM-", "stark.png", Flap_11x12);
            Final AP_Prem_Black_11x15 = new Final("AP+", "stark.png", Prem_Black_11x15);
            Final AP_Prem_Black_11x12 = new Final("AP+", "stark.png", Prem_Black_11x12);
           
            Final AP_Prem_Grey_9x12 = new Final("AP+", "stark.png", Prem_Grey_9x12);
            Final AP_Prem_Grey_9x15 = new Final("AP+", "stark.png", Prem_Grey_9x15);
            Final AP_DoorSlim15 = new Final("AP+", "stark.png", DoorSlim_12x15);
            Final AP_DoorSlim12 = new Final("AP+", "stark.png", DoorSlim_12x12);
            Final AP_Flap15 = new Final("AP+", "stark.png", Flap_11x15);
            Final AP_Flap12 = new Final("AP+", "stark.png", Flap_11x12);
            C2PosmAndPlacement.Children = new List<Route>() { BWD, MasterPlano, OHD, RKA };
            RKA.Children = new List<Route>() { NRKA, RRKA };
            NRKA.Children = new List<Route>() { Vict };
            Vict.Children = new List<Route>() { JUDO, OLD_OHD };
            RRKA.Children = new List<Route>() { Space };
            Prem_Black_11x15.Children = new List<Route>() { AP_Prem_Black_11x15, VFM_ROW_Prem_Black_11x15 };
            BWD.Children = new List<Route>() { Prem_Black_11x15, Prem_Black_11x12, A2SS, Prem_Grey_9x12, Prem_Grey_9x15, DoorSlim_12x12, DoorSlim_12x15, Flap_11x12, Flap_11x15 };
            Prem_Black_11x12.Children = new List<Route>() { VFM_ROW_Prem_Black_11x12, AP_Prem_Black_11x12 };
            A2SS.Children = new List<Route>() { SS,NONSS };
            SS.Children = new List<Route>() { AP_SS,VFM_SS};
            NONSS.Children = new List<Route>() { AP_NONSS,VFM_NON };
            Prem_Grey_9x15.Children = new List<Route>() { AP_Prem_Grey_9x15, VFM_ROW_Prem_Grey_15 };
            Prem_Grey_9x12.Children = new List<Route>() { AP_Prem_Grey_9x12, VFM_ROW_Prem_Grey_9x12 };
            DoorSlim_12x15.Children = new List<Route>() { AP_DoorSlim15, VFM_ROW_DoorSlim_12x15 };
            DoorSlim_12x12.Children = new List<Route>() { AP_DoorSlim12, VFM_ROW_DoorSlim_12x12 };
            Flap_11x12.Children = new List<Route>() { AP_Flap12, VFM_ROW_Flap_11x12 };
            Flap_11x15.Children = new List<Route>() { AP_Flap15, VFM_ROW_Flap_11x15 };

            r = C2PosmAndPlacement;

            client = _client;
            client.OnMessageReceived += ProcessMessage;

        }
        public async void ProcessMessage(Message message)
        {
            StreamWriter s = new StreamWriter("message.txt",true);
            s.WriteLine(message.Text);
            s.Close();
            if (chatDictionary.ContainsKey(message.Chat.Id) && !message.Text.Contains("start"))
            {
                Console.WriteLine("fsfdf");
                Console.WriteLine(message.Text);
                try
                {
                    ChatInfo chatInfo = chatDictionary[message.Chat.Id];
                   
                    Handler h = handler.ProccessMessage(message, chatDictionary[message.Chat.Id].CurrentNode);
                    handler.SendMessage(client.Bot);
                    chatDictionary[message.Chat.Id].CurrentNode = handler.returnCurrentRoute();
                    handler = h;
                }
                catch (Exception e)
                {
                
                    Console.WriteLine(e.Message);
                }
            }
            else if ( message.Text.Contains("start"))
            {
                Console.WriteLine("Здесь");
                handler = new HandlerLogin();
                if (!chatDictionary.ContainsKey(message.Chat.Id))
                {
                    chatDictionary.Add(message.Chat.Id, new ChatInfo() { ChatId = message.Chat.Id, CurrentNode = r, Login = false, Password = false });
                }
                await client.Bot.SendTextMessageAsync(message.Chat.Id, BotAnswers.InfoMessage(), false, false, 0);
                await client.Bot.SendTextMessageAsync(message.Chat.Id, "Введите логин", false, false, 0);
            }
            else if (Equals(message.Text, "/stop"))
            {
                Console.WriteLine("stop");
                chatDictionary.Remove(message.Chat.Id);
            }
            else if (!chatDictionary.ContainsKey(message.Chat.Id))    
            {
                Console.WriteLine("И тут");
                handler = new HandlerLogin();
                chatDictionary.Add(message.Chat.Id, new ChatInfo() { ChatId = message.Chat.Id, CurrentNode = r, Login = false, Password = false });
                await client.Bot.SendTextMessageAsync(message.Chat.Id, BotAnswers.InfoMessage(), false, false, 0);
                await client.Bot.SendTextMessageAsync(message.Chat.Id, "Введите логин", false, false, 0);
            }


        }
    }
}
