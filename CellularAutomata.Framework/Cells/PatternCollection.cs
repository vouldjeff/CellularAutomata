using System;
using System.Xml.Linq;
using CellularAutomata.Framework.Common;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Represents a collection of <see cref="Pattern"/>.
    /// The key is the <see cref="Pattern.Name"/> of the pattern.
    /// </summary>
    [Serializable]
    public class PatternCollection : KeyedValueListBase<string, Pattern>, IXmlBuildable
    {
        /// <summary>
        /// Used from the underlaying to know how to get the key from an element.
        /// </summary>
        /// <param name="element">The element, whose key is returned.</param>
        /// <returns>The key itself.</returns>
        protected override string GetKey(Pattern element)
        {
            return element.Name;
        }

        #region IXmlBuildable Members

        public string GetXml()
        {
            var doc = new XDocument();
            return GetXml(doc);
        }

        public string GetXml(XDocument document)
        {
            XElement patternsElement = GetXElement();
            document.Add(patternsElement);
            return document.ToString();
        }

        public void BuildFromXml(string xml)
        {
            XDocument document = Utilities.ParseXml(xml);
            if (document != null)
            {
                XElement pattternsElement = document.Element("Patterns");
                BuildFromXml(pattternsElement);
            }
        }

        public void BuildFromXml(XElement element)
        {
            foreach (XElement patternElement in element.Elements("Pattern"))
            {
                var pattern = new Pattern();
                pattern.BuildFromXml(patternElement);
                Add(pattern);
            }
        }


        public XElement GetXElement()
        {
            var patternsElements = new XElement("Patterns");

            foreach (Pattern pattern in this)
            {
                var element = pattern.GetXElement();
                patternsElements.Add(element);
            }

            return patternsElements;
        }

        #endregion
    }
}