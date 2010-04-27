using System;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Static class, which provides some standalone functions.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Retrieves rule type by the name of the rule.
        /// </summary>
        /// <param name="ruleName">The name of the rule, which <see cref="Type"/> is returned.</param>
        /// <returns><see cref="Type"/> of <see cref="IRule"/> object.</returns>
        public static Type GetRuleType(string ruleName)
        {
            switch (ruleName)
            {
                case "GameOfLife":
                    return typeof (GameOfLifeRule);
                case "CellularAutomation":
                    return typeof (CellularAutomationRule);
                case "TraditionalMaze":
                    return typeof (TraditionalMazeRule);
                default:
                    return Type.GetType(ruleName + "Rule");
            }
        }

        /// <summary>
        /// Retrieves neighbourhood type by the name of the rule.
        /// </summary>
        /// <param name="neighbourhoodName">The name of the neighbourhood, which <see cref="Type"/> is returned.</param>
        /// <returns><see cref="Type"/> of <see cref="INeighbourhood"/> object.</returns>
        public static Type GetNeighbourhoodType(string neighbourhoodName)
        {
            switch (neighbourhoodName)
            {
                case "Moore":
                    return typeof (MooreNeighbourhood);
                case "VonNeumann":
                    return typeof (VonNeumannNeighbourhood);
                case "BaseAutomation":
                    return typeof (BaseAutomationNeighbourhood);
                default:
                    return Type.GetType(neighbourhoodName + "Neighbourhood");
            }
        }

        /// <summary>
        /// Returns key used for the <see cref="CellState"/> collection.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns>A <see cref="long"/> number, which represents the key.</returns>
        public static long GetKey(this Cell cell)
        {
            return GetKey(cell.Location);
        }

        /// <summary>
        /// Returns key used for the <see cref="CellState"/> collection.
        /// </summary>
        /// <param name="location">The location of the cell, which key is returned.</param>
        /// <returns>A <see cref="long"/> number, which represents the key.</returns>
        public static long GetKey(Point location)
        {
            byte[] byteX = BitConverter.GetBytes(location.X);
            byte[] byteY = BitConverter.GetBytes(location.Y);
            byte[] byteZ = new byte[8];
            Array.Copy(byteX, byteZ, 4);
            Array.Copy(byteY, 0, byteZ, 4, 4);

            return BitConverter.ToInt64(byteZ, 0);
        }

        /// <summary>
        /// Retrieves the location of a <see cref="Cell"/> with particular key.
        /// </summary>
        /// <param name="key">The key of the cell, which is returned.</param>
        /// <returns>A <see cref="Cell"/> location.</returns>
        public static Point GetCellFromKey(long key)
        {
            byte[] byteZ = BitConverter.GetBytes(key);
            int x = BitConverter.ToInt32(byteZ, 0);
            int y = BitConverter.ToInt32(byteZ, 4);

            return new Point(x, y);
        }

        /// <summary>
        /// Returns the binary format of a basic rule with number <see cref="byte"/>.
        /// </summary>
        /// <param name="rule">The number of the rule.</param>
        /// <returns>The binary representation of a rule number.</returns>
        public static bool[] GetBinaryFromByte(byte rule)
        {
            bool[] binary = new bool[8] {false, false, false, false, false, false, false, false};

            byte index = 0;
            while (rule > 0)
            {
                binary[index] = rule % 2 != 0;

                rule /= 2;
                index++;
            }

            return binary;
        }

        public static XDocument ParseXml(string xml)
        {
            XDocument document = null;
            try
            {
                document = XDocument.Parse(xml);
            }
            catch (XmlException)
            {
                //TODO: handle the exception
            }
            return document;
        }
    }
}