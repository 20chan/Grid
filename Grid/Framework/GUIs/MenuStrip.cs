using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.GUIs
{
    public class MenuStrip : GUI
    {
        public bool IsShown { get; private set; } = false;

        public new int X { get => _head.X; set => _head.X = value; }
        public new int Y { get => _head.Y; set => _head.Y = value; }
        public new int Width { get => _head.Width; set => _head.Width = value; }
        public new int Height { get => _head.Height; set => _head.Height = value; }

        protected MenuStripItem _head;
        public List<MenuStripItem> Items => _head.SubItems;

        public bool IsSelected { get; private set; } = false;
        public bool IsCancled { get; private set; } = false;
        public MenuStripItem SelectedItem { get; private set; } = null;

        public MenuStrip(List<MenuStripItem> items = null)
        {
            _head = new MenuStripItem(">HEAD<", items ?? new List<MenuStripItem>(), true);

            if (MenuStripItem.Font == null)
                MenuStripItem.Font = GUIManager.DefaultFont;
        }

        public void Show(int x, int y)
        {
            IsShown = true;
            X = x; Y = y;
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            if (!IsShown) return;

            this.Bounds = _head.DrawItems(sb);
        }

        public override void HandleEvent()
        {
            base.HandleEvent();

            if (IsSelected) IsSelected = false;
            if (IsCancled) IsCancled = false;

            // TODO: Bounds가 아니라 SubItemBound 도 전부 검사해야함
            if (IsShown)
            {
                foreach (var item in Items)
                {
                    item.CheckFocus();
                }

                if (_head.IsFocusedItemExist())
                {

                    if (Scene.CurrentScene.IsLeftMouseUp)
                    {
                        int index = 0;
                        foreach (var item in Items)
                        {
                            if (item.Focused)
                            {
                                IsSelected = true;
                                SelectedItem = _head.GetLastFocusedItem();
                                IsShown = false;
                            }
                            index++;
                        }
                    }
                }
                else if (Scene.CurrentScene.IsLeftMouseDown)
                {
                    _head.Cancle();
                    IsCancled = true;
                    IsShown = false;
                }
            }
        }
    }
}
