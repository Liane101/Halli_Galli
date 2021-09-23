using Halli_Galli.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Halli_Galli.States
{
    public class HelpState : State
    {
        private List<Component> _back;
        private List<Component> _forward;
        private List<Component> _newGame;
        private Texture2D Hilfe1;
        private Texture2D Hilfe2;
        private Texture2D Hilfe3;
        private int Seite = 1;
        public HelpState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Hilfe1 = _content.Load<Texture2D>("img/Hilfe Seite 1");
            Hilfe2 = _content.Load<Texture2D>("img/Hilfe Seite 2");
            Hilfe3 = _content.Load<Texture2D>("img/Hilfe Seite 3");

            var buttonTexture = _content.Load<Texture2D>("img/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/File");
            var forwardButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1700, 950),
                Text = "weiter"
            };

            forwardButton.Click += forward_Click;

            var backButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1530, 950),
                Text = "Zurueck"
            };

            backButton.Click += back_Click;

            _back = new List<Component>
            {
                backButton
            };

            _forward = new List<Component>
            {
                forwardButton
            };

        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new ChoosePlayerState(_game, _graphicsDevice, _content));
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (Seite > 1)
                Seite--;
            else
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }
        private void forward_Click(object sender, EventArgs e)
        {
            if (Seite <= 2)
                Seite++;
            else
                Seite += 0;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var item in _back)
            {
                item.Draw(gameTime, spriteBatch);
            }

            if (Seite == 1)
            {
                spriteBatch.Draw(Hilfe1, new Rectangle(0, 0, 1920, 1080), Color.White);
                foreach (var item in _forward)
                {
                    item.Draw(gameTime, spriteBatch);
                }
            }

            if (Seite == 2)
            {
                spriteBatch.Draw(Hilfe2, new Rectangle(0, 0, 1920, 1080), Color.White);
                foreach (var item in _forward)
                {
                    item.Draw(gameTime, spriteBatch);
                }
            }

            if (Seite == 3)
            {
                spriteBatch.Draw(Hilfe3, new Rectangle(0, 0, 1920, 1080), Color.White);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in _back)
                item.Update(gameTime);
            foreach(var item in _forward)
                item.Update(gameTime);
        }
    }
}
