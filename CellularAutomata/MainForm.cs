using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CellularAutomata.Framework;

namespace CellularAutomata
{
    ///<summary>
    ///</summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            patternsViewControl.LoadPatterns(ApplicationManager.Patterns);
        }

		private void ExitMenu_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void AboutMenu_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
		}

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            cellularAutomataCanvas.Stop();
            cellularAutomataCanvas.DetachEvents();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Запазване на текуща генерация";
            saveFileDialog.Filter = "CellularAutomata file (*.ca)|*.ca";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                using (Stream stream = saveFileDialog.OpenFile())
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, cellularAutomataCanvas.Environment);
                    stream.Close();
                }
            }

            cellularAutomataCanvas.AttachEvents();
        }

        private void OpenMenu_Click(object sender, EventArgs e)
        {
            cellularAutomataCanvas.Stop();
            cellularAutomataCanvas.DetachEvents();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "ca";
            openFileDialog.Filter = "CellularAutomata file (*.ca)|*.ca";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                using (Stream stream = openFileDialog.OpenFile())
                {
                    IFormatter formatter = new BinaryFormatter();
                    cellularAutomataCanvas.Environment = (CAEnvironment) formatter.Deserialize(stream);
                    stream.Close();
                }
            }

            cellularAutomataCanvas.AttachEvents();
            cellularAutomataCanvas.Refresh();
        }
    }
}