using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PopupMessage.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupMessage : ContentView
	{
        public PopupMessage()
        {
            InitializeComponent();
            Opacity = 0;
            IsVisible = false;
        }

        #region Bindable Properties
        public static readonly BindableProperty PopupContentProperty = BindableProperty.Create("PopupContent", typeof(View), typeof(PopupMessage), default(View),
            propertyChanged:
            (bindable, oldValue, newValue) =>
            {
                PopupMessage pm = bindable as PopupMessage;
                pm.mainContent.Content = newValue as View;
            }
            );

        public View PopupContent
        {
            get { return (View)GetValue(PopupContentProperty); }
            set { SetValue(PopupContentProperty, value); }
        }

        public static readonly BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(ImageSource), typeof(PopupMessage), default(ImageSource),
            propertyChanged:
            (bindable, oldValue, newValue) =>
            {
                PopupMessage pm = bindable as PopupMessage;
                pm.img.Source = newValue as ImageSource;
            }
            );

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly BindableProperty ButtonColorProperty = BindableProperty.Create("ButtonColor", typeof(Color), typeof(PopupMessage), default(Color),
            propertyChanged:
            (bindable, oldValue, newValue) =>
            {
                PopupMessage pm = bindable as PopupMessage;
                pm.btnHide.BackgroundColor = (Color)newValue;
            }
            );

        public Color ButtonColor
        {
            get { return (Color)GetValue(ButtonColorProperty); }
            set { SetValue(ButtonColorProperty, value); }
        }

        public static readonly BindableProperty ButtonTextColorProperty = BindableProperty.Create("ButtonTextColor", typeof(Color), typeof(PopupMessage), default(Color),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                PopupMessage pm = bindable as PopupMessage;
                pm.btnHide.TextColor = (Color)newValue;
            });

        public Color ButtonTextColor
        {
            get { return (Color)GetValue(ButtonTextColorProperty); }
            set { SetValue(ButtonTextColorProperty, value); }
        }

        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create("ButtonText", typeof(string), typeof(PopupMessage), default(string),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                PopupMessage pm = bindable as PopupMessage;
                pm.btnHide.Text = newValue as string;
            });

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public static readonly BindableProperty ButtonSizeProperty = BindableProperty.Create("ButtonSize", typeof(double), typeof(PopupMessage), default(double),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                PopupMessage pm = bindable as PopupMessage;
                double size = (double)newValue;

                pm.btnHide.HeightRequest = size;
                pm.btnHide.WidthRequest = size;
                int radius = Convert.ToInt32(size / 2);
                pm.btnHide.CornerRadius = radius;
                pm.TranslationY = radius;
            });

        public double ButtonSize
        {
            get { return (double)GetValue(ButtonSizeProperty); }
            set { SetValue(ButtonSizeProperty, value); }
        }

        public static readonly BindableProperty ImagePositionProperty = BindableProperty.Create("ImagePosition", typeof(ImageAnchor), typeof(PopupMessage), default(ImageAnchor),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                PopupMessage pm = bindable as PopupMessage;
                var anch = (ImageAnchor)newValue;

                if (anch == ImageAnchor.Right)
                {
                    pm.imgFrame.HorizontalOptions = LayoutOptions.End;
                    pm.imgFrame.Margin = new Thickness(35, -35);
                }
                else
                {
                    pm.imgFrame.HorizontalOptions = LayoutOptions.Start;
                    pm.imgFrame.Margin = new Thickness(35, -35);
                }
            });

        public ImageAnchor ImagePosition
        {
            get { return (ImageAnchor)GetValue(ImagePositionProperty); }
            set { SetValue(ImagePositionProperty, value); }
        }
        #endregion

        #region Show/Hide Animations
        private async void btnHide_Clicked(object sender, EventArgs e)
        {
            await HidePopup();
        }

        public async Task ShowPopup()
        {
            IsVisible = true;
            await this.FadeTo(1, 400);
        }

        public async Task HidePopup()
        {
            await this.FadeTo(0, 400);
            IsVisible = false;
        }
        #endregion
    }

    public enum ImageAnchor
    {
        Left, Right
    }
}