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
        private Texture2D banane_1;
        private Texture2D banane_2;
        private Texture2D banane_3;
        private Texture2D banane_4;
        private Texture2D banane_5;
        private Texture2D erdbeere_1;
        private Texture2D erdbeere_2;
        private Texture2D erdbeere_3;
        private Texture2D erdbeere_4;
        private Texture2D erdbeere_5;
        private Texture2D limette_1;
        private Texture2D limette_2;
        private Texture2D limette_3;
        private Texture2D limette_4;
        private Texture2D limette_5;
        private Texture2D pflaume_1;
        private Texture2D pflaume_2;
        private Texture2D pflaume_3;
        private Texture2D pflaume_4;
        private Texture2D pflaume_5;
        private float angle = 0.0f;
        private int player = 4;

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
            banane_1 = Content.Load<Texture2D>("img/Banane_1");
            banane_2 = Content.Load<Texture2D>("img/Banane_2");
            banane_3 = Content.Load<Texture2D>("img/Banane_3");
            banane_4 = Content.Load<Texture2D>("img/Banane_4");
            banane_5 = Content.Load<Texture2D>("img/Banane_5");
            erdbeere_1 = Content.Load<Texture2D>("img/Erdbeere_1");
            erdbeere_2 = Content.Load<Texture2D>("img/Erdbeere_2");
            erdbeere_3 = Content.Load<Texture2D>("img/Erdbeere_3");
            erdbeere_4 = Content.Load<Texture2D>("img/Erdbeere_4");
            erdbeere_5 = Content.Load<Texture2D>("img/Erdbeere_5");
            limette_1 = Content.Load<Texture2D>("img/Limette_1");
            limette_2 = Content.Load<Texture2D>("img/Limette_2");
            limette_3 = Content.Load<Texture2D>("img/Limette_3");
            limette_4 = Content.Load<Texture2D>("img/Limette_4");
            limette_5 = Content.Load<Texture2D>("img/Limette_5");
            pflaume_1 = Content.Load<Texture2D>("img/Pflaume_1");
            pflaume_2 = Content.Load<Texture2D>("img/Pflaume_2");
            pflaume_3 = Content.Load<Texture2D>("img/Pflaume_3");
            pflaume_4 = Content.Load<Texture2D>("img/Pflaume_4");
            pflaume_5 = Content.Load<Texture2D>("img/Pflaume_5");
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

            Rectangle sourceRectangle = new Rectangle(0, 0, kartenrückseite.Width, kartenrückseite.Height);
            Vector2 origin = new Vector2(kartenrückseite.Width / 2, 2);

            if (player == 2)
            {
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 540), sourceRectangle, Color.White, 1.57f, origin, 1.0f, SpriteEffects.None, 1);
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 540), sourceRectangle, Color.White, 1.57f * 3, origin, 1.0f, SpriteEffects.None, 1);
            }
            else if (player == 3)
            {
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 1080 * 2 / 3), sourceRectangle, Color.White, 1.57f / 2, origin, 1.0f, SpriteEffects.None, 1);
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 1080 * 2 / 3), sourceRectangle, Color.White, (1.57f * 3) + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 2, 320), sourceRectangle, Color.White, 1.57f * 2, origin, 1.0f, SpriteEffects.None, 1);
            }
            else if (player == 4)
            {
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 1080 * 2 / 3), sourceRectangle, Color.White, 1.57f / 2, origin, 1.0f, SpriteEffects.None, 1);
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 1080 * 2 / 3), sourceRectangle, Color.White, (1.57f * 3) + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 1080  / 3), sourceRectangle, Color.White, 1.57f + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 1080 / 3), sourceRectangle, Color.White, (1.57f * 3) - (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
