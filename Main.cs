using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TiberiTreeGen
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch sb;

        Utility utility = new Utility(33);

        Branch branch;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
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
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            sb.Begin();

            // TODO: Add your drawing code here
            branch.draw(gameTime, sb);

            base.Draw(gameTime);

            sb.End();
        }

        public void generateNewTrunk()
        {
            branch = new Branch(false, new Vector2(sb.GraphicsDevice.PresentationParameters.Bounds.Width / 2, sb.GraphicsDevice.PresentationParameters.Bounds.Height), sb);
        }
    }
}