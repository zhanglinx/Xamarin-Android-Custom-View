using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace CustomeTitleBar
{
    public class CustomEditText : EditText
    {
        private Drawable imgClear;
        private Context Context;
        public CustomEditText(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.Context = context;
            init();
        }
        private void init()
        {
            imgClear = Context.Resources.GetDrawable(Resource.Drawable.icon_white_arrow_left);
            AfterTextChanged += (s, e) =>
            {
                setDrawable();
            };
        }

        //»ØÖ´É¾³ýÍ¼Æ¬  
        private void setDrawable()
        {
            if (Length() < 1)
                SetCompoundDrawablesWithIntrinsicBounds(null, null, null, null);
            else
                SetCompoundDrawablesWithIntrinsicBounds(null, null, imgClear, null);
        }
        //µ±´¥Ãþ·¶Î§ÔÚÓÒ²àÊ±£¬´¥·¢É¾³ý·½·¨£¬Òþ²Ø²æ²æ  
        public override bool OnTouchEvent(MotionEvent e)
        {
            if (imgClear != null && e.Action == MotionEventActions.Up)
            {
                int eventX = (int)e.RawX;
                int eventY = (int)e.RawY;
                Rect rect = new Rect();
                GetGlobalVisibleRect(rect);
                rect.Left = rect.Right - 100;
                if (rect.Contains(eventX, eventY))
                {
                    Text = string.Empty;
                }
            }
            return base.OnTouchEvent(e);
        }
    }
}