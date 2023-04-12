using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace TiberiTreeGen
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch sb;

        Utility utility = new Utility(33);

        Branch trunk;

        private static List<Drawable> toRender = new List<Drawable>();

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public static void addToRenderList(Drawable element)
        {
            toRender.Add(element);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            //_graphics.ToggleFullScreen();
            _graphics.PreferredBackBufferWidth = sb.GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = sb.GraphicsDevice.DisplayMode.Height;
            _graphics.ApplyChanges();

            
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);

            generateNewTrunk();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                generateNewTrunk();
                Thread.Sleep(10);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            sb.Begin();

            // TODO: Add your drawing code here
            foreach (Drawable element in toRender)
            {
                element.draw(gameTime, sb);
            }

            base.Draw(gameTime);

            sb.End();
        }

        public void generateNewTrunk()
        {
            //Clear existing branches from memory
            for(int i = 0; i < toRender.Count; i++)
            {
                toRender[i] = null;
            }
            toRender.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //Generate new tree
            trunk = new Branch(true, 0, 7, new Vector2(sb.GraphicsDevice.PresentationParameters.Bounds.Width / 2, sb.GraphicsDevice.PresentationParameters.Bounds.Height), sb);
        }
    }
}