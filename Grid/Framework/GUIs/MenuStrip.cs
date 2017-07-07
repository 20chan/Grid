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
        public List<MenuStripItem> Items { get; private set; }

        public MenuStrip()
        {
            Items = new List<MenuStripItem>();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);

            Point itemSize = new Point();
            foreach (var item in Items)
                itemSize = new Point(Math.Max(itemSize.X, item.MinimalSize.X),
                                      Math.Max(itemSize.Y, item.MinimalSize.Y));

            Point currentPos = new Point(X, Y);
            // 일단 색은 하얀새으로
            FillRectangle(sb, new Rectangle(currentPos, new Point(itemSize.X * Items.Count, (itemSize.Y + 1) * Items.Count - 1)), Color.White);
            foreach(var item in Items)
            {
                // MenuStripItem 그리기
                Rectangle bound = new Rectangle(currentPos, itemSize);
                FillRectangle(sb, bound, item.BackColor);
                DrawString(sb, MenuStripItem.Font, item.Text, item.TextAlignment, bound, item.ForeColor, 0);
                currentPos += itemSize;
                currentPos.Y++; // 아이템간의 간격
            }
        }
    }
}
