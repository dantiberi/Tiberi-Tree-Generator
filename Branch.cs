using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TiberiTreeGen
{
    public class Branch : Drawable
    {
        float length;
        float baseLength; // Triangle's bottom side length
        float angle; // Radians.

        Texture2D _texture;

        public Branch(bool isTrunk, Vector2 pos, SpriteBatch sb) {
            position = pos;

            length = Utility.randomInRange(15, 100);

            angle = !isTrunk ? angle = Utility.degreeToRadian(Utility.randomInRange(-135, 45)) : angle = 0f;

            baseLength = (float)(length * Math.Cos(angle));

            _texture = Utility.createSolidTexture(sb, Color.Green);

            Console.WriteLine($"Length: { length } Angle: { angle }");
        }

        private Vector2 calcBranchEndpoint()
        {
            float x = angle > Utility.degreeToRadian(90) ? position.X - length : position.X + length;
            float y = angle < Utility.degreeToRadian(90) ? position.Y - length : position.Y + length;

            float x1 = (float)(position.X + (x - position.X) * Math.Cos(angle) - (y - position.Y) * Math.Sin(angle));
            float y1 = (float)(position.Y + (x - position.X) * Math.Sin(angle) + (y - position.Y) * Math.Cos(angle));

            

            return new Vector2(x1, y1);
        }

        public override void draw(GameTime gameTime, SpriteBatch sb)
        {
            Utility.drawLine(sb, _texture, new Vector2(position.X, position.Y), calcBranchEndpoint());
        }

        public override void load()
        {
            throw new NotImplementedException();
        }

        public override void update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
