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
using GeneratorPortableLibrary.DTO;

namespace PowerBallGenerator
{
    public class MyCustomListAdapter : BaseAdapter<PowerBall>
    {
        private List<PowerBall> mItems;
        private Context mContext;
        public MyCustomListAdapter(Context context ,List<PowerBall> items)
        {
            mItems = items;
            mContext = context;
        }
        public override PowerBall this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override int Count
        {
            get
            {
              return  mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if(row==null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_layout_results, null, false);
            }

            TextView firstNo = row.FindViewById<TextView>(Resource.Id.firstNumber);
            firstNo.Text = mItems[position].FirstNumber.ToString()+", ";

            TextView secondNo = row.FindViewById<TextView>(Resource.Id.secondNumber);
            secondNo.Text = mItems[position].SecondNumber.ToString() + ", ";

            TextView thirdNo = row.FindViewById<TextView>(Resource.Id.thirdNumber);
            thirdNo.Text = mItems[position].ThirdNumber.ToString() + ", ";

            

            TextView fourthNo = row.FindViewById<TextView>(Resource.Id.fourthNumber);
            fourthNo.Text = mItems[position].FourthNumber.ToString() + ", ";

            TextView fifthNo = row.FindViewById<TextView>(Resource.Id.fifthNumber);
            fifthNo.Text = mItems[position].FirstNumber.ToString() + ", ";

            TextView powerNo = row.FindViewById<TextView>(Resource.Id.powerNumber);
            powerNo.Text = mItems[position].PowerNumber.ToString() ;

            return row;
        }

        public void ClearData()
        {
            mItems.Clear();
        }
    }
}