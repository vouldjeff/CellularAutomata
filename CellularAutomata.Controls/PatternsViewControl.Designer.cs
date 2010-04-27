namespace CellularAutomata.Controls
{
    partial class PatternsViewControl
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
            this.patternsView = new System.Windows.Forms.ListView();
            this.patternsImages = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // patternsView
            // 
            this.patternsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patternsView.Location = new System.Drawing.Point(0, 0);
            this.patternsView.MultiSelect = false;
            this.patternsView.Name = "patternsView";
            this.patternsView.ShowItemToolTips = true;
            this.patternsView.Size = new System.Drawing.Size(164, 344);
            this.patternsView.TabIndex = 1;
            this.patternsView.UseCompatibleStateImageBehavior = false;
            this.patternsView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.patternsView_MouseMove);
            // 
            // patternsImages
            // 
            this.patternsImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit;
            this.patternsImages.ImageSize = new System.Drawing.Size(30, 30);
            this.patternsImages.TransparentColor = System.Drawing.Color.White;
            // 
            // PatternsViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.patternsView);
            this.Name = "PatternsViewControl";
            this.Size = new System.Drawing.Size(164, 344);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView patternsView;
        private System.Windows.Forms.ImageList patternsImages;
    }
}
