// Type: System.Windows.Forms.ToolStripItem
// Assembly: System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Windows.Forms.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms.Layout;

namespace System.Windows.Forms
{
	[Designer(
		"System.Windows.Forms.Design.ToolStripItemDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
		)]
	[DefaultProperty("Text")]
	[DefaultEvent("Click")]
	[ToolboxItem(false)]
	[DesignTimeVisible(false)]
	public abstract class ToolStripItem : Component, IDropTarget, ISupportOleDropSource, IArrangedElement, IComponent,
	                                      IDisposable
	{
		protected ToolStripItem();
		protected ToolStripItem(string text, Image image, EventHandler onClick);
		protected ToolStripItem(string text, Image image, EventHandler onClick, string name);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public AccessibleObject AccessibilityObject { get; }

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string AccessibleDefaultActionDescription { get; set; }

		[DefaultValue(null)]
		[Localizable(true)]
		public string AccessibleDescription { get; set; }

		[DefaultValue(null)]
		[Localizable(true)]
		public string AccessibleName { get; set; }

		[DefaultValue(-1)]
		public AccessibleRole AccessibleRole { get; set; }

		[DefaultValue(0)]
		public ToolStripItemAlignment Alignment { get; set; }

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(false)]
		[Browsable(false)]
		public virtual bool AllowDrop { get; set; }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[Localizable(true)]
		[DefaultValue(true)]
		public bool AutoSize { get; set; }

		[DefaultValue(false)]
		public bool AutoToolTip { get; set; }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool Available { get; set; }

		[DefaultValue(null)]
		[Localizable(true)]
		public virtual Image BackgroundImage { get; set; }

		[DefaultValue(1)]
		[Localizable(true)]
		public virtual ImageLayout BackgroundImageLayout { get; set; }

		public virtual Color BackColor { get; set; }

		[Browsable(false)]
		public Rectangle ContentRectangle { get; }

		[Browsable(false)]
		public virtual bool CanSelect { get; }

		[DefaultValue(5)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AnchorStyles Anchor { get; set; }

		[Browsable(false)]
		[DefaultValue(0)]
		public DockStyle Dock { get; set; }

		protected virtual bool DefaultAutoToolTip { get; }
		protected internal virtual Padding DefaultMargin { get; }
		protected virtual Padding DefaultPadding { get; }
		protected virtual Size DefaultSize { get; }
		protected virtual ToolStripItemDisplayStyle DefaultDisplayStyle { get; }
		protected internal virtual bool DismissWhenClicked { get; }
		public virtual ToolStripItemDisplayStyle DisplayStyle { get; set; }

		[DefaultValue(false)]
		public bool DoubleClickEnabled { get; set; }

		[DefaultValue(true)]
		[Localizable(true)]
		public virtual bool Enabled { get; set; }

		public virtual Color ForeColor { get; set; }

		[Localizable(true)]
		public virtual Font Font { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public int Height { get; set; }

		[DefaultValue(32)]
		[Localizable(true)]
		public ContentAlignment ImageAlign { get; set; }

		[Localizable(true)]
		public virtual Image Image { get; set; }

		[Localizable(true)]
		public Color ImageTransparentColor { get; set; }

		[RefreshProperties(RefreshProperties.Repaint)]
		[RelatedImageList("Owner.ImageList")]
		[Browsable(false)]
		[Localizable(true)]
		[Editor(
			"System.Windows.Forms.Design.ToolStripImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
			, typeof (UITypeEditor))]
		[TypeConverter(typeof (NoneExcludedImageIndexConverter))]
		public int ImageIndex { get; set; }

		[TypeConverter(typeof (ImageKeyConverter))]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Browsable(false)]
		[RelatedImageList("Owner.ImageList")]
		[Editor(
			"System.Windows.Forms.Design.ToolStripImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
			, typeof (UITypeEditor))]
		[Localizable(true)]
		public string ImageKey { get; set; }

		[Localizable(true)]
		[DefaultValue(1)]
		public ToolStripItemImageScaling ImageScaling { get; set; }

		[Browsable(false)]
		public bool IsDisposed { get; }

		[Browsable(false)]
		public bool IsOnDropDown { get; }

		[Browsable(false)]
		public bool IsOnOverflow { get; }

		public Padding Margin { get; set; }

		[DefaultValue(0)]
		public MergeAction MergeAction { get; set; }

		[DefaultValue(-1)]
		public int MergeIndex { get; set; }

		[DefaultValue(null)]
		[Browsable(false)]
		public string Name { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStrip Owner { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripItem OwnerItem { get; }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		protected internal ToolStrip Parent { get; set; }

		[DefaultValue(2)]
		public ToolStripItemOverflow Overflow { get; set; }

		public virtual Padding Padding { get; set; }

		[Browsable(false)]
		public ToolStripItemPlacement Placement { get; }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual bool Pressed { get; }

		[Localizable(true)]
		public virtual RightToLeft RightToLeft { get; set; }

		[Localizable(true)]
		[DefaultValue(false)]
		public bool RightToLeftAutoMirrorImage { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool Selected { get; }

		protected internal virtual bool ShowKeyboardCues { get; }

		[Localizable(true)]
		public virtual Size Size { get; set; }

		[Localizable(false)]
		[DefaultValue(null)]
		[TypeConverter(typeof (StringConverter))]
		[Bindable(true)]
		public object Tag { get; set; }

		[Localizable(true)]
		[DefaultValue("")]
		public virtual string Text { get; set; }

		[DefaultValue(32)]
		[Localizable(true)]
		public virtual ContentAlignment TextAlign { get; set; }

		public virtual ToolStripTextDirection TextDirection { get; set; }

		[DefaultValue(4)]
		[Localizable(true)]
		public TextImageRelation TextImageRelation { get; set; }

		[Localizable(true)]
		[Editor(
			"System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
			, typeof (UITypeEditor))]
		public string ToolTipText { get; set; }

		[Localizable(true)]
		public bool Visible { get; set; }

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Width { get; set; }

		#region IArrangedElement Members

		public virtual Size GetPreferredSize(Size constrainingSize);

		[Browsable(false)]
		public virtual Rectangle Bounds { get; }

		#endregion

		#region IDropTarget Members

		void IDropTarget.OnDragEnter(DragEventArgs dragEvent);
		void IDropTarget.OnDragOver(DragEventArgs dragEvent);
		void IDropTarget.OnDragLeave(EventArgs e);
		void IDropTarget.OnDragDrop(DragEventArgs dragEvent);

		#endregion

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual AccessibleObject CreateAccessibilityInstance();

		protected override void Dispose(bool disposing);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects);

		public ToolStrip GetCurrentParent();
		public void Invalidate();
		public void Invalidate(Rectangle r);
		protected internal virtual bool IsInputKey(Keys keyData);
		protected internal virtual bool IsInputChar(char charCode);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnBackColorChanged(EventArgs e);

		protected virtual void OnBoundsChanged();
		protected virtual void OnClick(EventArgs e);
		protected internal virtual void OnLayout(LayoutEventArgs e);
		protected virtual void OnAvailableChanged(EventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDragEnter(DragEventArgs dragEvent);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDragOver(DragEventArgs dragEvent);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDragLeave(EventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDragDrop(DragEventArgs dragEvent);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDisplayStyleChanged(EventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnGiveFeedback(GiveFeedbackEventArgs giveFeedbackEvent);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnQueryContinueDrag(QueryContinueDragEventArgs queryContinueDragEvent);

		protected virtual void OnDoubleClick(EventArgs e);
		protected virtual void OnEnabledChanged(EventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnForeColorChanged(EventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnFontChanged(EventArgs e);

		protected virtual void OnLocationChanged(EventArgs e);
		protected virtual void OnMouseEnter(EventArgs e);
		protected virtual void OnMouseMove(MouseEventArgs mea);
		protected virtual void OnMouseHover(EventArgs e);
		protected virtual void OnMouseLeave(EventArgs e);
		protected virtual void OnMouseDown(MouseEventArgs e);
		protected virtual void OnMouseUp(MouseEventArgs e);
		protected virtual void OnPaint(PaintEventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentBackColorChanged(EventArgs e);

		protected virtual void OnParentChanged(ToolStrip oldParent, ToolStrip newParent);
		protected internal virtual void OnParentEnabledChanged(EventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected internal virtual void OnOwnerFontChanged(EventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentForeColorChanged(EventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected internal virtual void OnParentRightToLeftChanged(EventArgs e);

		protected virtual void OnOwnerChanged(EventArgs e);
		protected virtual void OnRightToLeftChanged(EventArgs e);

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnTextChanged(EventArgs e);

		protected virtual void OnVisibleChanged(EventArgs e);
		public void PerformClick();
		protected internal virtual bool ProcessDialogKey(Keys keyData);
		protected internal virtual bool ProcessCmdKey(ref Message m, Keys keyData);
		protected internal virtual bool ProcessMnemonic(char charCode);
		public void Select();
		protected virtual void SetVisibleCore(bool visible);
		protected internal virtual void SetBounds(Rectangle bounds);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetBackColor();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetDisplayStyle();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetForeColor();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetFont();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetImage();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetMargin();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetPadding();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetRightToLeft();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetTextDirection();

		public override string ToString();

		[Browsable(false)]
		public event EventHandler AvailableChanged;

		public event EventHandler BackColorChanged;
		public event EventHandler Click;
		public event EventHandler DisplayStyleChanged;
		public event EventHandler DoubleClick;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event DragEventHandler DragDrop;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event DragEventHandler DragEnter;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event DragEventHandler DragOver;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event EventHandler DragLeave;

		public event EventHandler EnabledChanged;
		public event EventHandler ForeColorChanged;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event GiveFeedbackEventHandler GiveFeedback;

		public event EventHandler LocationChanged;
		public event MouseEventHandler MouseDown;
		public event EventHandler MouseEnter;
		public event EventHandler MouseLeave;
		public event EventHandler MouseHover;
		public event MouseEventHandler MouseMove;
		public event MouseEventHandler MouseUp;
		public event EventHandler OwnerChanged;
		public event PaintEventHandler Paint;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event QueryContinueDragEventHandler QueryContinueDrag;

		public event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp;
		public event EventHandler RightToLeftChanged;
		public event EventHandler TextChanged;
		public event EventHandler VisibleChanged;

		#region Nested type: ToolStripItemAccessibleObject

		[ComVisible(true)]
		public class ToolStripItemAccessibleObject : AccessibleObject
		{
			public ToolStripItemAccessibleObject(ToolStripItem ownerItem);
			public override string DefaultAction { get; }
			public override string Description { get; }
			public override string Help { get; }
			public override string KeyboardShortcut { get; }
			public override string Name { get; set; }
			public override AccessibleRole Role { get; }
			public override AccessibleStates State { get; }
			public override Rectangle Bounds { get; }
			public override AccessibleObject Parent { get; }
			public override void DoDefaultAction();
			public override int GetHelpTopic(out string fileName);
			public override AccessibleObject Navigate(AccessibleNavigation navigationDirection);
			public void AddState(AccessibleStates state);
			public override string ToString();
		}

		#endregion
	}
}
