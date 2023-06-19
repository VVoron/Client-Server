using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server
{
    public static class ChatController
    {
        private const int _maxMessage = 100;
        public static List<message> Chat = new List<message>();
        public struct message
        {
            public string time;
            public string userName;
            public string data;
            public message(string timenow, string name, string msg)
            {
                time = timenow;
                userName = name;
                data = msg;
            }
        }
        public static void AddMessage(string timenow, string userName, string msg)
        {
            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(msg)) return;
                int countMessages = Chat.Count;
                if (countMessages > _maxMessage) ClearChat();
                message newMessage = new message(timenow, userName, msg);
                Chat.Add(newMessage);
                Console.WriteLine("New message [{0}] {1}: {2}.", timenow, userName, msg);
                Server.UpdateAllChats();
            }
            catch (Exception exp) { Console.WriteLine("Error with addMessage: {0}.", exp.Message); }
        }
        public static void ClearChat()
        {
            Chat.Clear();
        }
        public static string GetChat()
        {
            try
            {
                string data = "#updatechat&";
                int countMessages = Chat.Count;
                if (countMessages <= 0) return string.Empty;
                for (int i = 0; i < countMessages; i++)
                {
                    data += String.Format("{0}~{1}~{2}|", Chat[i].time, Chat[i].userName, Chat[i].data);
                }
                return data;
            }
            catch (Exception exp) { Console.WriteLine("Error with getChat: {0}", exp.Message); return string.Empty; }
        }
    }
}
