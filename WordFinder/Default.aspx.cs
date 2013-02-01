using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WordFinderEngine;

namespace WordFinder
{
   public partial class Default : System.Web.UI.Page
   {
      private readonly Engine _engine = new Engine();

      protected void Page_Load( object sender, EventArgs e )
      {
      }

      protected void Go_Click( object sender, EventArgs e )
      {
         var result = _engine.FindWords( Letters.Text.ToCharArray().ToList() );
         result.Sort();
         FoundWords.Text = string.Join( ", ", result);
      }
   }
}