﻿// Copyright (c) Lykke Corp.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Threading;
using Lykke.RabbitMqBroker.Publisher;
using Lykke.RabbitMqBroker.Subscriber;
using Swisschain.LykkeLog.Adapter;

namespace TestInvoke.PublishExample
{
    public static class HowToPublish
    {
        public static void Example(RabbitMqSubscriptionSettings settings)
        {

            var connection
                = new RabbitMqPublisher<string>(LegacyLykkeLogFactoryToConsole.Instance, settings)
                .SetSerializer(new TestMessageSerializer())
                .SetPublishStrategy(new DefaultFanoutPublishStrategy(settings))
                .DisableInMemoryQueuePersistence()
                .Start();


            for (var i = 0; i <= 10; i++)
            {
                connection.ProduceAsync("message#" + i);
                Thread.Sleep(3000);
            }
        }

    }
}
