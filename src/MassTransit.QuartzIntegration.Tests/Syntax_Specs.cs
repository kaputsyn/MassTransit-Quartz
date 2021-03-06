﻿// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.QuartzIntegration.Tests
{
    using Magnum.Extensions;
    using NUnit.Framework;
    using Scheduling;


    [TestFixture]
    public class Syntax_Specs
    {
        [Test]
        public void Should_have_a_clean_syntax()
        {
            IServiceBus bus = ServiceBusFactory.New(x => x.ReceiveFrom("loopback://localhost/client"));
            using (bus)
            {
                ScheduledMessage<A> scheduledMessage = bus.ScheduleMessage(5.Seconds().FromNow(), new A());

                Assert.IsNotNull(scheduledMessage);
            }
        }


        class A
        {
        }
    }
}