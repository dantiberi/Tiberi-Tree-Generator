using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TiberiTreeGen
{
    public class Branch : Drawable
    {
        float length;
        float baseLength; // Triangle's bottom side length
        float angle; // Radians.
        public Vector2 endPosition;
        int maxIterations;
        int iteration;
        float scale;

        Texture2D _texture;

        public Branch(bool isTrunk, int iteration, int maxIterations, Vector2 pos, SpriteBatch sb) {
            position = pos;
            this.iteration = iteration + 1;
            this.maxIterations = maxIterations;

            //this.scale = (((float)maxIterations - (float)this.iteration) / (float)this.maxIterations) * 2;
            this.scale = (((float)maxIterations - (float)this.iteration) / (float)this.maxIterations) * ( 0.002f * (float)sb.GraphicsDevice.DisplayMode.Width);
            length = Utility.RandomInRange(15, 100) * scale;

            angle = isTrunk ? Utility.DegreeToRadian(-45f) : Utility.DegreeToRadian(Utility.RandomInRange(-135, 45));

            baseLength = (float)(length * Math.Cos(angle));

            _texture = getBranchColor(isTrunk, sb, iteration, maxIterations);

            endPosition = calcBranchEndpoint();

            Main.addToRenderList(this);

            if (iteration < maxIterations) growBranches(sb, 3);
        }

        private Texture2D getBranchColor(bool isTrunk, SpriteBatch sb, int iteration, int maxIterations)
        {
            Texture2D output = Utility.CreateSolidTexture(sb, Color.Blue); 
            
            if (isTrunk)
            {
                output = Utility.CreateSolidTexture(sb, Color.Brown);
            }
            else if (iteration < maxIterations) //Middle branches
            {
                int colorSelector = Utility.RandomInRange(1, 3);
                switch (colorSelector)
                {
                    case 1:
                        output = Utility.CreateSolidTexture(sb, Color.DarkGreen);
                        break;
                    case 2:
                        output = Utility.CreateSolidTexture(sb, Color.OliveDrab);
                        break;
                    case 3:
                        output = Utility.CreateSolidTexture(sb, Color.DarkOliveGreen);
                        break;
                }
            }
            else //Last branch
            {
                output = Utility.CreateSolidTexture(sb, Color.ForestGreen);
            }

            return output;
        }

        private Vector2 calcBranchEndpoint()
        {
            float x = angle > Utility.DegreeToRadian(90) ? position.X - length : position.X + length;
            float y = angle < Utility.DegreeToRadian(90) ? position.Y - length : position.Y + length;

            float x1 = (float)(position.X + (x - position.X) * Math.Cos(angle) - (y - position.Y) * Math.Sin(angle));
            float y1 = (float)(position.Y + (x - position.X) * Math.Sin(angle) + (y - position.Y) * Math.Cos(angle));

            

            return new Vector2(x1, y1);
        }

        public void growBranches(SpriteBatch sb, int numberOfBranches)
        {
            for( int i = 0; i < numberOfBranches; i++ )
            {
                new Branch(false, iteration, maxIterations, endPosition, sb);
            }
        }

        public override void draw(GameTime gameTime, SpriteBatch sb)
        {
            Utility.DrawLine(sb, _texture, new Vector2(position.X, position.Y), endPosition, 3f);
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
