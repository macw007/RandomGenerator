using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Util;
using GeneratorPortableLibrary.DTO;
using System.Collections.Generic;
using GeneratorPortableLibrary;
using Java.Lang;

namespace PowerBallGenerator
{
    [Activity(Label = "PowerBallGenerator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
       
        private ProgressDialog m_ProgressDialog = null;
        private GenerateRandomNumber rand = null;
        private ListView mList;
        private MyCustomListAdapter adapter;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            configView();

        }
        private void configView()
        {
           
            SetContentView(Resource.Layout.Main);
            rand = new GenerateRandomNumber();
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            EditText count = FindViewById<EditText>(Resource.Id.selected_count);
            try
            {


                mList = FindViewById<ListView>(Resource.Id.listViewResultd);

                button.Click += delegate {
                    var counter = Convert.ToInt32(count.Text);

                    if (adapter != null)
                        adapter.ClearData();
                     adapter = new MyCustomListAdapter(this, rand.GenerateList(counter));
                    
                    mList.Adapter = adapter;
                };
            }
            catch (Java.Lang.Exception ex)
            {

            }
        }
    }
}

