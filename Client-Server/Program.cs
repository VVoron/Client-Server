﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client_Server
{
    internal class Program
    {
        private const string _serverHost = "localhost";
        private const int _serverPort = 4000;
        private static Thread _serverThread;
        static void Main(string[] args)
        {
            _serverThread = new Thread(startServer);
            _serverThread.IsBackground = true;
            _serverThread.Start();
            while (true)
                handlerCommands(Console.ReadLine());
        }
        private static void handlerCommands(string cmd)
        {
            cmd = cmd.ToLower();
            if (cmd.Contains("/getusers"))
            {
                int countUsers = Server.Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    Console.WriteLine("[{0}]: {1}", i, Server.Clients[i].UserName);
                }
            }
        }
        private static void startServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            socket.Listen(1000);
            Console.WriteLine("Server has been started", ipEndPoint);
            while (true)
            {
                try
                {
                    Socket user = socket.Accept();
                    Server.NewClient(user);
                }
                catch (Exception exp) { Console.WriteLine("Error: {0}", exp.Message); }
            }

        }
    }
}
