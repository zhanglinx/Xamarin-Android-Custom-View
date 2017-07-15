using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using static Android.Views.ViewGroup;
namespace customSpinnerDemo
{
    public  class SpinerPopWindow<T>:PopupWindow
    {
        private ListView listView;
        private List<T> list;
        private LVAdapter<T> adapter;
        private Context context;
        private LayoutInflater inflater;
        public SpinerPopWindow(Context _context ,List<T> _list, AdapterView.IOnItemClickListener itemClickListener)
        {
            context = _context;
            list = _list;
            inflater = LayoutInflater.From(_context);
            InitListView(itemClickListener);
        }
        private void InitListView(AdapterView.IOnItemClickListener itemClickListener)
        {
            View view = inflater.Inflate(Resource.Layout.spiner_window_layout, null);
            this.ContentView = view;
            //LayoutParams
            var parentView = (ViewGroup)view;
            var child  = parentView.GetChildAt(0);
            this.Width = LayoutParams.WrapContent;
            this.Height = LayoutParams.WrapContent;
            this.Focusable = true;
            ColorDrawable cdw = new ColorDrawable(Android.Graphics.Color.Transparent);
            SetBackgroundDrawable(cdw);
            //View childView = ContentView
            
            listView = view.FindViewById<ListView>(Resource.Id.listview);
            adapter = new customSpinnerDemo.LVAdapter<T>(context,list);
            listView.Adapter = adapter;
            listView.OnItemClickListener = itemClickListener;
        }
    }
    public class LVAdapter<T> : BaseAdapter
    {
        private List<T> list;
        private Context context;
        public LVAdapter(Context _context,List<T> _list)
        {
            context = _context;
            list = _list;
        }
        public override int Count
        {
            get{
                return list.Count();
            }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ViewHolder holder = null;
            if (convertView == null)
            {
                holder = new ViewHolder();
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.spiner_item_layout,parent,false);
                holder.tvName = convertView.FindViewById<TextView>(Resource.Id.tv_name);
                convertView.Tag = holder;
            }
            else
            {
                holder = (ViewHolder)convertView.Tag;
            }
            holder.tvName.Text = list[position].ToString();
            return convertView; 
        }
        private class ViewHolder:Java.Lang.Object {
            internal TextView tvName;
        }
    }
}