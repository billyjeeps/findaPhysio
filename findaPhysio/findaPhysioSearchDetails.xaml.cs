using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using findaPhysio.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace findaPhysio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class findaPhysioSearchDetails : Page
    {

        public Clinics _myClinic;
        public findaPhysioSearchDetails()
        {
            this.InitializeComponent();
            MyMap.MapServiceToken = "AkaRVlcfNdzPJWi3QI3iQOr_mcDepgQZutsQn-rPDa8lpe-Bs-9yV5E9dHpOBDb9";
            DrawerLayout.InitializeDrawerLayout(); //Intialize drawer       


            string[] menuItems = new string[11] { "Home", "About Us", "Contact", "Search", "How FindaPhysio Works", "Physiotherapists", "Aritcle Of Week", "Blog Of Week", "Podcast Of Week", "Jobs", "Courses" }; ListMenuItems.ItemsSource = menuItems.ToList();  //Set Menu list  
      
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                _myClinic = e.Parameter as Clinics;
                MyMap.SetView(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = _myClinic._Latitude, Longitude = _myClinic._Longitude }, 10);
                txtName.Text = _myClinic._Name.ToString();
                txtAddress.Text = _myClinic._Address1.ToString();
                txtTelephone.Text = _myClinic._Telephone.ToString();
                txtTown.Text = _myClinic._Town.ToString();
                txtWeb.Text = _myClinic._WebSite.ToString();
                txttxtSpeciality.Text = _myClinic._Speciaity.ToString();

            
            }
            catch (Exception ex)
            {


            }

        }

        private void DrawerIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (DrawerLayout.IsDrawerOpen)
                DrawerLayout.CloseDrawer();//Close drawer  
            else
                DrawerLayout.OpenDrawer();//Open drawer  
        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListMenuItems.SelectedItem != null)
            {
                //Get selected favorites item value  
                var selecteditem = ListMenuItems.SelectedValue as string;
              

                if (selecteditem == "Search")
                {

                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(findaPhysioSearch));
                }
                if (selecteditem == "Contact")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(findaPhysioContact));

                }

                if (selecteditem == "How FindaPhysio Works")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(findaPhysioHowWorks));

                }

                if (selecteditem == "Home")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(MainPage));

                }

                if (selecteditem == "About Us")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(findaPhysioAbout), "http://members.find-a-physio.co.uk/physiotherapists/");

                }



                if (selecteditem == "Physiotherapists")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(webView), "http://members.find-a-physio.co.uk/physiotherapists/");

                }


                if (selecteditem == "Aritcle Of Week")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(webView), "http://members.find-a-physio.co.uk/category/article-of-the-week/");

                }
                if (selecteditem == "Blog Of Week")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(webView), "http://members.find-a-physio.co.uk/category/blog-of-the-week/");

                }
                if (selecteditem == "Podcast Of Week")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(webView), "http://members.find-a-physio.co.uk/category/podcast-of-the-week/");

                }
                if (selecteditem == "Jobs")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(webView), "http://members.find-a-physio.co.uk/jobs/");

                }
                if (selecteditem == "Courses")
                {
                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(webView), "");

                }
                ListMenuItems.SelectedItem = null;
            }
        } 

        private void txtTelephone_Tapped(object sender, TappedRoutedEventArgs e)
        {


            Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(_myClinic._Telephone, _myClinic._Name);

        }

        private void btnBookNow_Tapped(object sender, TappedRoutedEventArgs e)
        {



            string uri = _myClinic._BookUrl;
            Uri _url;
            if (uri == null)
            {


                _url = new Uri("http://www.find-a-physio.co.uk/Home/online-booking");


            }
            else
                _url = new Uri(_myClinic._BookUrl);





            Frame.Navigate(typeof(webView), _url);
        }

        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            MyMap.AddPushpin(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = _myClinic._Latitude, Longitude = _myClinic._Longitude }, "1");
        
        
        }
    }
}
