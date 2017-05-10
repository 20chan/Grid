﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework
{
    public class GUI
    {
        public virtual void Draw(SpriteBatch sb) { }
        public virtual void HandleEvent() { }

        public static Texture2D DummyTexture;
    }
}