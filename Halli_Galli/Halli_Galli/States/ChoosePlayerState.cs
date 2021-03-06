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
        private SpriteFont schrift;
        public static int player;
        private List<Component> _components;
        private Texture2D logo;


        public ChoosePlayerState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            schrift = _content.Load<SpriteFont>("Fonts/Font");
            logo = _content.Load<Texture2D>("img/Logo");

            var buttonTexture = _content.Load<Texture2D>("img/Button");
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
            GameState.Spieleranzahl = 2;
            StatisticState.anzStufen = 2;
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }
        private void Spieler3_Click(object sender, EventArgs e)
        {
            GameState.Spieleranzahl = 3;
            StatisticState.anzStufen = 3;
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void Spieler4_Click(object sender, EventArgs e)
        {
            GameState.Spieleranzahl = 4;
            StatisticState.anzStufen = 4;
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
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

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in _components)
                item.Update(gameTime);
        }
    }
}
