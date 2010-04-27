// Type: System.Windows.Forms.ToolStripControlHost
// Assembly: System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Windows.Forms.dll

using System;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
	public class ToolStripControlHost : ToolStripItem
	{
		public ToolStripControlHost(Control c);
		public ToolStripControlHost(Control c, string name);

		public override Color BackColor { get; set; }

		[DefaultValue(null)]
		[Localizable(true)]
		public override Image BackgroundImage { get; set; }

		[Localizable(true)]
		[DefaultValue(1)]
		public override ImageLayout BackgroundImageLayout { get; set; }

		public override bool CanSelect { get; }

		[DefaultValue(true)]
		public bool CausesValidation { get; set; }

		[Browsable(false)]
		[DefaultValue(32)]
		public ContentAlignment ControlAlign { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Control Control { get; }

		protected override Size DefaultSize { get; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ToolStripItemDisplayStyle DisplayStyle { get; set; }

		[Browsable(false)]
		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool DoubleClickEnabled { get; set; }

		public override Font Font { get; set; }
		public override bool Enabled { get; set; }

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(false)]
		public virtual bool Focused { get; }

		public override Color ForeColor { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Image Image { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ToolStripItemImageScaling ImageScaling { get; set; }

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Color ImageTransparentColor { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new ContentAlignment ImageAlign { get; set; }

		public override RightToLeft RightToLeft { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new bool RightToLeftAutoMirrorImage { get; set; }

		public override bool Selected { get; }
		public override Size Size { get; set; }

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public override ISite Site { get; set; }

		[DefaultValue("")]
		public override string Text { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new ContentAlignment TextAlign { get; set; }

		[DefaultValue(1)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override ToolStripTextDirection TextDirection { get; set; }

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new TextImageRelation TextImageRelation { get; set; }

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected override AccessibleObject CreateAccessibilityInstance();

		protected override void Dispose(bool disposing);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void Focus();

		public override Size GetPreferredSize(Size constrainingSize);
		protected virtual void OnEnter(EventArgs e);
		protected virtual void OnGotFocus(EventArgs e);
		protected virtual void OnLeave(EventArgs e);
		protected virtual void OnLostFocus(EventArgs e);
		protected virtual void OnKeyDown(KeyEventArgs e);
		protected virtual void OnKeyPress(KeyPressEventArgs e);
		protected virtual void OnKeyUp(KeyEventArgs e);
		protected override void OnBoundsChanged();
		protected override void OnPaint(PaintEventArgs e);
		protected internal override void OnLayout(LayoutEventArgs e);
		protected override void OnParentChanged(ToolStrip oldParent, ToolStrip newParent);
		protected virtual void OnSubscribeControlEvents(Control control);
		protected virtual void OnUnsubscribeControlEvents(Control control);
		protected virtual void OnValidating(CancelEventArgs e);
		protected virtual void OnValidated(EventArgs e);
		protected virtual void OnHostedControlResize(EventArgs e);
		protected internal override bool ProcessCmdKey(ref Message m, Keys keyData);
		protected internal override bool ProcessDialogKey(Keys keyData);
		protected override void SetVisibleCore(bool visible);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void ResetBackColor();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void ResetForeColor();

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler DisplayStyleChanged;

		public event EventHandler Enter;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event EventHandler GotFocus;

		public event EventHandler Leave;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event EventHandler LostFocus;

		public event KeyEventHandler KeyDown;
		public event KeyPressEventHandler KeyPress;
		public event KeyEventHandler KeyUp;
		public event CancelEventHandler Validating;
		public event EventHandler Validated;
	}
}
