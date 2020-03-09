﻿// Copyright (c) Lykke Corp.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using Lykke.RabbitMqBroker;
using Lykke.RabbitMqBroker.Subscriber;
using Swisschain.LykkeLog.Adapter;

namespace TestInvoke.SubscribeExample
{
    public static class HowToSubscribe
    {
        private static RabbitMqSubscriber<string> _connector;
        public static void Example(RabbitMqSubscriptionSettings settings)
        {
            _connector =
                new RabbitMqSubscriber<string>(LegacyLykkeLogFactoryToConsole.Instance, settings, 
                        new DefaultErrorHandlingStrategy(LegacyLykkeLogFactoryToConsole.Instance, settings))
                  .SetMessageDeserializer(new TestMessageDeserializer())
                  .CreateDefaultBinding()
                  .Subscribe(HandleMessage)
                  .Start();
        }

        public static void Stop()
        {
            _connector.Stop();
        }

        private static Task HandleMessage(string msg)
        {
            Console.WriteLine(msg);
            return Task.FromResult(0);
        }
    }
}
