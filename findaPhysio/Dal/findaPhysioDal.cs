using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using findaPhysio.Models;
using Parse;
namespace findaPhysio.Dal
{
   public class findaPhysioDal
   {




       private async Task<ParseGeoPoint> GetPostCodeGeoPoints(string postcode)
       {
           //set default geopint to belfast

           ParseGeoPoint _geoPoint = new ParseGeoPoint(54.597443299999990000, -5.934068300000035000);

           var query = ParseObject.GetQuery("clinics");
           query.WhereContains("postcode", postcode);
           query = query.Limit(10);

           IEnumerable<ParseObject> result = new List<ParseObject>();


           result = await query.FirstAsync();
           var listItems = new List<Clinics>();


           foreach (var listItemParseObject in result)
           {
               var listItem = await Clinics.CreateFromParseObject(listItemParseObject);

               _geoPoint =new Parse.ParseGeoPoint(listItems[0]._Latitude,listItems[0]._Longitude);
            }

           return _geoPoint;

       }

        public async Task<List<Clinics>> GetClinicsByPostCodeAndDistance(string postcode)
        {
            try
            {


                ParseGeoPoint db = await GetPostCodeGeoPoints("CM21 9ET");

               var query = ParseObject.GetQuery("clinics");
                   query.WhereNear("locationgeo",db);
                   query = query.Limit(10);

            IEnumerable<ParseObject> result = new List<ParseObject>();


            result = await query.FindAsync();
            var listItems = new List<Clinics>();
          

            foreach (var listItemParseObject in result)
            {
                var listItem = await Clinics.CreateFromParseObject(listItemParseObject);
                listItems.Add(listItem);
            }


            return listItems;
         
              }

                
             catch(Exception ex)
            {

                return null;
            }

          
         
        

        }
    }
}
