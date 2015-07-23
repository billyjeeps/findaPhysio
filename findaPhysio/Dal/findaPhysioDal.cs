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


 

        public async Task<List<Clinics>> GetClinicsByPostCodeAndDistance(string  postcode)
        {



           
               var query = ParseObject.GetQuery("clinics");
               query = query.WhereContains("postcode", postcode);
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
    }
}
