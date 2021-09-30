using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using Halli_Galli.Controls;

namespace Halli_Galli.States
{
    public class ChangeDifficultyState : State
    {
        public static string schwierigkeit = "mittel";
        public static int geschwindigkeit = 1000;
        private SpriteFont schrift;
        private List<Component> _components;
        private Texture2D logo;

        public ChangeDifficultyState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            schrift = _content.Load<SpriteFont>("Fonts/Font");
            logo = _content.Load<Texture2D>("img/Logo");

            var buttonTexture = _content.Load<Texture2D>("img/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/File");

            var easyButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 480),
                Text = "leicht"
            };

            easyButton.Click += EasyButton_Click;

            var middleButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 530),
                Text = "mittel"
            };

            middleButton.Click += MiddleButton_Click;

            var hardButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 580),
                Text = "schwer"
            };

            hardButton.Click += HardButton_Click;

            var backButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 630),
                Text = "Zurueck"
            };

            backButton.Click += back_Click;

            _components = new List<Component>
            {
                easyButton,
                middleButton,
                hardButton,
                backButton
            };
        }

        private void back_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new OptionState(_game, _graphicsDevice, _content));
        }
        private void HardButton_Click(object sender, EventArgs e)
        {
            schwierigkeit = "schwer";
            geschwindigkeit = 500;
        }
        private void MiddleButton_Click(object sender, EventArgs e)
        {
            schwierigkeit = "mittel";
            geschwindigkeit = 1000;
        }
        private void EasyButton_Click(object sender, EventArgs e)
        {
            schwierigkeit = "leicht";
            geschwindigkeit = 1500;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(schrift, "Aktuelle Schwierigkeit: " + schwierigkeit, new Vector2(1350, 980), Color.White);

            foreach (var item in _components)
            {
                item.Draw(gameTime, spriteBatch);
            }

            spriteBatch.Draw(logo, new Vector2(960 - logo.Width / 2, 240 - logo.Height / 2), Color.White);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in _components)
                item.Update(gameTime);
        }
    }
}
