﻿// Copyright (c) Lykke Corp.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System;
using Lykke.RabbitMqBroker.Subscriber;
using TestInvoke.PublishExample;
using TestInvoke.SubscribeExample;

namespace TestInvoke
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var rabbitMqSettings = new RabbitMqSubscriptionSettings
            {
                QueueName = Environment.GetEnvironmentVariable("RabbitMqQueue"),
                ConnectionString = Environment.GetEnvironmentVariable("RabbitMqConnectionString"),
                ExchangeName = Environment.GetEnvironmentVariable("RabbitMqExchange"),
                DeadLetterExchangeName = Environment.GetEnvironmentVariable("RabbitMqExchange")+ ".dead-letter"
            };

            HowToSubscribe.Example(rabbitMqSettings);
            HowToPublish.Example(rabbitMqSettings);

            Console.WriteLine("Working... Press Enter to stop");
            Console.ReadLine();

            Console.WriteLine("Stopping....");
            HowToSubscribe.Stop();
            Console.WriteLine("Stopped");
            Console.ReadLine();
        }


    }
}
