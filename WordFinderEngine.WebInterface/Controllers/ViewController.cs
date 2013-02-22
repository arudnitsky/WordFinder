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
          if( letters == null ) return PartialView( new List<string>() );

          var engine = new Engine();
          var words = engine.FindWords( new List<char>( letters ) );
          words.Sort( new LengthComparer() );
          return PartialView( words );
       }

    }

    public class LengthComparer : IComparer<string>
    {
       public int Compare( string x, string y )
       {
          // Handle nulls
          if ( x == null && y == null )
             return 0;
          if ( x == null )
             return -1;
          if ( y == null )
             return 1;

          // Handle different lengths
          if ( x.Length > y.Length )
             return 1;

          if ( y.Length > x.Length )
             return -1;

          // Handle same length
          return x.CompareTo( y );
       }
    }
}
