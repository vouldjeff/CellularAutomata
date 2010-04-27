namespace CellularAutomata.Controls
{
    partial class CellularAutomataCanvas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CellularAutomataCanvas));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.numberOfCellsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.numberOfLiveCells = new System.Windows.Forms.ToolStripStatusLabel();
            this.generationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.generation = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedControl = new CellularAutomata.Controls.ToolStripTrackBar();
            this.speedValueLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.automataSpace = new System.Windows.Forms.PictureBox();
            this.controlStrip = new System.Windows.Forms.ToolStrip();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearButton = new System.Windows.Forms.ToolStripButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.automataSpace)).BeginInit();
            this.controlStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numberOfCellsLabel,
            this.numberOfLiveCells,
            this.generationLabel,
            this.generation,
            this.speedLabel,
            this.speedControl,
            this.speedValueLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 276);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(514, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // numberOfCellsLabel
            // 
            this.numberOfCellsLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.numberOfCellsLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.numberOfCellsLabel.Name = "numberOfCellsLabel";
            this.numberOfCellsLabel.Size = new System.Drawing.Size(84, 17);
            this.numberOfCellsLabel.Text = "Живи клетки: ";
            // 
            // numberOfLiveCells
            // 
            this.numberOfLiveCells.AutoSize = false;
            this.numberOfLiveCells.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.numberOfLiveCells.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.numberOfLiveCells.Name = "numberOfLiveCells";
            this.numberOfLiveCells.Size = new System.Drawing.Size(50, 17);
            this.numberOfLiveCells.Text = "0";
            this.numberOfLiveCells.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // generationLabel
            // 
            this.generationLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.generationLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.generationLabel.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.generationLabel.Size = new System.Drawing.Size(71, 17);
            this.generationLabel.Text = "Генерация: ";
            // 
            // generation
            // 
            this.generation.AutoSize = false;
            this.generation.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.generation.Name = "generation";
            this.generation.Size = new System.Drawing.Size(50, 17);
            this.generation.Text = "1";
            this.generation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // speedLabel
            // 
            this.speedLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(59, 17);
            this.speedLabel.Text = "Скорост: ";
            // 
            // speedControl
            // 
            this.speedControl.AutoToolTip = true;
            this.speedControl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.speedControl.LargeChange = 5;
            this.speedControl.Maximum = 10;
            this.speedControl.Minimum = 0;
            this.speedControl.Name = "speedControl";
            this.speedControl.Size = new System.Drawing.Size(104, 20);
            this.speedControl.Value = 10;
            this.speedControl.ValueChanged += new System.EventHandler(this.speedControl_ValueChanged);
            // 
            // speedValueLabel
            // 
            this.speedValueLabel.AutoSize = false;
            this.speedValueLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.speedValueLabel.Name = "speedValueLabel";
            this.speedValueLabel.Size = new System.Drawing.Size(50, 17);
            this.speedValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // automataSpace
            // 
            this.automataSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.automataSpace.Location = new System.Drawing.Point(0, 25);
            this.automataSpace.Name = "automataSpace";
            this.automataSpace.Size = new System.Drawing.Size(514, 251);
            this.automataSpace.TabIndex = 1;
            this.automataSpace.TabStop = false;
            this.automataSpace.DragOver += new System.Windows.Forms.DragEventHandler(this.automataSpace_DragOver);
            this.automataSpace.MouseMove += new System.Windows.Forms.MouseEventHandler(this.automataSpace_MouseMove);
            this.automataSpace.DragDrop += new System.Windows.Forms.DragEventHandler(this.automataSpace_DragDrop);
            this.automataSpace.Resize += new System.EventHandler(this.automataSpace_Resize);
            this.automataSpace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.automataSpace_MouseDown);
            this.automataSpace.Paint += new System.Windows.Forms.PaintEventHandler(this.automataSpace_Paint);
            this.automataSpace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.automataSpace_MouseUp);
            this.automataSpace.SizeChanged += new System.EventHandler(this.automataSpace_SizeChanged);
            // 
            // controlStrip
            // 
            this.controlStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startButton,
            this.stopButton,
            this.toolStripSeparator1,
            this.clearButton});
            this.controlStrip.Location = new System.Drawing.Point(0, 0);
            this.controlStrip.Name = "controlStrip";
            this.controlStrip.Size = new System.Drawing.Size(514, 25);
            this.controlStrip.TabIndex = 2;
            this.controlStrip.Text = "controlStrip";
            this.controlStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.controlStrip_ItemClicked);
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(57, 22);
            this.startButton.Tag = "Start";
            this.startButton.Text = "Пускане";
            this.startButton.ToolTipText = "startButton";
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stopButton.Enabled = false;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(59, 22);
            this.stopButton.Tag = "Stop";
            this.stopButton.Text = "Спиране";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // clearButton
            // 
            this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 22);
            this.clearButton.Tag = "Clear";
            this.clearButton.Text = "Изчистване";
            this.clearButton.ToolTipText = "Clear";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CellularAutomataCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.automataSpace);
            this.Controls.Add(this.controlStrip);
            this.Controls.Add(this.statusStrip);
            this.Name = "CellularAutomataCanvas";
            this.Size = new System.Drawing.Size(514, 298);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.automataSpace)).EndInit();
            this.controlStrip.ResumeLayout(false);
            this.controlStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.PictureBox automataSpace;
        private System.Windows.Forms.ToolStrip controlStrip;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton clearButton;
        private System.Windows.Forms.ToolStripStatusLabel numberOfLiveCells;
        private System.Windows.Forms.ToolStripStatusLabel numberOfCellsLabel;
        private System.Windows.Forms.ToolStripStatusLabel generationLabel;
        private System.Windows.Forms.ToolStripStatusLabel generation;
        private System.Windows.Forms.ToolStripStatusLabel speedLabel;
        private ToolStripTrackBar speedControl;
		private System.Windows.Forms.ToolStripStatusLabel speedValueLabel;
    }
}
