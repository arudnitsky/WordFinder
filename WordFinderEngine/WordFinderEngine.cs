using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WordFinderEngine
{
   public class Engine
   {
      private List<string> _dictionary;
      
      public Engine()
      {
         var dictionaryAsString = global::WordFinderEngine.Properties.Resources.DefaultDictionary;
         _dictionary = new List<string>( dictionaryAsString.Split( new char[] { '\r', '\n', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries ) );
      }

      public Engine( List<string> dictionary )
      {
         _dictionary = dictionary;
      }

      public void SetDictionary( List<string> dictionary )
      {
         _dictionary = dictionary;
      }

      public List<string> FindWords( List<char> letters )
      {
         var wordList = _dictionary.Where( word => CanCreateWordFromLetters( word, letters ) ).ToList();

         return wordList;
      }

      private static bool CanCreateWordFromLetters( string word, List<char> letters )
      {
         var lettersMatched = 0;
         foreach ( var character in letters )
         {
            var letter = Char.ToUpper( character );
            if ( letter == '*' )
            {
               ++lettersMatched;
            }
            else
            {
               int index = word.IndexOf( letter );
               if ( index != -1 )
               {
                  int length = word.Length;
                  ++lettersMatched;
                  
                  if ( index == 0 )
                  {
                     word = "-" +  word.Substring( index + 1 );
                  }
                  else if ( index == length - 1 )
                  {
                     word = word.Substring( 0, length - 1 ) + "-";
                  }
                  else
                  {
                     string left = word.Substring( 0, index );
                     string right = word.Substring( index + 1 );
                     word = left + "-" + right;
                  }
               }
            }


            if ( lettersMatched == word.Length )
               return true;
         }

         return false;
      }
   }
}