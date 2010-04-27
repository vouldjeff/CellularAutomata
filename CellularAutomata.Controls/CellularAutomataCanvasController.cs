using CellularAutomata.Framework;

namespace CellularAutomata.Controls
{
    public class CellularAutomataCanvasController
    {
        public void CreateCommand(string commandName, CellularAutomataCanvas canvas)
        {
            switch (commandName)
            {
                case "Start":
                    canvas.Start();
                    break;
                case "Stop":
                    canvas.Stop();
                    break;
                case "Clear":
                    canvas.Clear();
                    break;
            }
        }
    }
}