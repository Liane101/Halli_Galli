using Halli_Galli.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework.Content;

namespace Halli_Galli.States
{
    public class GameState : State
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
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
        private SpriteFont font;
        public static int player;
        public Player[] Spieler = new Player[player];
        private int counter;
        public int player1;
        public int player2;
        public int player3;
        public int player4;
        public int runde;
        public int rundeKarten;
        public bool start = true;
        private List<Card> Tisch = new List<Card>();

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

            //_spriteBatch = new SpriteBatch(GraphicsDevice);

            kartenrückseite = _content.Load<Texture2D>("img/Karten_Ruckseite");
            klingel = _content.Load<Texture2D>("img/Klingel");
            banane_1 = _content.Load<Texture2D>("img/Banane_1");
            banane_2 = _content.Load<Texture2D>("img/Banane_2");
            banane_3 = _content.Load<Texture2D>("img/Banane_3");
            banane_4 = _content.Load<Texture2D>("img/Banane_4");
            banane_5 = _content.Load<Texture2D>("img/Banane_5");
            erdbeere_1 = _content.Load<Texture2D>("img/Erdbeere_1");
            erdbeere_2 = _content.Load<Texture2D>("img/Erdbeere_2");
            erdbeere_3 = _content.Load<Texture2D>("img/Erdbeere_3");
            erdbeere_4 = _content.Load<Texture2D>("img/Erdbeere_4");
            erdbeere_5 = _content.Load<Texture2D>("img/Erdbeere_5");
            limette_1 = _content.Load<Texture2D>("img/Limette_1");
            limette_2 = _content.Load<Texture2D>("img/Limette_2");
            limette_3 = _content.Load<Texture2D>("img/Limette_3");
            limette_4 = _content.Load<Texture2D>("img/Limette_4");
            limette_5 = _content.Load<Texture2D>("img/Limette_5");
            pflaume_1 = _content.Load<Texture2D>("img/Pflaume_1");
            pflaume_2 = _content.Load<Texture2D>("img/Pflaume_2");
            pflaume_3 = _content.Load<Texture2D>("img/Pflaume_3");
            pflaume_4 = _content.Load<Texture2D>("img/Pflaume_4");
            pflaume_5 = _content.Load<Texture2D>("img/Pflaume_5");
            font = _content.Load<SpriteFont>("File");


            


        }


        public override void Update(GameTime gameTime)
        {

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();


            //Thread.Sleep(30);



            //base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            

            _spriteBatch.Begin();


            Texture2D[] Früchte = { banane_1,
                                    banane_2,
                                    banane_3,
                                    banane_4,
                                    banane_5,
                                    erdbeere_1,
                                    erdbeere_2,
                                    erdbeere_3,
                                    erdbeere_4,
                                    erdbeere_5,
                                    limette_1,
                                    limette_2,
                                    limette_3,
                                    limette_4,
                                    limette_5,
                                    pflaume_1,
                                    pflaume_2,
                                    pflaume_3,
                                    pflaume_4,
                                    pflaume_5
            };


            _spriteBatch.Draw(klingel, new Vector2(960 - (klingel.Width / 2), 540 - (klingel.Height / 2)), Color.White);

            Rectangle sourceRectangle = new Rectangle(0, 0, kartenrückseite.Width, kartenrückseite.Height);
            Vector2 origin = new Vector2(kartenrückseite.Width / 2, 2);

            if (player == 2)
            {
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 540 + 190), sourceRectangle, Color.White, 1.57f, origin, 1.0f, SpriteEffects.None, 1);
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 540 - 190), sourceRectangle, Color.White, 1.57f * 3, origin, 1.0f, SpriteEffects.None, 1);
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
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 1080 / 3), sourceRectangle, Color.White, 1.57f + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
                _spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 1080 / 3), sourceRectangle, Color.White, (1.57f * 3) - (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
            }



            if (player == 2)
            {
                if (runde > 0)
                    _spriteBatch.Draw(Früchte[player1], new Vector2(1920 / 4, 540), sourceRectangle, Color.White, 1.57f, origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 1)
                    _spriteBatch.Draw(Früchte[player2], new Vector2(1920 * 3 / 4, 540), sourceRectangle, Color.White, 1.57f * 3, origin, 1.0f, SpriteEffects.None, 1);
            }
            else if (player == 3)
            {
                if (runde > 0)
                    _spriteBatch.Draw(Früchte[player1], new Vector2(1920 / 4 + 120, 1080 * 2 / 3 + 120), sourceRectangle, Color.White, 1.57f / 2, origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 1)
                    _spriteBatch.Draw(Früchte[player3], new Vector2(1920 * 3 / 4 - 120, 1080 * 2 / 3 + 120), sourceRectangle, Color.White, (1.57f * 3) + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 2)
                    _spriteBatch.Draw(Früchte[player2], new Vector2(1920 / 2 - 170, 320), sourceRectangle, Color.White, 1.57f * 2, origin, 1.0f, SpriteEffects.None, 1);
            }
            else if (player == 4)
            {
                if (runde > 0)
                    _spriteBatch.Draw(Früchte[player1], new Vector2(1920 / 4 + 120, 1080 * 2 / 3 + 120), sourceRectangle, Color.White, 1.57f / 2, origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 3)
                    _spriteBatch.Draw(Früchte[player4], new Vector2(1920 * 3 / 4 - 120, 1080 * 2 / 3 + 120), sourceRectangle, Color.White, (1.57f * 3) + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 1)
                    _spriteBatch.Draw(Früchte[player2], new Vector2(1920 / 4 + 120, 1080 / 3 - 120), sourceRectangle, Color.White, 1.57f + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 2)
                    _spriteBatch.Draw(Früchte[player3], new Vector2(1920 * 3 / 4 - 120, 1080 / 3 - 120), sourceRectangle, Color.White, (1.57f * 3) - (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
            }

            _spriteBatch.DrawString(font, "" + Tisch.Count, new Vector2(900, 500), Color.Black);

            runde++;
            rundeKarten++;

            if (start)
            {

                Deck.FillDeck();
                Deck.ShuffleDeck();

                Card[] deck = Deck.Deckzurückgeben();



                for (int i = 0; i < Spieler.Length; i++)
                {
                    List<Card> Kartenliste = new List<Card>();

                    for (int k = 0; k < deck.Length / player; k++)
                    {
                        Kartenliste.Add(deck[k + (deck.Length / player * i)]);
                    }
                    Spieler[i] = new Player(Kartenliste);
                }

                start = false;
            }

            if (runde > 0)
            {
                Tisch.Insert(rundeKarten - 1, Spieler[runde % player].Karten[0]);
                Spieler[runde % player].Karten.RemoveAt(0);
            }








            if (player >= 2 && rundeKarten > 0)
            {
                player1 = 0;
                player1 += Tisch[0].Value - 1;

                if (Tisch[0].Fruit == "Erdbeere")
                    player1 += 5;
                if (Tisch[0].Fruit == "Limette")
                    player1 += 10;
                if (Tisch[0].Fruit == "Pflaume")
                    player1 += 15;

                if (rundeKarten > 1)
                {
                    player2 = 0;
                    player2 += Tisch[0].Value - 1;

                    if (Tisch[1].Fruit == "Erdbeere")
                        player2 += 5;
                    if (Tisch[1].Fruit == "Limette")
                        player2 += 10;
                    if (Tisch[1].Fruit == "Pflaume")
                        player2 += 15;
                }
            }
            if (player >= 3 && rundeKarten > 2)
            {
                player3 = 0;
                player3 += Tisch[2].Value - 1;

                if (Tisch[2].Fruit == "Erdbeere")
                    player3 += 5;
                if (Tisch[2].Fruit == "Limette")
                    player3 += 10;
                if (Tisch[2].Fruit == "Pflaume")
                    player3 += 15;
            }
            if (player >= 4 && rundeKarten > 3)
            {
                player4 = 0;
                player4 += Tisch[3].Value - 1;

                if (Tisch[3].Fruit == "Erdbeere")
                    player4 += 5;
                if (Tisch[3].Fruit == "Limette")
                    player4 += 10;
                if (Tisch[3].Fruit == "Pflaume")
                    player4 += 15;
            }

            if (rundeKarten == player)
                rundeKarten = 0;


            _spriteBatch.End();

            
        }

        public override void PostUpdate(GameTime gameTime)
        {
           
        }
    }
}
