using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Form1 : Form
    {
        private delegate void printer(string data);
        printer Printer;
        private delegate void cleaner();
        cleaner Cleaner;
        private Socket serverSocket;
        public Thread clientThread;
        private const string serverHost = "localhost";
        private const int serverPort = 4000;
        public Form1()
        {
            InitializeComponent();
            tBoxChat.Enabled = false;
            tBoxMsg.Enabled = false;
            BtnSendMsg.Enabled = false;
            Printer = new printer(print);
            Cleaner = new cleaner(clearChat);
            Connect();
            clientThread = new Thread(listner);
            clientThread.IsBackground = true;
            clientThread.Start();
        }
        private void listner()
        {
            while (serverSocket.Connected)
            {
                byte[] buffer = new byte[8196];
                int bytesRead = serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                if (data.Contains("#updatechat"))
                {
                    UpdateChat(data);
                    continue;
                }
            }
        }
        private void Send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesRead = serverSocket.Send(buffer);
            }
            catch
            {
                print("Connection lost...");
            }
        }
        private void Connect()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(serverHost);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, serverPort);
                serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(ipEndPoint);
            }
            catch
            {
                print("Чат недоступен");
            }
            
        }
        private void UpdateChat(string data)
        {
            clearChat();
            string[] messages = data.Split('&')[1].Split('|');
            int CountMessages = messages.Length;
            if (CountMessages <= 0) return;
            for (int i = 0; i < CountMessages; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    print(String.Format("[{0}]{1}:{2}.", messages[i].Split('~')[0], messages[i].Split('~')[1], messages[i].Split('~')[2]));
                }
                catch
                {
                    continue;
                }
            }
        }
        private void clearChat()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Cleaner);
                return;
            }
            tBoxChat.Clear();
        }
        private void print(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg);
                return;
            }
            if (tBoxChat.Text.Length == 0)
            {
                tBoxChat.AppendText(msg);
            }
            else
            {
                tBoxChat.AppendText(Environment.NewLine + msg);
            }
        }
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            string Name = tBoxUserName.Text;
            if (string.IsNullOrEmpty(Name)) return;
            Send("#setname&" + Name);
            tBoxChat.Enabled = true;
            tBoxChat.Clear();
            tBoxMsg.Enabled = true;
            BtnSendMsg.Enabled = true;
        }

        private void BtnSendMsg_Click(object sender, EventArgs e)
        {
            sendMessage();
        }
        private void sendMessage()
        {
            try
            {
                string data = tBoxMsg.Text;
                if (string.IsNullOrEmpty(data)) return;
                Send("#newmsg&" + data);
                tBoxMsg.Text = string.Empty;
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }
    }
}
