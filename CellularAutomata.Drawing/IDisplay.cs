using System;
using CellularAutomata.Framework;
using System.Drawing;

namespace CellularAutomata.Drawing
{
	/// <summary>
	/// Represents a basic display, which visualizes the Cellular Automata.
	/// </summary>
	public interface IDisplay
	{
		/// <summary>
		/// The ratio between the <see cref="Cell"/> location metric and the display metric. 
		/// </summary>
		int Ratio { get; set; }

		/// <summary>
		/// Draws the grid guides if needed.
		/// </summary>
		/// <param name="args">Arguments for function (can be <see cref="Nullable"/>).</param>
		/// <param name="environment">The <see cref="CAEnvironment"/>`s grid to be drawed.</param>
		void DrawGuides(object[] args, CAEnvironment environment);

		/// <summary>
		/// Draws all the <see cref="Cell"/> objects.
		/// </summary>
		/// <param name="args">Arguments for function (can be <see cref="Nullable"/>).</param>
		/// <param name="environment">The <see cref="CAEnvironment"/>`s <see cref="Cell"/> objects to be drawed.</param>
		void DrawAutomata(object[] args, CAEnvironment environment);
	}
}