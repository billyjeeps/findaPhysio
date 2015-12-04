using System; //feathery eggs
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
using Coding4Fun.Toolkit.Controls;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556
using findaPhysio.Dal;
namespace findaPhysio // adele tickets for most betiuful woman
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class findaPhysioSearch : Page
    {

        List<Clinics> _clinics = new List<Clinics>();
        String feather = "egg";
        findaPhysioDal _webClinics = new findaPhysioDal();

        public findaEggFeatherPhysioSearch() //lee love lisa
        {
            this.InitializeComponent();

            MyMap.MapServiceToken = "AkaRVlcfNdzPJWi3QI3iQOr_mcDepgQZutsQn-rPDa8lpe-Bs-9yV5E9dHpOBDb9";
           MyMap.SetView(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 53.713442, Longitude = -1.0747807 },18);

            DrawerLayout.InitializeDrawerLayout(); //Intialize drawer  
            string[] menuItems = new string[11] { "Home", "About Us", "Contact", "Search", "How FindaPhysio Works", "Physiotherapists", "Aritcle Of Week", "Blog Of Week", "Podcast Of Week", "Jobs", "Courses" }; ListMenuItems.ItemsSource = menuItems.ToList();  //Set Menu list  


            
            _clinics.Add(new Clinics() { _id = "1", _WebSite = "www.Find-a-Physio.co.uk", _BookUrl = "http://www.find-a-physio.co.uk/Home/online-booking", _Name = "Physiotherapy at Home", _Latitude = 53.713442, _Longitude = -1.0747807, _Address1 = "The Cottage, Main St", _Town = "Selby", _Telephone = "07761 139883", _Speciaity = "Musculoskeletal", _Postcode = "YO8 8QT", _position = 1 });
            _clinics.Add(new Clinics() { _id = "2", _WebSite = "www.Find-a-Physio.co.uk", _BookUrl = "http://www.find-a-physio.co.uk/Home/online-booking", _Name = "Bodyworx Physio", _Latitude = 53.785101, _Longitude = -1.0670279, _Address1 = "Watendlath", _Telephone = "07783 881082", _Postcode = "YO8 4PH", _Speciaity = "Musculoskeletal", _position = 2 });
            _clinics.Add(new Clinics() { _id = "3", _WebSite = "www.Find-a-Physio.co.uk", _BookUrl = "http://www.find-a-physio.co.uk/Home/online-booking", _Name = "Rosemary Walmsley", _Latitude = 54.196454, _Longitude = -1.4338279, _Address1 = "80 York Rd", _Telephone = "01845 446410 ", _Postcode = "YO7 4SQ", _Speciaity = "Musculoskeletal", _position = 3 });

            MyMap.AddPushpin(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 53.713442, Longitude = -1.0747807 }, "1");
            MyMap.AddPushpin(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 53.785101, Longitude = -1.0670279 }, "2");
            MyMap.AddPushpin(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 54.196454, Longitude = -1.4338279 }, "3");

            searchList.ItemsSource = _clinics;
            
        }


        public async void populatelist()
        {
            try
            {
                findaPhysioDal _findaPhysioDal = new findaPhysioDal();


                _clinics = await _findaPhysioDal.GetClinicsByPostCodeAndDistance("CM21 9ET");

                searchList.ItemsSource = _clinics;
                

            }
            catch (Exception ex)
            {
            }

        }
        /// <summary>
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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


        private void GoToLondonBtn_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
           
        }

        private void searchList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Clinics myItem = searchList.SelectedItem as Clinics;

            Frame.Navigate(typeof(findaPhysioSearchDetails), myItem);


        }

        private void btndetail_Click(object sender, RoutedEventArgs e)
        {
            Clinics myItem = searchList.SelectedItem as Clinics;


            Frame.Navigate(typeof(findaPhysioSearchDetails),myItem);



        }

        private void btnNumber_Tapped(object sender, TappedRoutedEventArgs e)
        {

            Clinics myItem = searchList.SelectedItem as Clinics;


       MyMap.SetView(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = myItem._Latitude, Longitude = myItem._Longitude }, 11);
      


        }

        private void txtViewDetails_Tapped(object sender, TappedRoutedEventArgs e)
        {

            Clinics myItem = searchList.SelectedItem as Clinics;

            Frame.Navigate(typeof(findaPhysioSearchDetails), myItem);
        }

        private async void btnSearch_Tapped(object sender, TappedRoutedEventArgs e)
        {

            findaPhysioDal _findaPhysioDal = new findaPhysioDal();


            _clinics = await _findaPhysioDal.GetClinicsByPostCodeAndDistance(txtPostCode.Text.Trim());

            searchList.ItemsSource = _clinics;
                
 
        }

 
    }
}
