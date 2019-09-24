using PopCorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PopCorn.Models.DAL;
namespace PopCorn.Controllers
{
    public class FilmController : Controller
    {
        private DataBaseContext _db = new DataBaseContext();
        // GET: Film
        public ActionResult Index()
        {

            return View();
        }

        public async Task<PartialViewResult> SearchAsync( string activity)
        {
            const string apiKey = "&apikey=13ba01ba";
            var ss = activity;
            var r = await BOXOFFICE.analyze("http://www.omdbapi.com/?t=" + ss + apiKey);
            var item = new FilmAttributes();

            item.Title = r.Title;
            item.Genre = r.Genre;
            item.Type = r.Type;
            item.Actors = r.Actors;
            item.totalSeasons = r.totalSeasons;

            item.imdbRating = r.imdbRating;
            item.imdbVotes = r.imdbVotes;
            item.Year = r.Year;
            item.Awards = r.Awards;
             item.Poster = r.Poster;
 
            item.Plot = r.Plot;

            item.imdbID = r.imdbID;
            if (item.Title == null)
            {
                item.Title = "Sorry Wirte Correct Name";
            }

            return PartialView ("Detalis",item);
        }

        [HttpGet]
        public ActionResult Messages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Messages(string Name , string Messages)
        {

            Messages newMessage = new Messages();
            newMessage.Name = Name;
            newMessage.Messaage = Messages;
            _db.Messages.Add(newMessage);
            _db.SaveChanges();

            return RedirectToAction("Messages");
        }
    }
}