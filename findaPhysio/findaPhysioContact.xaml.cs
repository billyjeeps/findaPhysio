using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace findaPhysio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class findaPhysioContact : Page
    {
        public findaPhysioContact()
        {
            this.InitializeComponent();

            DrawerLayout.InitializeDrawerLayout(); //Intialize drawer  
            string[] menuItems = new string[11] { "Home","About Us", "Contact", "Search", "How FindaPhysio Works", "Physiotherapists", "Aritcle Of Week", "Blog Of Week", "Podcast Of Week", "Jobs", "Courses" };
            ListMenuItems.ItemsSource = menuItems.ToList();  //Set Menu list  
     
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void txtemail2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            EmailRecipient sendTo = new EmailRecipient()
            {
                Address = "fapapp@find-a-physio.co.uk"
            };

            //generate mail object
            EmailMessage mail = new EmailMessage();
            mail.Subject = "Feedback";

            //add recipients to the mail object
            mail.To.Add(sendTo);
            //mail.Bcc.Add(sendTo);
            //mail.CC.Add(sendTo);

            //open the share contract with Mail only:
            await EmailManager.ShowComposeNewEmailAsync(mail);
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


    }
}
