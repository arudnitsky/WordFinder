using System;
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

      #region FindWords

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

      [TestMethod]
      public void FindWords_LetterListHasDuplicates_ReturnsWords()
      {
         var letters = new List<char> { 'A', 'T', 'A', 'C', 'C' };

         var result = _engine.FindWords( letters );
         Assert.AreEqual( 1, result.Count );
      }

      #endregion

      #region NLetterWordList

      [TestMethod]
      public void NLetterWordList_Constructor_InitializedProperly()
      {
         var wordlist = new NLetterWordList( 3 );
         Assert.AreEqual( 3, wordlist.WordLength );
      }

      [TestMethod]
      public void NLetterWordList_Add_ReturnsSortedWords()
      {
         var wordlist = new NLetterWordList( 3 );
         wordlist.Add( "dog" );
         wordlist.Add( "hat" );
         wordlist.Add( "cat" );

         var actual = new List<string>();
         foreach ( var word in wordlist )
         {
            actual.Add( word );
         }
         Assert.AreEqual( 3, actual.Count );
         Assert.IsTrue( actual[0] == "cat" );
         Assert.IsTrue( actual[1] == "dog" );
         Assert.IsTrue( actual[2] == "hat" );
      }

      [TestMethod, ExpectedException( typeof( ArgumentException ) )]
      public void NLetterWordList_AddingWrongLengthWord_Throws()
      {
         var wordlist = new NLetterWordList( 3 );
         wordlist.Add( "grass" );
      }
      #endregion
   }
}
