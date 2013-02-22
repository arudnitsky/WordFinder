using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WordFinderEngine.WebInterface.Controllers
{
    public class ViewController : Controller
    {

       public ActionResult Index()
       {
           return View();
       }

       public PartialViewResult GetWords( string letters )
       {
          if( letters == null ) return PartialView( new List<Word>() );

          var engine = new Engine();
          var words = engine.FindWords( new List<char> ( letters ) );
          words.Sort( new Word.ScoreComparer() );
          words.Reverse();
          return PartialView( words );
       }

    }
}
