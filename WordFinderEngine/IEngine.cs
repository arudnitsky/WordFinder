using System.Collections.Generic;

namespace WordFinderEngine
{
   public interface IEngine
   {
      void SetDictionary( List<string> dictionary );
      IEnumerable<string> FindWords( IEnumerable<char> letters );
   }
}