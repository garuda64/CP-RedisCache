using StackExchange.Redis;
using System;

namespace RedisPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string cadenaConexion = "localhost:6379";


            //Create a connection
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(cadenaConexion))
            {
                ISubscriber sub = redis.GetSubscriber();

                Console.WriteLine("please enter any character and exit to exit");

                string input;

                do
                {
                    input = Console.ReadLine();
                    sub.Publish("miCanal", input);
                } while (input != "exit");
            }


        }
    }
}
