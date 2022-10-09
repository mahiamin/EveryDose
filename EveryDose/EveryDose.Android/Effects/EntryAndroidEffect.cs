using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EveryDose.Droid.Effects;
using EveryDose.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("EveryDose")]
[assembly: ExportEffect(typeof(EntryAndroidEffect), nameof(EntryEffect))]

namespace EveryDose.Droid.Effects
{
    public class EntryAndroidEffect : PlatformEffect
    {

        protected override void OnAttached()
        {
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}