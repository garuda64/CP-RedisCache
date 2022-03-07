using StackExchange.Redis;
using System;

namespace RedisSubscriber
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

                //Subscribe to the channel named messages

                sub.Subscribe("miCanal", (channel, message) => {

                    //Output received message
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
                });
                Console.WriteLine("subscribed messages");
                Console.ReadKey();
            }


        }
    }
}
