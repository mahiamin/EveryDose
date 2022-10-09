using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EveryDose.Effects
{
    public class EntryEffect : RoutingEffect
    {
        public EntryEffect() : base($"EveryDose.{nameof(EntryEffect)}")
        {
        }
    }
}
