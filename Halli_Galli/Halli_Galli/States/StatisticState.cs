using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using Halli_Galli.Controls;

namespace Halli_Galli.States
{
    class StatisticState : State
    {
        private SpriteFont schrift;
        public static int anzStufen;
        private Texture2D treppchen2;
        private Texture2D treppchen3;
        private Texture2D treppchen4;
        private Texture2D spieler1;
        private Texture2D spieler2;
        private Texture2D spieler3;
        private Texture2D spieler4;

        public StatisticState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            schrift = _content.Load<SpriteFont>("Fonts/Font");
            treppchen2 = _content.Load<Texture2D>("img/treppchen2");
            treppchen3 = _content.Load<Texture2D>("img/treppchen3");
            treppchen4 = _content.Load<Texture2D>("img/treppchen4");
            spieler1 = _content.Load<Texture2D>("img/sieger1");
            spieler2 = _content.Load<Texture2D>("img/sieger2");
            spieler3 = _content.Load<Texture2D>("img/sieger3");
            spieler4 = _content.Load<Texture2D>("img/sieger4");
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            if(anzStufen == 2)
                spriteBatch.Draw(treppchen2, new Rectangle(0, 0, 1920, 1080), Color.White);

            else if(anzStufen == 3)
                spriteBatch.Draw(treppchen3, new Rectangle(0, 0, 1920, 1080), Color.White);

            else if (anzStufen == 4)
                spriteBatch.Draw(treppchen4, new Rectangle(0, 0, 1920, 1080), Color.White);

            spriteBatch.DrawString(schrift, $"Spieler {GameState.Spielerreinfolge[0]} hat gewonnen", new Vector2(960 - schrift.MeasureString("Spieler 2 hat gewonnen").X / 2, 300), Color.White);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
