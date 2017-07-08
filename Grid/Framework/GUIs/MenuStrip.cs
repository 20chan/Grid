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
        public List<MenuStripItem> Items { get; private set; }
        private int _gapX = 3, _gapY = 3;

        public bool IsSelected { get; private set; } = false;
        public bool IsCancled { get; private set; } = false;
        public int SelectedIndex { get; private set; } = -1;

        public MenuStrip()
        {
            Items = new List<MenuStripItem>();

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

            var itemSize = new Point();
            foreach (var item in Items)
                itemSize = new Point(Math.Max(itemSize.X, item.MinimalSize.X),
                                     Math.Max(itemSize.Y, item.MinimalSize.Y));

            Point currentPos = new Point(X, Y);

            // 일단 색은 하얀색으로
            var rect = new Rectangle(currentPos, new Point(itemSize.X + _gapX * 2, (itemSize.Y + _gapY * 2) * Items.Count));
            this.Bounds = rect;
            FillRectangle(sb, rect, Color.White);

            foreach (var item in Items)
            {
                // MenuStripItem 그리기
                Rectangle bound = new Rectangle(currentPos.X + _gapX, currentPos.Y + _gapY, itemSize.X, itemSize.Y);
                item.Bounds = bound;
                FillRectangle(sb, bound, item.Focused ? item.FocusedBackColor : item.BackColor);
                DrawString(sb, MenuStripItem.Font, item.Text, item.TextAlignment, bound, item.ForeColor, 0);
                currentPos.Y += itemSize.Y + _gapY * 2;
            }
        }

        public override void HandleEvent()
        {
            base.HandleEvent();

            if (IsSelected) IsSelected = false;
            if (IsCancled) IsCancled = false;

            // TODO: 아이템들 마우스 호버시 포커스되게끔
            if (IsShown && Bounds.Contains(Scene.CurrentScene.MousePosition))
            {
                foreach (var item in Items)
                {
                    item.Focused = item.Bounds.Contains(Scene.CurrentScene.MousePosition);
                }

                if (Scene.CurrentScene.IsLeftMouseUp)
                {
                    int index = 0;
                    foreach (var item in Items)
                    {
                        if (item.Focused)
                        {
                            IsSelected = true;
                            SelectedIndex = index;
                            IsShown = false;
                        }
                        index++;
                    }
                }
            }
            else if (Scene.CurrentScene.IsLeftMouseDown)
            {
                IsCancled = true;
                IsShown = false;
            }
        }
    }
}
