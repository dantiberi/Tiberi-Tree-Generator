using Microsoft.Xna.Framework;
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

        public abstract void draw(GameTime gameTime);
        public abstract void update(GameTime gameTime);
        public abstract void load();
    }
}
