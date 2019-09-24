using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;

namespace PopCorn.Models
{
    public class BOXOFFICE
    {

        public static async Task<FilmAttributes> analyze(string uri)
        {
              using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(uri))
                using (HttpContent content = response.Content)
                {
                    var mycontent = await content.ReadAsStringAsync();

                    var items = JsonConvert.SerializeObject(mycontent);
                    var array = JsonConvert.DeserializeObject<FilmAttributes>(mycontent);
                    //if (array.imdbRating == null)
                    //{
                    //    return (array);
                    //}

                    return (array);
                    //return ("Title: " + array.Title + " (" + array.Year + ")" + "\n" + "Type: " + array.Genre + "\n" + "Rating: " + array.imdbRating + "\n" + "imdbVotes: " + array.imdbVotes + "\n" + "Awards: " + array.Awards).ToString();
                }
            }
        }

    }


}