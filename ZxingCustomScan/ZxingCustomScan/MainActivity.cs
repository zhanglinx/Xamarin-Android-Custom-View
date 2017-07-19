using Android.App;
using Android.Widget;
using Android.OS;
using ZXing.Mobile;
using Android.Views;

namespace ZxingCustomScan
{
    [Activity(Label = "ZxingCustomScan", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private TextView title_bar_title;
        private Button title_bar_left_btn;
        private Button title_bar_right_btn;
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            //title_bar_left_btn = FindViewById<TextView>(Resource.Id);
            //btn_scan = FindViewById<Button>(Resource.Id.btn_scan);
            //tv_value = FindViewById<TextView>(Resource.Id.tv_value);

            //MobileBarcodeScanner.Initialize(Application);
            //View view = LayoutInflater.From(this).Inflate(Resource.Layout.zxing_qrcode_capture_layout, null);
            //btn_scan.Click += async (s, e) =>
            //{
            //    MobileBarcodeScanner scan = new MobileBarcodeScanner();
            //    scan.CustomOverlay = view;
            //    var result = await scan.Scan();
            //    if (!string.IsNullOrEmpty(result.Text))
            //    {
            //        tv_value.Text = result.Text;
            //    }
            //};
        }
    }
}

