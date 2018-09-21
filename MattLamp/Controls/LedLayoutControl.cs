using MattLamp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace MattLamp.Controls
{
    [Designer(typeof(LedLayoutControl), typeof(Control))]
    [ComplexBindingProperties("DataSource")]
    internal class LedLayoutControl : Control
    {
        private object _DataSource;
        private string _DataMember;
        private CurrencyManager _CurrencyManager;
        private IBindingList _BindingList;
        private List<LedModel> _Leds = new List<LedModel>();
        private Rectangle _BoundingBox;
        private int _HoveredIndex = -1;

        [Category("Behavior")]
        public event EventHandler<StatusTextChangedEventArgs> StatusTextChanged;

        [Category("Action")]
        public event EventHandler<LedStatusEventArgs> OnItemRightClick;

        public LedLayoutControl() : base()
        {
            SetStyle(ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region Data binding

        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        public object DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                if (value != null && !(value is IList)) throw new ArgumentException("DataSource must extend IList");
                if (_DataSource == value) return;
                _DataSource = value;
                SetDataBinding();
                OnDataSourceChanged(EventArgs.Empty);
            }
        }

        public event EventHandler DataSourceChanged;

        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            DataSourceChanged?.Invoke(this, e);
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]
        public string DataMember
        {
            get
            {
                return _DataMember;
            }
            set
            {
                if (_DataMember == value) return;
                _DataMember = value;
                SetDataBinding();
                OnDataMemberChanged(EventArgs.Empty);
            }
        }

        public event EventHandler DataMemberChanged;

        protected virtual void OnDataMemberChanged(EventArgs e)
        {
            DataMemberChanged?.Invoke(this, e);
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
            SetDataBinding();
        }

        protected override void OnParentBindingContextChanged(EventArgs e)
        {
            base.OnParentBindingContextChanged(e);
            SetDataBinding();
        }

        #endregion

        #region LED selection

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (!Enabled) return;
            var i = FindLedAtPoint(e.Location);
            if (i > -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _Leds[i].Selected = !_Leds[i].Selected;
                    Invalidate();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    var led = _Leds[i].Led.Color;
                    OnItemRightClick?.Invoke(this, new LedStatusEventArgs(led, e.Location));
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var i = FindLedAtPoint(e.Location);
            if (Enabled && i > -1)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
            HandleHovered(i);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
            HandleHovered(-1);
        }

        private int FindLedAtPoint(Point p)
        {
            for (int i = 0; i < _Leds.Count; i++)
            {
                var gp = new GraphicsPath();
                gp.AddEllipse(_Leds[i].LastDraw);
                if (gp.IsVisible(p)) return i;
            }
            return -1;
        }

        public int[] GetSelectedIndeces()
        {
            return Enumerable.Range(0, _Leds.Count).Where(i => _Leds[i].Selected).ToArray();
        }

        public bool IsAllSelected()
        {
            return _Leds.All(l => l.Selected);
        }

        #endregion

        #region Event handlers

        private void bindingList_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemChanged:
                    _Leds[e.NewIndex].Led = (LedStatus)_CurrencyManager.List[e.NewIndex];
                    // The reference above is probably already the same, and since we can't change layout, just paint the canvas again
                    Invalidate();
                    // If we did indeed need to redo the layout, call this instead:
                    //ComputeLayout();
                    break;
                case ListChangedType.ItemAdded:
                    var newItem = (LedStatus)_CurrencyManager.List[e.NewIndex];
                    _Leds.Insert(e.NewIndex, CreateItem(newItem));
                    ComputeLayout();
                    break;
                case ListChangedType.ItemDeleted:
                    if (e.NewIndex < _Leds.Count)
                    {
                        _Leds.RemoveAt(e.NewIndex);
                    }
                    Invalidate();
                    break;
                case ListChangedType.ItemMoved:
                    var moving = _Leds[e.OldIndex];
                    _Leds.RemoveAt(e.OldIndex);
                    _Leds.Insert(e.NewIndex, moving);
                    Invalidate();
                    break;
                case ListChangedType.Reset:
                case ListChangedType.PropertyDescriptorAdded:
                case ListChangedType.PropertyDescriptorChanged:
                case ListChangedType.PropertyDescriptorDeleted:
                    LoadItemsFromSource();
                    break;
            }
        }

        private void currencyManager_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            if (e.Index == -1)
            {
                if (!ReferenceEquals(_BindingList, _CurrencyManager.List))
                {
                    _BindingList.ListChanged -= bindingList_ListChanged;
                    _BindingList = _CurrencyManager.List as IBindingList;
                    if (_BindingList != null)
                    {
                        _BindingList.ListChanged += bindingList_ListChanged;
                    }
                }
                LoadItemsFromSource();
            }
        }

        #endregion

        #region Private methods

        private void SetDataBinding()
        {
            if (BindingContext != null)
            {
                CurrencyManager currencyManager = null;
                IBindingList bindingList = null;

                if (DataSource != null)
                {
                    currencyManager = (CurrencyManager)BindingContext[DataSource, DataMember];
                    if (currencyManager != null)
                    {
                        bindingList = currencyManager.List as IBindingList;
                    }
                }

                bool reloadItems = false;
                if (currencyManager != _CurrencyManager)
                {
                    if (_CurrencyManager != null)
                    {
                        _CurrencyManager.ItemChanged -= currencyManager_ItemChanged;
                    }

                    _CurrencyManager = currencyManager;

                    if (_CurrencyManager != null)
                    {
                        reloadItems = true;
                        _CurrencyManager.ItemChanged += currencyManager_ItemChanged;
                    }
                }

                if (bindingList != _BindingList)
                {
                    if (_BindingList != null)
                    {
                        _BindingList.ListChanged -= bindingList_ListChanged;
                    }
                    _BindingList = bindingList;
                    if (_BindingList != null)
                    {
                        reloadItems = true;
                        _BindingList.ListChanged += bindingList_ListChanged;
                    }
                }

                if (reloadItems)
                {
                    LoadItemsFromSource();
                }
            }
        }

        private void LoadItemsFromSource()
        {
            _Leds.Clear();
            IList items = _CurrencyManager.List;
            int c = items.Count;
            for (int i = 0; i < c; i++)
            {
                var led = (LedStatus)items[i];
                _Leds.Add(CreateItem(led));
            }
            ComputeLayout();
        }

        private LedModel CreateItem(LedStatus led)
        {
            return new LedModel() { Led = led, Selected = true };
        }

        private void ComputeLayout()
        {
            var minX = int.MaxValue;
            var minY = int.MaxValue;
            var maxX = 0;
            var maxY = 0;
            bool hadAbsolute = false;

            foreach (var led in _Leds.Select(l => l.Led).Where(l => l.X >= 0 && l.Y >= 0))
            {
                hadAbsolute = true;
                if (led.X < minX) minX = led.X;
                if (led.Y < minY) minY = led.Y;
                if (led.X + led.Size > maxX) maxX = led.X + led.Size;
                if (led.Y + led.Size > maxY) maxY = led.Y + led.Size;
            }

            if (hadAbsolute)
            {
                _BoundingBox = new Rectangle(0, 0, maxX - minX, maxY - minY);
                foreach (var led in _Leds)
                {
                    led.Location = new Point(led.Led.X - minX, led.Led.Y - minY);
                }
            }
            else _BoundingBox = Rectangle.Empty;

            Invalidate();
        }

        private void HandleHovered(int index)
        {
            if (_HoveredIndex != index)
            {
                _HoveredIndex = index;
                if (_HoveredIndex > -1)
                {
                    var s = string.Format("#{0} ({1}) Click to toggle selection.", _HoveredIndex + 1, _Leds[_HoveredIndex].Led.Color);
                    StatusTextChanged?.Invoke(this, new StatusTextChangedEventArgs(s));
                }
                else
                {
                    StatusTextChanged?.Invoke(this, new StatusTextChangedEventArgs(string.Empty));
                }
            }
        }

        #endregion

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            base.OnPaint(e);

            // Scale bounding box to canvas
            var scaledBox = RectangleF.Empty;
            var scale = 1.0f;

            if (!_BoundingBox.IsEmpty)
            {
                var vScale = (Height - 21) / (float)_BoundingBox.Height;
                var hScale = (Width - 21) / (float)_BoundingBox.Width;
                scale = Math.Min(vScale, hScale);
                var newH = _BoundingBox.Height * scale;
                var newW = _BoundingBox.Width * scale;
                scaledBox = new RectangleF(Width - newW + 10, Height - newH + 10, newW, newH);
            }

            var currentAutoPos = new Point(10, 10);
            int lastRowMaxHeight = 0;

            foreach (var item in _Leds)
            {
                Point loc;
                if (item.Location.HasValue)
                {
                    loc = item.Location.Value;
                }
                else
                {
                    if (currentAutoPos.X + item.Led.Size > Width)
                    {
                        currentAutoPos = new Point(10, currentAutoPos.Y + lastRowMaxHeight + 10);
                        lastRowMaxHeight = 0;
                    }
                    loc = currentAutoPos;
                    lastRowMaxHeight = Math.Max(lastRowMaxHeight, item.Led.Size);
                    currentAutoPos.Offset(item.Led.Size + 10, 0);
                }
                item.LastDraw = new RectangleF(loc.X * scale + 10, loc.Y * scale + 10, item.Led.Size * scale, item.Led.Size * scale);

                if (item.Selected)
                {
                    var selectedBox = new RectangleF(item.LastDraw.X - 5, item.LastDraw.Y - 5, item.LastDraw.Width + 10, item.LastDraw.Height + 10);
                    var selectedBrush = new SolidBrush(Enabled ? SystemColors.Highlight : SystemColors.ControlDark);
                    e.Graphics.FillEllipse(selectedBrush, selectedBox);
                }

                e.Graphics.FillEllipse(new SolidBrush(item.Led.Color.ToColor()), item.LastDraw);
                e.Graphics.DrawEllipse(Pens.Black, item.LastDraw);
            }
        }

        #endregion

        private class LedModel
        {
            public LedStatus Led { get; set; }

            public Point? Location { get; set; }

            public RectangleF LastDraw { get; set; }

            public bool Selected { get; set; }
        }
    }

    internal static class LedLayoutUtils
    {
        // May want to refactor this out as a static extension method if this were to ever be made into a library to lose the dependency on System.Drawing
        public static Color ToColor(this LedColor c)
        {
            return Color.FromArgb(c.R, c.G, c.B);
        }
    }

    internal class StatusTextChangedEventArgs : EventArgs
    {
        public StatusTextChangedEventArgs(string statusText)
        {
            StatusText = statusText ?? throw new ArgumentNullException("statusText");
        }

        public string StatusText { get; }
    }

    internal class LedStatusEventArgs : EventArgs
    {
        public LedStatusEventArgs(LedColor led, Point p)
        {
            Led = led;
            Location = p;
        }

        public LedColor Led { get; }

        public Point Location { get; }
    }
}
