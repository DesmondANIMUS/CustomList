using Android.OS;
using Android.App;
using Android.Widget;
using System.Collections.Generic;

namespace CustomListView
{
    [Activity(Label = "CustomListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<Person> list1;
        ListView dataList;
        CustomLaout1Adapter adapt;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            list1 = new List<Person>();
            dataList = FindViewById<ListView>(Resource.Id.listView1);

            list1.Add(new Person { FirstName = "Hakase", LastName = "Shinonome", Age = "7", Gender = "Female" });
            list1.Add(new Person { FirstName = "Sakamoto", LastName = "Shinonome", Age = "20", Gender = "Male" });
            list1.Add(new Person { FirstName = "Nano", LastName = "Shinonome", Age = "1", Gender = "Female" });
            list1.Add(new Person { FirstName = "Aioi", LastName = "Yuuko", Age = "16", Gender = "Female" });

            adapt = new CustomLaout1Adapter(this, list1);

            dataList.Adapter = adapt;            

            dataList.ItemClick += DataList_ItemClick;   // Subscribing to that event
            dataList.ItemClick += DataList_ItemClick1;
            //you can subscribe to multiple methods

            //dataList.ItemClick -= DataList_ItemClick; // And this is how you unsubscribe to an event
        }

        private void DataList_ItemClick1(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, list1[e.Position].LastName, ToastLength.Short).Show();
        }

        private void DataList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // Getting data from the list here, NOT the listview
            if (list1[e.Position].FirstName.Equals("Aioi"))
                Toast.MakeText(this, "Test Complete", ToastLength.Short).Show();
            else
                Toast.MakeText(this, list1[e.Position].FirstName, ToastLength.Short).Show();
        }
    }
}