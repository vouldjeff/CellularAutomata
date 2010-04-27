using System.Drawing;
using System.Xml.Linq;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Represents a single cell with its <paramref name="State"/> and <paramref name="Location"/>.
    /// </summary>
    /// <param name="State">The current state of the cell.</param>
    /// <param name="Location">The current <see cref="Point">location</see> of the cell.</param>
    public class Cell : IXmlBuildable
    {
        /// <summary>
        /// The current state of the cell.
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// The current location of the cell using a <see cref="Point"/>.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// The default constructor used for Unit testing.
        /// </summary>
        internal Cell()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class using the cell`s location. 
        /// </summary>
        /// <param name="location">The location of the cell using a <see cref="Point"/>.</param>
        internal Cell(Point location)
        {
            Location = location;
        }

        #region IXmlBuildable Members

        public void BuildFromXml(XElement element)
        {
            if (element != null)
            {
                State = true;
                var x = int.Parse(element.Attribute("left").Value);
                var y = int.Parse(element.Attribute("top").Value);

                Location = new Point(x, y);
            }
        }

        public void BuildFromXml(string xml)
        {
            XDocument document = Utilities.ParseXml(xml);
            if (document != null)
            {
                XElement cellElement = document.Element("Cell");
                BuildFromXml(cellElement);
            }
        }

        public string GetXml()
        {
            var doc = new XDocument();
            return GetXml(doc);
        }

        public string GetXml(XDocument doc)
        {
            var cellEl = GetXElement();
            doc.Add(cellEl);
            return doc.ToString();
        }

        public XElement GetXElement()
        {
            var cellEl = new XElement("Cell");
            cellEl.SetAttributeValue("left", Location.X);
            cellEl.SetAttributeValue("top", Location.Y);
            
            return cellEl;
        }

        #endregion
    }
}