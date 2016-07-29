﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SegmentedControl.FormsPlugin.Abstractions
{
    /// <summary>
    /// SegmentedControl Interface
    /// </summary>
    public class SegmentedControl : View, IViewContainer<SegmentedControlOption>
	{
		public IList<SegmentedControlOption> Children { get; set; }

		public SegmentedControl()
		{
			Children = new List<SegmentedControlOption>();
		}

		public event ValueChangedEventHandler ValueChanged;
		public delegate void ValueChangedEventHandler(object sender, EventArgs e);

		public static readonly BindableProperty SelectedSegmentProperty = BindableProperty.Create("SelectedSegment", typeof(int), typeof(SegmentedControl), 0);

		public int SelectedSegment
		{
			get { return (int)GetValue(SelectedSegmentProperty); }
			set { SetValue(SelectedSegmentProperty, value); }
		}

		private string _selectedText;
		public string SelectedText
		{
			get
			{
				return _selectedText;
			}
			set
			{
				_selectedText = value;
				if (ValueChanged != null)
					ValueChanged(this, EventArgs.Empty);
			}
		}

		public static readonly BindableProperty TintColorProperty = BindableProperty.Create("TintColor", typeof(Color), typeof(SegmentedControl), Color.FromHex("#007AFF"));

		public Color TintColor
		{
			get { return (Color)GetValue(TintColorProperty); }
			set { SetValue(TintColorProperty, value); }
		}
    }

	public class SegmentedControlOption : View
	{
		public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(SegmentedControlOption), string.Empty);

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
	}
}
