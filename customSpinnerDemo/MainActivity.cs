using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using static Android.Widget.AdapterView;
using Android.Views;
using Android.Graphics.Drawables;
using Android.Support.V7.App;
namespace customSpinnerDemo
{
    [Activity(Label = "customSpinnerDemo", MainLauncher = true, Icon = "@drawable/icon",Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, IOnItemClickListener, PopupWindow.IOnDismissListener
    {
        private List<string> list;
        private TextView tv_value;
        private SpinerPopWindow<string> SpinnerPopwindow;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            tv_value = FindViewById<TextView>(Resource.Id.tv_value);
            tv_value.Click += (s,e) =>
            {
                SpinnerPopwindow.Width = tv_value.Width;
                SpinnerPopwindow.ShowAsDropDown(tv_value);
                SetTextImage(Resource.Drawable.icon_up);
            };
            list = new List<string>() { "科比","詹姆斯","韦德","波什"};
            SpinnerPopwindow = new SpinerPopWindow<string>(this,list,this);
            SpinnerPopwindow.SetOnDismissListener(this);
        }
        /// <summary>
        /// 给TextView右边设置图片
        /// </summary>
        private void SetTextImage(int resId)
        {
            //var drawable =GetDrawable(resId);
            Drawable drawable = Resources.GetDrawable(resId);
            drawable.SetBounds(0,0,drawable.MinimumWidth,drawable.MinimumHeight);
            tv_value.SetCompoundDrawables(null,null,drawable,null);
        }
        /// <summary>
        /// popupWindow 显示的ListView的item点击事件
        /// </summary>
        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            SpinnerPopwindow.Dismiss();
            tv_value.Text=list[position].ToString();
            Toast.MakeText(this,"点击了:"+list[position],ToastLength.Long).Show();
        }
        /// <summary>
        /// popupWindow取消
        /// </summary>
        public void OnDismiss()
        {
            SetTextImage(Resource.Drawable.icon_down);
        }
    }
}

