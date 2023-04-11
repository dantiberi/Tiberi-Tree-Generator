using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiberiTreeGen
{
    public abstract class Drawable
    {
        public float xPos { get; set; }
        public float yPos { get; set; }

        public abstract void draw(GameTime gameTime, SpriteBatch sb);
        public abstract void update(GameTime gameTime);
        public abstract void load();
    }
}
