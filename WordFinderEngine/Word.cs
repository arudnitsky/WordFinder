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

      private int GetPointValue( string word )
      {
         var pointValue = 0;
         foreach ( var c in word )
         {
            pointValue += PointValueLookup.Instance[ c ];
         }
         return pointValue;
      }

   }
}
