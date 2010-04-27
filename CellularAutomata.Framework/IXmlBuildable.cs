using System.Xml.Linq;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Provides a functionality to serialize and deserialize object into XML format.
    /// </summary>
    public interface IXmlBuildable
    {
        /// <summary>
        /// Deserialize object from XML in a <see cref="string"/>. 
        /// </summary>
        /// <param name="xml">The XML code, which which will be used to build the object.</param>
        void BuildFromXml(string xml);

        /// <summary>
        /// Deserialize object from an <see cref="XElement"/>.
        /// </summary>
        /// <param name="element">The XML code, which which will be used to build the object.</param>
        void BuildFromXml(XElement element);
       
        /// <summary>
        /// Serialize this object into XML format.
        /// </summary>
        /// <returns>The serialized object.</returns>
        string GetXml();

        /// <summary>
        /// Serialize this object into XML format.
        /// </summary>
        /// <param name="doc">Already created <see cref="XDocument"/>.</param>
        /// <returns>The updated <paramref name="doc"/> with this object in <see cref="string"/>.</returns>
        string GetXml(XDocument doc);

        /// <summary>
        /// Returns a new <see cref="XElement"/> from this object`s properties.
        /// </summary>
        /// <returns>The <see cref="XElement"/>.</returns>
        XElement GetXElement();
    }
}