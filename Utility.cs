using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiberiTreeGen
{
    public class Utility
    {
        static Random random;

        static float pi = 3.14159265359f;

        public Utility(int randomSeed)
        {
            //Utility.random = new Random(randomSeed);
            Utility.random = new Random();
        }

        public static int randomInRange(int min, int max)
        {
            return Utility.random.Next(min, max + 1);
        }

        public static float degreeToRadian(float degree)
        {
            return degree * (pi / 180);
        }

        public static float radianToDegree(float radian)
        {
            return (radian * 180) / pi;
        }

        public static void drawLine(SpriteBatch sb, Texture2D texture, Vector2 start, Vector2 end, float thickness)
        {
            sb.Draw(texture, start, null, Color.White,
                             (float)Math.Atan2(end.Y - start.Y, end.X - start.X),
                             new Vector2(0f, (float)texture.Height / 2),
                             new Vector2(Vector2.Distance(start, end), thickness),
                             SpriteEffects.None, 0f);

        }

        public static Texture2D createSolidTexture(SpriteBatch sb, Color color)
        {
            Texture2D _texture;
            _texture = new Texture2D(sb.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { color });
            return _texture;
        }
    }
}
