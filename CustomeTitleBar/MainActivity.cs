using Android.App;
using Android.Widget;
using Android.OS;
using static Android.Views.View;
using Android.Views;
using System;
using Android.Support.V7.App;

namespace CustomeTitleBar
{
    [Activity(Label = "CustomeTitleBar", MainLauncher = true, Icon = "@drawable/icon",Theme = "@style/AppBaseTheme")]
    public class MainActivity : AppCompatActivity
    {
        private TextView title_bar_title;
        private Button title_bar_left_btn;
        private Button title_bar_right_btn;
        protected override void OnCreate(Bundle bundle)
        {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.Main);
                MyTitleBar myTitleBar = (MyTitleBar)FindViewById(Resource.Id.myTitleBar);
                myTitleBar.GetTitleBarLeftBtn().Click += (s, e) =>
                {
                    Toast.MakeText(this, "单击了左边按钮", ToastLength.Short).Show();
                };
                myTitleBar.GetTitleRightBtn().Click += (s, e) =>
                {
                    Toast.MakeText(this, "单击了右边按钮", ToastLength.Short).Show();
                };
            }
        }
}


