﻿using Android.Widget;
using Android.Util;
using Android.App;

[assembly: Xamarin.Forms.ExportRenderer(typeof(VidyoConnector.Controls.NativeView), typeof(VidyoConnector.Android.NativeViewRenderer))]

namespace VidyoConnector.Android
{
    public class NativeViewRenderer : Xamarin.Forms.Platform.Android.ViewRenderer<VidyoConnector.Controls.NativeView, FrameLayout>
    {
        FrameLayout _frameLayout;

        public NativeViewRenderer() { }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<VidyoConnector.Controls.NativeView> e)
        {
            base.OnElementChanged(e);

            if (Control == null) {
                // Instantiate the native control and assign it to the Control property with
                // the SetNativeControl method
                _frameLayout = new FrameLayout(this.Context);
                SetNativeControl(_frameLayout);
            }

            if (e.OldElement != null) {
                // Unsubscribe from event handlers and cleanup any resources
                VidyoController.GetInstance().Cleanup();
            }

            if (e.NewElement != null) {
                // Configure the control and subscribe to event handlers
#if true
                DisplayMetrics displayMetrics = Application.Context.Resources.DisplayMetrics;
                e.NewElement.Density = displayMetrics.Density;
#endif
                e.NewElement.Handle  = this.Control.Handle;
            }
        }
    }
}
