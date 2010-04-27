using System.Collections.Generic;
using System;
using System.Xml.Linq;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Represents a list from <see cref="Cell"/> objects.
    /// </summary>
    public class CellCollection : List<Cell>, IXmlBuildable
    {
        #region IXmlBuildable Members

        public string GetXml()
        {
            var document = new XDocument();
            return GetXml(document);
        }

        public string GetXml(XDocument document)
        {
            XElement cellsElement = GetXElement();
            document.Add(cellsElement);
            return document.ToString();
        }

        public void BuildFromXml(string xml)
        {
            XDocument document = Utilities.ParseXml(xml);
            if (document != null)
            {
                XElement cellsElement = document.Element("Cells");
                BuildFromXml(cellsElement);
            }
        }

        public void BuildFromXml(XElement element)
        {
            foreach (XElement cellElement in element.Elements("Cell"))
            {
                var cell = new Cell();
                cell.BuildFromXml(cellElement);
                Add(cell);
            }
        }


        public XElement GetXElement()
        {
            var cellsElement = new XElement("Cells");

            foreach (Cell cell in this)
            {
                var element = cell.GetXElement();
                cellsElement.Add(element);
            }

            return cellsElement;
        }

        #endregion
    }
}