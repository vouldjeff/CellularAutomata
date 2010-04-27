using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CellularAutomata.Framework
{
    public static class CAManager
    {
        private const string defaultPatternFile = "patterns.xml";

        private static PatternCollection _patterns;

        public static PatternCollection Patterns
        {
            get
            {
                if (_patterns == null)
                {
                    _patterns = LoadPatterns(defaultPatternFile);
                }

                return _patterns;
            }
        }


        public static PatternCollection LoadPatterns(string fileName)
        {
            throw new NotImplementedException();
        }

        public static void SavePatterns(string fileName)
        {
            throw new NotImplementedException();
        }

        public static void SavePatterns(PatternCollection patterns, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}