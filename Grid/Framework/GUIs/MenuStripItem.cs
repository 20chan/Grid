using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.GUIs
{
    public class MenuStripItem : GUI
    {
        private static readonly int _gapX = 3, _gapY = 3;
        private static readonly int _itemSizeIndent = 30;

        public static SpriteFont Font;
        private string _text;
        public bool IsHead { get; private set; }
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                _minimalSize = MeasureFontSize(Font, _text).ToPoint();
            }
        }
        public Alignment TextAlignment { get; set; } = Alignment.Left;
        public Color ForeColor { get; set; } = Color.Black;
        public Color BackColor { get; set; } = Color.Snow;
        public Color FocusedBackColor { get; set; } = Color.SkyBlue;
        public bool Focused { get; internal set; } = false;
        private Point _minimalSize;
        public Point MinimalSize => _minimalSize;

        public Rectangle SubItemRect { get; private set; } = new Rectangle();
        public List<MenuStripItem> SubItems { get; private set; }

        public MenuStripItem(string text, List<MenuStripItem> subItems = null, bool isHead = false)
        {
            IsHead = isHead;
            if (IsHead)
                _text = text;
            else
                Text = text;
            SubItems = subItems ?? new List<MenuStripItem>();
        }
        
        /// <summary>
        /// 아이템들을 그리고 전체 Bounds를 리턴함
        /// </summary>
        public Rectangle DrawItems(SpriteBatch sb)
        {
            var itemSize = new Point();
            foreach (var item in SubItems)
                itemSize = new Point(Math.Max(itemSize.X, item.MinimalSize.X),
                                     Math.Max(itemSize.Y, item.MinimalSize.Y));

            itemSize.X += _itemSizeIndent;

            Point currentPos = new Point(X + Width, Y);

            // 일단 색은 하얀색으로
            var rect = new Rectangle(currentPos, new Point(itemSize.X + _gapX * 2, (itemSize.Y + _gapY * 2) * SubItems.Count));
            FillRectangle(sb, rect, Color.White);

            foreach (var item in SubItems)
            {
                // MenuStripItem 그리기
                Rectangle bound = new Rectangle(currentPos.X + _gapX, currentPos.Y + _gapY, itemSize.X, itemSize.Y);
                item.Bounds = new Rectangle(currentPos.X, currentPos.Y, _gapX * 2 + itemSize.X, _gapY * 2 + itemSize.Y);
                FillRectangle(sb, bound, item.Focused ? item.FocusedBackColor : item.BackColor);
                DrawString(sb, Font, item.Text, item.TextAlignment, bound, item.ForeColor, 0);

                if (item.SubItems.Count > 0)
                {
                    DrawString(sb, Font, ">", Alignment.Right, bound, item.ForeColor, 0);
                    if (item.Focused)
                        item.SubItemRect = item.DrawItems(sb);
                }
                currentPos.Y += itemSize.Y + _gapY * 2;
            }

            return rect;
        }

        public void CheckFocus()
        {
            if (Focused)
            {
                if (IsSubItemsFocused())
                {
                    foreach (var item in SubItems)
                        item.CheckFocus();
                    return;
                }
                else
                {
                    Cancle();
                }
            }
            Focused = Bounds.Contains(Scene.CurrentScene.MousePosition);
        }

        public bool IsSubItemsFocused()
            => SubItems.Count > 0
            && (SubItemRect.Contains(Scene.CurrentScene.MousePosition)
                || (from sub in SubItems
                    select sub.IsSubItemsFocused()).Any(b => b));

        public MenuStripItem GetLastFocusedItem()
            => SubItems.Count == 0 ? this : SubItems.FindLast(i => i.Focused)?.GetLastFocusedItem() ?? this;

        public void Cancle()
        {
            Focused = false;
            foreach (var sub in SubItems)
                sub.Cancle();
        }

        public bool IsFocusedItemExist()
            => SubItems.Any(item => item.Focused);
    }
}
