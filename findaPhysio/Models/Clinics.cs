using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.Devices.Geolocation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Parse;
namespace findaPhysio.Models
{
    public class Clinics : INotifyPropertyChanged
    {

        public Clinics()
        {

        }
 

            public string _id { get;  set; }
            public int _position { get; set; }


         public string _BookUrl { get; set; }

         public string _OpeningHours { get; set; }

       
         public string _WebSite { get; set; }


         public string _Speciaity { get; set; }
        
        public string _Name { get;  set; }
        public string _Address1 { get;  set; }

        public string _Address2 { get; set; }
        public string _Telephone{ get;  set; }
        public string _Town { get; set; }


        public string _Postcode { get;  set; }

        public double _Latitude { get; set; }

        public double _Longitude { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;



        public static async Task<Clinics> CreateFromParseObject(ParseObject parseObject)
        {
            return await Task.Run<Clinics>(() =>
            {
                var findaPhysioList = new Clinics();

                findaPhysioList._Name = parseObject.ObjectId;
                if (parseObject.ContainsKey("BookURL"))
                {
                    findaPhysioList._Name = (string)parseObject["BookURL"];
                }

                
                if (parseObject.ContainsKey("OpeningHours"))
                {
                    findaPhysioList._OpeningHours = (string)parseObject["OpeningHours"];
                }

                if (parseObject.ContainsKey("Speciality"))
                {
                    findaPhysioList._Speciaity = (string)parseObject["Speciality"];
                }

                if (parseObject.ContainsKey("Town"))
                {
                    findaPhysioList._Town = (string)parseObject["Town"];
                }



                if (parseObject.ContainsKey("Website"))
                {
                    findaPhysioList._WebSite = (string)parseObject["Website"];
                }

                if (parseObject.ContainsKey("adress1"))
                {
                    findaPhysioList._Address1 = (string)parseObject["adress1"];
                }


              


                if (parseObject.ContainsKey("name"))
                {
                    findaPhysioList._Name = (string)parseObject["name"];
                }


                if (parseObject.ContainsKey("postcode"))
                {
                    findaPhysioList._Postcode = (string)parseObject["postcode"];
                }

                if (parseObject.ContainsKey("telephone"))
                {
                    findaPhysioList._Telephone = (string)parseObject["telephone"];
                }


                if (parseObject.ContainsKey("lat"))
                {
                    findaPhysioList._Latitude = (double)parseObject["lat"];
                }


                if (parseObject.ContainsKey("long"))
                {
                    findaPhysioList._Longitude = (double)parseObject["long"];
                }
                return findaPhysioList;
            });
        }
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
