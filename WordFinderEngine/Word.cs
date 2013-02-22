using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinderEngine
{
   public class Word 
   {
      public string Text { get; private set; }
      public int PointValue { get; private set; }

      public Word( string word )
      {
         Text = word;
         PointValue = GetPointValue( word );
      }

      private static int GetPointValue( string word )
      {
         return word.Sum( c => PointValueLookup.Instance[ c ] );
      }

      public override string ToString()
      {
         return string.Format( "{0} ( {1} )", Text, PointValue );
      }

      public class ScoreComparer : IComparer<Word>
      {
         public int Compare( Word x, Word y )
         {
            if ( x.PointValue > y.PointValue )
            {
               return 1;
            }

            else if ( x.PointValue < y.PointValue )
            {
               return -1;
            }

            else
            {
               return 1;
            }
         }
      }

      public class LengthComparer : IComparer<Word>
      {
         public int Compare( Word x, Word y )
         {
            // Handle nulls
            if ( x == null && y == null )
               return 0;
            if ( x == null )
               return -1;
            if ( y == null )
               return 1;

            // Handle different lengths
            if ( x.Text.Length > y.Text.Length )
               return 1;

            if ( y.Text.Length > x.Text.Length )
               return -1;

            // Handle same length
            return String.Compare(x.Text, y.Text, StringComparison.Ordinal);
         }
      }

   }
}
