using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    public class ServerClass
    {
        public String test;

        // The method that will be called when the thread is started.
        public void InstanceMethod()
        {
            Console.WriteLine(
                "ServerClass.InstanceMethod is running on another thread.");
            var manager = new RedisManagerPool("localhost:6379");
            using (var client = manager.GetClient())
            {
                client.Set("foo", "bar");
                Console.WriteLine("foo={0}", client.Get<string>("foo"));
            }
            // Pause for a moment to provide a delay to make
            // threads more apparent.
            Thread.Sleep(3000);
            Console.WriteLine(
                "The instance method called by the worker thread has ended.");

           
        }

        public static void StaticMethod()
        {
            Console.WriteLine(
                "ServerClass.StaticMethod is running on another thread.");

            // Pause for a moment to provide a delay to make
            // threads more apparent.
            Thread.Sleep(5000);
            Console.WriteLine(
                "The static method called by the worker thread has ended.");
        }
    }
}
