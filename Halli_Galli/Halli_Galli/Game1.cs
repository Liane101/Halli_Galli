using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Halli_Galli
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D background;
        private Texture2D kartenrückseite;
        private Texture2D klingel;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("img/Tisch");
            kartenrückseite = Content.Load<Texture2D>("img/Karten_Ruckseite");
            klingel = Content.Load<Texture2D>("img/Klingel");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(background, new Rectangle(0, 0, 960, 540), Color.White);
            _spriteBatch.Draw(background, new Rectangle(960, 0, 960, 540), Color.White);
            _spriteBatch.Draw(background, new Rectangle(0, 540, 960, 540), Color.White);
            _spriteBatch.Draw(background, new Rectangle(960, 540, 960, 540), Color.White);

            _spriteBatch.Draw(klingel, new Vector2(960 - (klingel.Width/2), 540 - (klingel.Height/2)), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
