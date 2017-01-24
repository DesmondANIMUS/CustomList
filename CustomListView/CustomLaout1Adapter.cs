using System.Collections.Generic;


using Android.Views;
using Android.Widget;
using Android.Content;

namespace CustomListView
{
    class CustomLaout1Adapter : BaseAdapter<Person>
    {
        List<Person> mList;
        Context mCon;
        
        public CustomLaout1Adapter(Context Con, List<Person> list)
        {
            mCon = Con;
            mList = list;
        }

        public override int Count => mList.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Person this[int position] => mList[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
                row = LayoutInflater.From(mCon).Inflate(Resource.Layout.CustomLayout1, null, false);

            TextView firstNameView = row.FindViewById<TextView>(Resource.Id.firstName);
            firstNameView.Text = mList[position].FirstName;

            TextView lastNameView = row.FindViewById<TextView>(Resource.Id.lasName);
            lastNameView.Text = mList[position].LastName;

            TextView ageView = row.FindViewById<TextView>(Resource.Id.age);
            ageView.Text = mList[position].Age;

            TextView genderView = row.FindViewById<TextView>(Resource.Id.gender);
            genderView.Text = mList[position].Gender;

            return row;
        }
    }
}