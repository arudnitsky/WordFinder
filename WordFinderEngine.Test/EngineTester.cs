using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordFinderEngine.Test
{
   [TestClass]
   public class EngineTester
   {
      private readonly List<string> _dictionary;
      private readonly Engine _engine;

      public EngineTester()
      {
         _dictionary = new List<string>();
         _dictionary.Add( "CAT" );
         _dictionary.Add( "BAD" );  
         _dictionary.Add( "CAD" );  
         _dictionary.Add( "ADC" );  
         _dictionary.Add( "COOT" );
         _dictionary.Add( "DOG" );
         _dictionary.Add( "LLL" );  

         _engine = new Engine( _dictionary );
         //_engine = new Engine();
      }

      [TestMethod]
      public void FindWords_AllLettersInWord_ReturnsWord()
      {
         var letters = new List<char> { 'a', 'b', 'c', 'd', 't' };

         var result = _engine.FindWords( letters );
         Assert.AreEqual( 4, result.Count );
      }

      [TestMethod]
      public void FindWords_NotAllLettersInWord_ReturnsNoWords()
      {
         var letters = new List<char> { 'a', 'b', 'c' };

         var result = _engine.FindWords( letters );
         Assert.AreEqual( 0, result.Count );
     }

      [TestMethod]
      public void FindWords_AllLettersInWordWithDuplicateLetters_ReturnsNoWords()
      {
         var letters = new List<char> { 'c', 'o', 't' };

         var result = _engine.FindWords( letters );
         Assert.AreEqual( 0, result.Count );
     }

      [TestMethod]
      public void FindWords_LettersMissingButHasWildcard1_ReturnsWords()
      {
         var letters = new List<char> { 'C', 'A', '*' };

         var result = _engine.FindWords( letters );
         Assert.AreEqual( 3, result.Count );
      }

      [TestMethod]
      public void FindWords_LetterMissingButHasWildcard2_ReturnsWords()
      {
         var letters = new List<char> { '*', 'A', 'D' };

         var result = _engine.FindWords( letters );
         Assert.AreEqual( 3, result.Count );
      }

      [TestMethod]
      public void FindWords_LetterListHasDuplicates_ReturnsNoWords()
      {
         var letters = new List<char> { 'A', 'T', 'A' };

         var result = _engine.FindWords( letters );
         Assert.AreEqual( 0, result.Count );
      }
   }
}
