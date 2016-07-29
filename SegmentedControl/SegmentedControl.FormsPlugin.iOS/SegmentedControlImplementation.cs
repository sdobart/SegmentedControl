﻿using System;
using Xamarin.Forms;
using SegmentedControl.FormsPlugin.iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(SegmentedControl.FormsPlugin.Abstractions.SegmentedControl), typeof(SegmentedControlRenderer))]
namespace SegmentedControl.FormsPlugin.iOS
{
	/// <summary>
	/// SegmentedControl Renderer
	/// </summary>
	public class SegmentedControlRenderer : ViewRenderer<Abstractions.SegmentedControl, UISegmentedControl>
	{
		UISegmentedControl nativeControl;

		protected override void OnElementChanged(ElementChangedEventArgs<Abstractions.SegmentedControl> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				// Instantiate the native control and assign it to the Control property with
				// the SetNativeControl method

				nativeControl = new UISegmentedControl();

				SetNativeControl(nativeControl);
			}

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources

				if (nativeControl != null)
				    nativeControl.ValueChanged -= nativeControl_ValueChanged;
			}

			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers

				for (var i = 0; i < e.NewElement.Children.Count; i++)
				{
					nativeControl.InsertSegment(e.NewElement.Children[i].Text, i, false);
				}

				nativeControl.TintColor = Element.TintColor.ToUIColor();

				nativeControl.SelectedSegment = Element.SelectedSegment;
				e.NewElement.SelectedText = e.NewElement.Children[0].Text;

				nativeControl.ValueChanged += nativeControl_ValueChanged;
			}
		}

		void nativeControl_ValueChanged(object sender, EventArgs e)
		{
			Element.SelectedSegment = (int)nativeControl.SelectedSegment;
			Element.SelectedText = nativeControl.TitleAt(nativeControl.SelectedSegment);
		}

		protected override void Dispose(bool disposing)
		{
			nativeControl.Dispose();
			nativeControl = null;

			try
			{
				base.Dispose(disposing);
			}
			catch (Exception ex)
			{
				return;
			}
		}

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
		{
			var temp = DateTime.Now;
		}
    }
}
