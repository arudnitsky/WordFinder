﻿using System;
using System.Collections.Generic;
using System.IO;

namespace WordFinderEngine
{
   public class PointValueLookup
   {
      private static PointValueLookup _instance;
      private Dictionary<char, int> _dict;

      private PointValueLookup()
      {
         _dict = new Dictionary<char, int>();

         Initialize();
      }

      public static PointValueLookup Instance
      {
         get
         {
            return _instance ?? ( _instance = new PointValueLookup() );
         }
      }

      public int this[char key]
      {
         get
         {
            key = char.ToUpper( key );
            return _dict[key];
         }
      }

      private void Initialize()
      {
         _dict = new Dictionary<char, int>()
            {
               {'*', 0},
               {'A', 1},
               {'B', 4},
               {'C', 4},
               {'D', 2},
               {'E', 1},
               {'F', 4},
               {'G', 3},
               {'H', 3},
               {'I', 1},
               {'J', 10},
               {'K', 5},
               {'L', 2},
               {'M', 4},
               {'N', 2},
               {'O', 1},
               {'P', 4},
               {'Q', 10},
               {'R', 1},
               {'S', 1},
               {'T', 1},
               {'U', 2},
               {'V', 5},
               {'W', 4},
               {'X', 8},
               {'Y', 3},
               {'Z', 10}
            };
      }
   }
}