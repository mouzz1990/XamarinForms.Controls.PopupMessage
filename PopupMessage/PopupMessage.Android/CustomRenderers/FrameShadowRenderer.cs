using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PopupMessage.Controls;
using PopupMessage.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FrameShadow), typeof(FrameShadowRenderer))]
namespace PopupMessage.Droid.CustomRenderers
{
    public class FrameShadowRenderer : FrameRenderer
    {
        public FrameShadowRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var contr = e.NewElement as FrameShadow;

                Elevation = contr.Elevation;

                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(contr.BackgroundColor.ToAndroid());
                gd.SetCornerRadius(contr.CornerRadius * 2);

                Background = gd;
            }
        }
    }
}