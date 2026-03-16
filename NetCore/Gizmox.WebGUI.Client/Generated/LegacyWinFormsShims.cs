using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    public enum Shortcut
    {
        None = 0
    }

    public class Menu : Component
    {
        public class MenuItemCollection : IList
        {
            private readonly List<MenuItem> _items = new List<MenuItem>();
            private readonly Menu _owner;

            internal MenuItemCollection(Menu owner)
            {
                _owner = owner;
            }

            public int Count => _items.Count;
            public bool IsReadOnly => false;
            public bool IsFixedSize => false;
            public bool IsSynchronized => false;
            public object SyncRoot => ((ICollection)_items).SyncRoot;

            public MenuItem this[int index]
            {
                get => _items[index];
                set
                {
                    _items[index] = value;
                    value.Parent = _owner;
                }
            }

            object IList.this[int index]
            {
                get => this[index];
                set => this[index] = (MenuItem)value;
            }

            public int Add(object value)
            {
                if (value is MenuItem item)
                {
                    item.Parent = _owner;
                    _items.Add(item);
                    return _items.Count - 1;
                }

                throw new ArgumentException("MenuItem expected", nameof(value));
            }

            public void Clear() => _items.Clear();
            public bool Contains(object value) => value is MenuItem item && _items.Contains(item);
            public int IndexOf(object value) => value is MenuItem item ? _items.IndexOf(item) : -1;

            public void Insert(int index, object value)
            {
                var item = (MenuItem)value;
                item.Parent = _owner;
                _items.Insert(index, item);
            }

            public void Remove(object value)
            {
                if (value is MenuItem item)
                {
                    _items.Remove(item);
                }
            }

            public void RemoveAt(int index) => _items.RemoveAt(index);
            public void CopyTo(Array array, int index) => ((ICollection)_items).CopyTo(array, index);
            public IEnumerator GetEnumerator() => _items.GetEnumerator();
        }

        public MenuItemCollection MenuItems { get; }

        public Menu()
        {
            MenuItems = new MenuItemCollection(this);
        }

        public virtual MainMenu GetMainMenu() => this as MainMenu ?? Parent?.GetMainMenu();

        internal Menu Parent { get; set; }

        public object InternalParent { get; set; }
    }

    public class MainMenu : Menu
    {
        public MainMenu()
        {
        }

        public MainMenu(params MenuItem[] items)
            : this()
        {
            foreach (var item in items)
            {
                MenuItems.Add(item);
            }
        }

        public Form Form { get; set; }

        public Form GetForm() => Form;
    }

    public class ContextMenu : Menu
    {
        public ContextMenu()
        {
        }

        public ContextMenu(params MenuItem[] items)
            : this()
        {
            foreach (var item in items)
            {
                MenuItems.Add(item);
            }
        }

        public ContextMenu(Component owner)
            : this()
        {
            _ = owner;
        }

        public virtual void Show(Control control, Point pos)
        {
            _ = control;
            _ = pos;
        }

        public virtual void Show(Control control, Point pos, LeftRightAlignment alignment)
        {
            _ = control;
            _ = pos;
            _ = alignment;
        }
    }

    public class MenuItem : Menu
    {
        public MenuItem()
        {
        }

        public MenuItem(string text)
        {
            Text = text;
        }

        public bool OwnerDraw { get; set; }
        public bool DefaultItem { get; set; }
        public bool BarBreak { get; set; }
        public bool Checked { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Visible { get; set; } = true;
        public Shortcut Shortcut { get; set; } = Shortcut.None;
        public bool ShowShortcut { get; set; } = true;
        public bool RadioCheck { get; set; }
        public string Text { get; set; } = string.Empty;
        public object Tag { get; set; }
        public int Index { get; set; }
        public bool IsParent => MenuItems.Count > 0;

        public new Menu Parent { get; internal set; }

        public event EventHandler Click;
        public event DrawItemEventHandler DrawItem;
        public event MeasureItemEventHandler MeasureItem;

        internal void RaiseClick() => Click?.Invoke(this, EventArgs.Empty);
        internal void RaiseDrawItem(DrawItemEventArgs e) => DrawItem?.Invoke(this, e);
        internal void RaiseMeasureItem(MeasureItemEventArgs e) => MeasureItem?.Invoke(this, e);
    }

    public enum ToolBarAppearance
    {
        Normal = 0,
        Flat = 1
    }

    public enum ToolBarTextAlign
    {
        Underneath = 0,
        Right = 1
    }

    public enum ToolBarButtonStyle
    {
        PushButton = 1,
        ToggleButton = 2,
        Separator = 3,
        DropDownButton = 4
    }

    public delegate void ToolBarButtonClickEventHandler(object sender, ToolBarButtonClickEventArgs e);

    public class ToolBarButtonClickEventArgs : EventArgs
    {
        public ToolBarButtonClickEventArgs(ToolBarButton button)
        {
            Button = button;
        }

        public ToolBarButton Button { get; }
    }

    public class ToolBarButton : Component
    {
        public ToolBar Parent { get; internal set; }
        public ToolBarButtonStyle Style { get; set; }
        public Image Image { get; set; }
        public string ImageKey { get; set; } = string.Empty;
        public int ImageIndex { get; set; } = -1;
        public string ToolTipText { get; set; } = string.Empty;
        public bool Pushed { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Visible { get; set; } = true;
        public string Text { get; set; } = string.Empty;
        public object Tag { get; set; }
    }

    public class ToolBar : Control
    {
        public class ToolBarButtonCollection : IList
        {
            private readonly List<ToolBarButton> _items = new List<ToolBarButton>();
            private readonly ToolBar _owner;

            internal ToolBarButtonCollection(ToolBar owner)
            {
                _owner = owner;
            }

            public int Count => _items.Count;
            public bool IsReadOnly => false;
            public bool IsFixedSize => false;
            public bool IsSynchronized => false;
            public object SyncRoot => ((ICollection)_items).SyncRoot;

            public ToolBarButton this[int index]
            {
                get => _items[index];
                set
                {
                    _items[index] = value;
                    value.Parent = _owner;
                }
            }

            object IList.this[int index]
            {
                get => this[index];
                set => this[index] = (ToolBarButton)value;
            }

            public int Add(object value)
            {
                var item = (ToolBarButton)value;
                item.Parent = _owner;
                _items.Add(item);
                return _items.Count - 1;
            }

            public void Clear() => _items.Clear();
            public bool Contains(object value) => value is ToolBarButton item && _items.Contains(item);
            public int IndexOf(object value) => value is ToolBarButton item ? _items.IndexOf(item) : -1;

            public void Insert(int index, object value)
            {
                var item = (ToolBarButton)value;
                item.Parent = _owner;
                _items.Insert(index, item);
            }

            public void Remove(object value)
            {
                if (value is ToolBarButton item)
                {
                    _items.Remove(item);
                }
            }

            public void RemoveAt(int index) => _items.RemoveAt(index);
            public void CopyTo(Array array, int index) => ((ICollection)_items).CopyTo(array, index);
            public IEnumerator GetEnumerator() => _items.GetEnumerator();
        }

        public ToolBar()
        {
            Buttons = new ToolBarButtonCollection(this);
        }

        public ToolBarAppearance Appearance { get; set; }
        public ToolBarTextAlign TextAlign { get; set; }
        public Size ButtonSize { get; set; }
        public ImageList ImageList { get; set; }
        public ToolBarButtonCollection Buttons { get; }

        public event ToolBarButtonClickEventHandler ButtonClick;

        internal void RaiseButtonClick(ToolBarButton button) => ButtonClick?.Invoke(this, new ToolBarButtonClickEventArgs(button));
    }

    public enum StatusBarPanelAutoSize
    {
        None = 0,
        Spring = 1,
        Contents = 2
    }

    public class StatusBarPanel : Component
    {
        public string Text { get; set; } = string.Empty;
        public int Width { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public StatusBarPanelAutoSize AutoSize { get; set; }
    }

    public class StatusBar : Control
    {
        public class StatusBarPanelCollection : IList
        {
            private readonly List<StatusBarPanel> _items = new List<StatusBarPanel>();

            public int Count => _items.Count;
            public bool IsReadOnly => false;
            public bool IsFixedSize => false;
            public bool IsSynchronized => false;
            public object SyncRoot => ((ICollection)_items).SyncRoot;

            public StatusBarPanel this[int index]
            {
                get => _items[index];
                set => _items[index] = value;
            }

            object IList.this[int index]
            {
                get => this[index];
                set => this[index] = (StatusBarPanel)value;
            }

            public int Add(object value)
            {
                _items.Add((StatusBarPanel)value);
                return _items.Count - 1;
            }

            public void Clear() => _items.Clear();
            public bool Contains(object value) => value is StatusBarPanel item && _items.Contains(item);
            public int IndexOf(object value) => value is StatusBarPanel item ? _items.IndexOf(item) : -1;
            public void Insert(int index, object value) => _items.Insert(index, (StatusBarPanel)value);
            public void Remove(object value)
            {
                if (value is StatusBarPanel item)
                {
                    _items.Remove(item);
                }
            }

            public void RemoveAt(int index) => _items.RemoveAt(index);
            public void CopyTo(Array array, int index) => ((ICollection)_items).CopyTo(array, index);
            public IEnumerator GetEnumerator() => _items.GetEnumerator();
        }

        public StatusBar()
        {
            Panels = new StatusBarPanelCollection();
        }

        public bool ShowPanels { get; set; }
        public StatusBarPanelCollection Panels { get; }
    }
}
