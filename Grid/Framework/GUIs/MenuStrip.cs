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
        public bool IsShown { get; set; } = false;
        public List<MenuStripItem> Items { get; private set; }
        private int _gapX = 2, _gapY = 2;

        public MenuStrip()
        {
            Items = new List<MenuStripItem>();

            if (MenuStripItem.Font == null)
                MenuStripItem.Font = GUIManager.DefaultFont;
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            if (!IsShown) return;

            var itemSize = new Point();
            foreach (var item in Items)
                itemSize = new Point(Math.Max(itemSize.X, item.MinimalSize.X),
                                     Math.Max(itemSize.Y, item.MinimalSize.Y));

            itemSize = new Point(itemSize.X + _gapX * 2, itemSize.Y + _gapY * 2);

            Point currentPos = new Point(X, Y);
            // 일단 색은 하얀색으로
            FillRectangle(sb, new Rectangle(currentPos, 
                new Point(itemSize.X + _gapX * 2, (itemSize.Y + _gapY) * Items.Count - _gapY)),
                Color.White);

            foreach(var item in Items)
            {
                // MenuStripItem 그리기
                Rectangle bound = new Rectangle(currentPos, itemSize);
                FillRectangle(sb, bound, item.BackColor);
                DrawString(sb, MenuStripItem.Font, item.Text, item.TextAlignment, bound, item.ForeColor, 0);
                currentPos.Y += itemSize.Y + _gapY;
            }
        }

        public override void HandleEvent()
        {
            base.HandleEvent();

            // TODO: 아이템들 마우스 호버시 포커스되게끔
        }
    }
}
