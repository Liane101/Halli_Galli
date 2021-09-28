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
            spieler1 = _content.Load<Texture2D>("img/P1_4x");
            spieler2 = _content.Load<Texture2D>("img/P2_4x");
            spieler3 = _content.Load<Texture2D>("img/P3_4x");
            spieler4 = _content.Load<Texture2D>("img/P4_4x");
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            Texture2D[] spieler = { spieler1, spieler2, spieler3, spieler4 };


            if(anzStufen == 2)
            { 
                spriteBatch.Draw(treppchen2, new Rectangle(0, 0, 1920, 1080), Color.White);

                spriteBatch.Draw(spieler[GameState.Spielerreinfolge[0] - 1], new Vector2(990,300), Color.White);
                spriteBatch.Draw(spieler[GameState.Spielerreinfolge[1] - 1], new Vector2(670, 400), Color.White);

            }
            else if(anzStufen == 3)
            { 
                spriteBatch.Draw(treppchen3, new Rectangle(0, 0, 1920, 1080), Color.White);

                spriteBatch.Draw(spieler[GameState.Spielerreinfolge[0] - 1], new Vector2(850, 300), Color.White);
                spriteBatch.Draw(spieler[GameState.Spielerreinfolge[1] - 1], new Vector2(550, 400), Color.White);
                spriteBatch.Draw(spieler[GameState.Spielerreinfolge[2] - 1], new Vector2(1160, 500), Color.White);
            }
            else if (anzStufen == 4)
            { 
                spriteBatch.Draw(treppchen4, new Rectangle(0, 0, 1920, 1080), Color.White);

                spriteBatch.Draw(spieler[GameState.Spielerreinfolge[0] - 1], new Vector2(850, 300), Color.White);
                spriteBatch.Draw(spieler[GameState.Spielerreinfolge[1] - 1], new Vector2(550, 400), Color.White);
                spriteBatch.Draw(spieler[GameState.Spielerreinfolge[2] - 1], new Vector2(1160, 500), Color.White);
                spriteBatch.Draw(spieler[GameState.Spielerreinfolge[3] - 1], new Vector2(1490, 695), Color.White);
            }


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
