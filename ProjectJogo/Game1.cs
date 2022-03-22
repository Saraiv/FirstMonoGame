using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectJogo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyboardManager km;
        private Texture2D t2d;
        private Rectangle screenRectangle;
        private Rectangle luigiRectangle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            km = new KeyboardManager();
            screenRectangle = new Rectangle(0, 0, 800, 480);

            luigiRectangle.X = 120;
            luigiRectangle.Y = 40;

            luigiRectangle.Width = screenRectangle.Width / 2 - luigiRectangle.Width / 2; 
            luigiRectangle.Height = screenRectangle.Height / 2 - luigiRectangle.Height / 2;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            t2d = Content.Load<Texture2D>("Luigi");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            km.Update();
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                luigiRectangle.X++;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                luigiRectangle.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                luigiRectangle.Y++;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                luigiRectangle.Y--;
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(t2d, luigiRectangle, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
