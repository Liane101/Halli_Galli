using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using Halli_Galli.Controls;

namespace Halli_Galli.States
{
    class OptionState : State
    {
        private List<Component> _components;
        public static bool screen;
        private SpriteFont schrift;
        public OptionState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            schrift = _content.Load<SpriteFont>("Fonts/Font");

            var buttonTexture = _content.Load<Texture2D>("img/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/File");

            var difficultyButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 480),
                Text = "Schwierigkeit"
            };

            difficultyButton.Click += DifficultyButton_Click;

            var fullScreenTrueButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 530),
                Text = "Vollbild: ein"
            };

            fullScreenTrueButton.Click += FullScreenTrueButton_Click;

            var fullScreenFalseButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 580),
                Text = "Vollbild: aus"
            };

            fullScreenFalseButton.Click += FullScreenFalseButton_Click;

            var backButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 630),
                Text = "Zurueck"
            };

            backButton.Click += back_Click;

            _components = new List<Component>
            {
                difficultyButton,
                fullScreenTrueButton,
                fullScreenFalseButton,
                backButton
            };
        }

        private void back_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        private void FullScreenFalseButton_Click(object sender, EventArgs e)
        {
            screen = false;
            Game1.change = true;
            _game.ChangeState(new OptionState(_game, _graphicsDevice, _content));
        }
        private void FullScreenTrueButton_Click(object sender, EventArgs e)
        {
            screen = true;
            Game1.change = true;
            _game.ChangeState(new OptionState(_game, _graphicsDevice, _content));
        }
        private void DifficultyButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new ChangeDifficultyState(_game, _graphicsDevice, _content));
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var item in _components)
            {
                item.Draw(gameTime, spriteBatch);
            }

            spriteBatch.DrawString(schrift, "Aktuelle Schwierigkeit: " + ChangeDifficultyState.schwierigkeit, new Vector2(1350, 980), Color.White);

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
