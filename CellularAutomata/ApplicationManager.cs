using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CellularAutomata.Framework;

namespace CellularAutomata
{
    public static class ApplicationManager
    {
        public static PatternCollection Patterns
        { 
            get; set;
        }

        public static void LoadMainForm()
        {
            Application.Run(new MainForm());
        }
        
        public static void LoadPatterns(string filePath)
        {
            Patterns = new PatternCollection();
            try
            {
                using (Stream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    StreamReader reader = new StreamReader(fileStream);
                    var xml = reader.ReadToEnd();
                    Patterns.BuildFromXml(xml);
                }
            }
            catch (FileNotFoundException)
            {
                //TODO: handle the exception
            }
        }
    }
}
