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
using findaPhysio.Dal;
namespace findaPhysio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class findaPhysioSearch : Page
    {

        List<Clinics> _clinics = new List<Clinics>();

        public findaPhysioSearch()
        {
            this.InitializeComponent();
            MyMap.MapServiceToken = "AkaRVlcfNdzPJWi3QI3iQOr_mcDepgQZutsQn-rPDa8lpe-Bs-9yV5E9dHpOBDb9";
            MyMap.SetView(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 51.5, Longitude = -0.05 }, 11);

  

           // List<Clinics> _clinics = new List<Clinics>();
      
           // _clinics.Add(new Clinics() { _id = "1", _Name="Test Clinic 1" ,_Phone="(232) 232 323",_Postcode="SW1 T30",_position=1});
           // _clinics.Add(new Clinics() { _id = "2", _Name = "Test Clinic 2", _Phone = "(232) 232 323", _Postcode = "SW1 T30", _position = 2 });
           // _clinics.Add(new Clinics() { _id = "3", _Name = "Test Clinic 3", _Phone = "(232) 232 323", _Postcode = "SW1 T30", _position = 3 });

           //MyMap.AddPushpin(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 51.5, Longitude = -0.05 }, "1");
           // MyMap.AddPushpin(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 51.503399, Longitude = -0.119519 }, "2");
           //  MyMap.AddPushpin(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 51.5057, Longitude = -0.1419 }, "3");


            populatelist();

            
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

        }

        private void GoToLondonBtn_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
           
        }
    }
}
