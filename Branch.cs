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
        float angle; // Radians. 90 = straight up

        Texture2D _texture;

        public Branch(bool isTrunk, SpriteBatch sb) { 
            xPos = 200; yPos = 200;

            length = Utility.randomInRange(15, 200);
            baseLength = (float)(length * Math.Cos(angle));

            angle = !isTrunk ? angle = Utility.degreeToRadian(Utility.randomInRange(0, 180)) : angle = 0f;

            _texture = Utility.createSolidTexture(sb, Color.Green);

            Console.WriteLine($"Length: { length } Angle: { angle }");
        }

        private Vector2 calcBranchEndpoint()
        {
            float x = angle > Utility.degreeToRadian(90) ? xPos - length : xPos + length;
            float y = angle < Utility.degreeToRadian(90) ? yPos - length : yPos + length;

            float x1 = (float)(xPos + (x - xPos) * Math.Cos(angle) - (y - yPos) * Math.Sin(angle));
            float y1 = (float)(yPos + (x - xPos) * Math.Sin(angle) + (y - yPos) * Math.Cos(angle));

            return new Vector2(x1, y1);
        }

        public override void draw(GameTime gameTime, SpriteBatch sb)
        {
            Utility.drawLine(sb, _texture, new Vector2(xPos, yPos), calcBranchEndpoint());
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
