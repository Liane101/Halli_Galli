using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Halli_Galli.Controls;

namespace Halli_Galli.States
{
    public class ChoosePlayerState : State
    {
        private List<Component> _components;

        public ChoosePlayerState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/File");
            var spieler2Button = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 480),
                Text = "2 Spieler"
            };

            spieler2Button.Click += Spieler2_Click;

            var spieler3Button = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 530),
                Text = "3 Spieler"
            };

            spieler3Button.Click += Spieler3_Click;

            var spieler4Button = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 580),
                Text = "4 Spieler"
            };

            spieler4Button.Click += Spieler4_Click;

            var backButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(880, 630),
                Text = "Zurueck"
            };

            backButton.Click += back_Click;

            _components = new List<Component>
            {
                spieler2Button,
                spieler3Button,
                spieler4Button,
                backButton
            };
        }

        private void back_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }
        private void Spieler2_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }
        private void Spieler3_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void Spieler4_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var item in _components)
            {
                item.Draw(gameTime, spriteBatch);
            }

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
