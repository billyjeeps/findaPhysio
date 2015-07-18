﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace findaPhysio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

           
            DrawerLayout.InitializeDrawerLayout(); //Intialize drawer  
            string[] menuItems = new string[5] { "About Us", "Contact", "Search", "How To", "Physiotherapists" };
            ListMenuItems.ItemsSource = menuItems.ToList();  //Set Menu list  
            this.NavigationCacheMode = NavigationCacheMode.Required;  

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
                DetailsTxtBlck.Text = "SelectedItem is: " + selecteditem;


                if (selecteditem=="Search")
                {

                    DrawerLayout.CloseDrawer();
                    Frame.Navigate(typeof(findaPhysioSearch));
                }
                

                ListMenuItems.SelectedItem = null;
            }
        } 

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
