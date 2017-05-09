using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework
{
    public class GUIManager : Component
    {
        public List<GUI> GUIs { get; private set; }
        public GUIManager()
        {
            GUIs = new List<GUI>();
        }

        public void Draw(SpriteBatch sb)
        {
            // TODO: GUI 그리기 (..)
            throw new NotImplementedException();
        }

        public void HandleEvent()
        {
            // TODO: 버튼을 클릭했는지 텍스트박스에 입력했는지 등의 각 GUI들의 모든 이벤트 처리
            throw new NotImplementedException();
        }
    }
}
