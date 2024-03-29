﻿using Stateless; // <--
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.State
{
    public class StatelessLightSwitch
    {
        public StatelessLightSwitch()
        {
            var light = new StateMachine<bool, Trigger>(false);

            light.Configure(false) // if the light is off...
                .Permit(Trigger.On, true)  // we can turn it on
                .OnEntry(transition =>
                {
                    if (transition.IsReentry)
                        Console.WriteLine("Light is already off!");
                    else
                        Console.WriteLine("Switching light off");
                })
                .PermitReentry(Trigger.Off);
            // .Ignore(Trigger.Off) // but if it's already off we do nothing

            // same for when the light is on
            light.Configure(true)
              .Permit(Trigger.Off, false)
              .OnEntry(() => Console.WriteLine("Turning light on"))
              .Ignore(Trigger.On);

            light.Fire(Trigger.On);  // Turning light on
            light.Fire(Trigger.Off); // Turning light off
            light.Fire(Trigger.Off); // Light is already off!
        }
    }
}
