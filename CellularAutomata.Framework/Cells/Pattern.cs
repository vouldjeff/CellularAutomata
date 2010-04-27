using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Represents a Cellular Automata pattern, defined with a <see cref="CellCollection"/>.
    /// </summary>
    [Serializable]
    public class Pattern : IXmlBuildable
    {
        /// <summary>
        /// The name of the pattern.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A brief description of the pattern.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The <see cref="CellCollection"/>, which represent the pattern itself.
        /// </summary>
        public CellCollection Cells { get; set; }

        /// <summary>
        /// Initializes a new <see cref="Pattern"/>.
        /// </summary>
        public Pattern()
        {
            Cells = new CellCollection();
        }

        #region IXmlBuildable Members

        public void BuildFromXml(XElement element)
        {
            if (element != null)
            {
                Name = element.Attribute("name").Value;
                Description = element.Element("Description").Value;
                Cells.BuildFromXml(element.Element("Cells"));
            }
        }

        public void BuildFromXml(string xml)
        {
            XDocument document = Utilities.ParseXml(xml);
            if (document != null)
            {
                XElement patternElement = document.Element("Pattern");
                BuildFromXml(patternElement);
            }
        }

        public string GetXml()
        {
            var document = new XDocument();
            return GetXml(document);
        }

        public string GetXml(XDocument document)
        {
            var patternElement = GetXElement();
            document.Add(patternElement);
            return document.ToString();
        }

        public XElement GetXElement()
        {
            var patternElement = new XElement("Pattern");
            XElement descriptionElement = new XElement("Description");
            descriptionElement.Add(Description);

            patternElement.SetAttributeValue("name", Name);
            patternElement.Add(descriptionElement);
            patternElement.Add(Cells.GetXElement());

            return patternElement;
        }

        #endregion
    }
}