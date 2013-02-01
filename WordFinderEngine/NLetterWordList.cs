using System;
using System.Collections;
using System.Collections.Generic;

namespace WordFinderEngine
{
   public class NLetterWordList : IEnumerable<string>
   {
      public int WordLength { get; private set; }
      private readonly List<string> _wordlist;

      public NLetterWordList( int wordLength )
      {
         WordLength = wordLength;
         _wordlist = new List<string>();
      }

      public void Add( string word )
      {
         if ( word.Length != WordLength )
            throw new ArgumentException( "Incorrect word length" );

         _wordlist.Add( word );
         _wordlist.Sort();
      }

      public IEnumerator<string> GetEnumerator()
      {
         return ( (IEnumerable<string>) _wordlist ).GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
   }
}
