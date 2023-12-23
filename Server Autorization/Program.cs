using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_Autorization
{
    internal class Program
    {
        private static String Gen(int len)
        {
            String str = "";
            Random rnd = new Random();
           
            for (int i = 0; i < len; i++)
            {
                str += (char)rnd.Next(255);
            }

            return str;
        }
        static void Main(string[] args)
        {
            string Login = "123";
            string Pass = "123";
            Console.WriteLine(Gen(256));
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            TcpListener _listener = new TcpListener(ipPoint);
            try
            {
                byte[] buffer = new byte[100];
                _listener.Start();
                Console.WriteLine("Сервер запущен");
                TcpClient handler = _listener.AcceptTcpClient();
                NetworkStream stream = handler.GetStream();
                Console.WriteLine(handler.Client.Connected);
                stream.Read(buffer, 0, 100);

                Console.WriteLine(Encoding.UTF8.GetString(buffer));
                //Console.WriteLine(Gen(256));
                Console.Read();




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
