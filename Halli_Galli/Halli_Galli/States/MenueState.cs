using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using Halli_Galli.Controls;

namespace Halli_Galli.States
{
    public class MenuState : State
    {
        private SpriteFont schrift;
        private Texture2D logo;
        private List<Component> _components;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            schrift = _content.Load<SpriteFont>("Fonts/Font");
            logo = _content.Load<Texture2D>("img/Logo");

            var buttonTexture = _content.Load<Texture2D>("img/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/File");
            var startGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 480),
                Text = "Spiel Starten"
            };

            startGameButton.Click += NewGameButton_Click;

            var helpButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 530),
                Text = "Hilfe"
            };

            helpButton.Click += HelpButton_Click;

            var optionButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 580),
                Text = "Optionen"
            };

            optionButton.Click += OptionButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 630),
                Text = "Exit"
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>
            {
                startGameButton,
                helpButton,
                optionButton,
                quitGameButton
            };
        }


        private void OptionButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new OptionState(_game, _graphicsDevice, _content));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
        private void HelpButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new HelpState(_game, _graphicsDevice, _content));
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new ChoosePlayerState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var item in _components)
            {
                item.Draw(gameTime, spriteBatch);
            }
            spriteBatch.DrawString(schrift, "Aktuelle Schwierigkeit: " + ChangeDifficultyState.schwierigkeit, new Vector2(1350, 980), Color.White);

            spriteBatch.Draw(logo, new Vector2(960 - logo.Width / 2, 240 - logo.Height / 2), Color.White);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Remove
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in _components)
                item.Update(gameTime);
        }
    }
}
