using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Grid.Framework.GUIs
{
    public abstract class Clickable : GUI
    {
        /// <summary>
        /// 마우스가 처음 UI의 범위 안에 들어왔는가
        /// </summary>
        public bool IsMouseEntered { get; private set; } = false;
        /// <summary>
        /// 마우스가 UI의 범위 위에서 움직였는가
        /// </summary>
        public bool IsMouseMoved { get; private set; } = false;
        /// <summary>
        /// 마우스가 UI의 범위 안에 있는가
        /// </summary>
        public bool IsMouseHover { get; private set; } = false;
        /// <summary>
        /// 마우스가 UI을 처음 눌렀는가
        /// </summary>
        public bool IsMouesDown { get; private set; } = false;
        /// <summary>
        /// 마우스가 UI에서 뗐는가
        /// </summary>
        public bool IsMouseUp { get; private set; } = false;
        /// <summary>
        /// 마우스가 막 UI의 범위를 벗어났는가
        /// </summary>
        public bool IsMouseLeaved { get; private set; } = false;
        /// <summary>
        /// 마우스가 UI를 클릭중인가
        /// </summary>
        public bool IsMouseClicking { get; private set; } = false;
        /// <summary>
        /// 마우스가 UI의 범위 안에서 스크롤
        /// </summary>
        public int MouseWheel { get; private set; } = 0;

        public override void HandleEvent()
        {

        }

        public abstract bool IsInRect(Point point);
        public virtual bool IsClicking()
            => Mouse.GetState().LeftButton == ButtonState.Pressed && IsInRect(Mouse.GetState().Position);
    }
}
