using Halli_Galli.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework.Content;
using Halli_Galli.Controls;

namespace Halli_Galli.States
{
    public class GameState : State
    {
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
        private static readonly TimeSpan intervalBetweenAttack = TimeSpan.FromMilliseconds(500);
        private TimeSpan lastTimeAttack;
        public int runde;
        public int rundeKarten;
        private bool geklingelt = false;
        public bool start = true;
        public bool nextCard = false;
        private List<Card> Tisch = new List<Card>();
        private List<Component> _Buttons12;
        private List<Component> _Button3;
        private List<Component> _Button4;
        private Texture2D leertaste;
        private Vector2 button1;
        private Vector2 button2;
        private Vector2 button3;
        private Vector2 button4;
        private SpriteFont font1;
        private Texture2D Schatten;


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

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
            leertaste = _content.Load<Texture2D>("img/Leertaste");
            font1 = _content.Load<SpriteFont>("Fonts/Font");
            Schatten = _content.Load<Texture2D>("img/Schatten");

            var buttonTexture = _content.Load<Texture2D>("img/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/File");

            if (player == 2)
            {
                button1 = new Vector2(275, 410);
                button2 = new Vector2(1490, 627);
            }

            if (player == 3)
            {
                button1 = new Vector2(342, 620);
                button2 = new Vector2(880, 323);
                button3 = new Vector2(1420, 620);
            }

            if (player == 4)
            {
                button1 = new Vector2(350, 627);
                button2 = new Vector2(350, 415);
                button3 = new Vector2(1415, 415);
                button4 = new Vector2(1415, 627);
            }

            var spieler1Button = new Button(buttonTexture, buttonFont)
            {
                Position = button1,
                Text = "Spieler 1"
            };

            spieler1Button.Click += Spieler1_Click;

            var spieler2Button = new Button(buttonTexture, buttonFont)
            {
                Position = button2,
                Text = "Spieler 2"
            };

            spieler2Button.Click += Spieler2_Click;

            var spieler3Button = new Button(buttonTexture, buttonFont)
            {
                Position = button3,
                Text = "Spieler 3"
            };

            spieler3Button.Click += Spieler3_Click;

            var spieler4Button = new Button(buttonTexture, buttonFont)
            {
                Position = button4,
                Text = "Spieler 4"
            };

            spieler4Button.Click += Spieler4_Click;

            _Buttons12 = new List<Component>
            {
                spieler1Button,
                spieler2Button,
            };
            _Button3 = new List<Component>
            {
                spieler3Button,
            };
            _Button4 = new List<Component>
            {
                spieler4Button,
            };


        }

        private void Spieler1_Click(object sender, EventArgs e)
        {
            if (Deck.Check(Tisch, player))
            {
                int count = Tisch.Count;

                for (int l = 0; l < count; l++)
                {
                    Spieler[1].Karten.Insert(0, Tisch[0]);
                    Tisch.RemoveAt(0);
                }
                
                runde = 0;
                rundeKarten = 0;

                player1 = 0;
                player2 = 0;
                player3 = 0;
                player4 = 0;
            }
            else
            {
                if (player >= 2)
                {
                    Spieler[2].Karten.Insert(0, Spieler[1].Karten[0]);
                    Spieler[1].Karten.RemoveAt(0);
                }


                if (player >= 3)
                {
                    Spieler[3].Karten.Insert(0, Spieler[1].Karten[0]);
                    Spieler[1].Karten.RemoveAt(0);
                }

                if (player >= 4)
                {
                    Spieler[0].Karten.Insert(0, Spieler[1].Karten[0]);
                    Spieler[1].Karten.RemoveAt(0);
                }
            }
            geklingelt = false;
        }
        private void Spieler2_Click(object sender, EventArgs e)
        {
            if (Deck.Check(Tisch, player))
            {
                int count = Tisch.Count;

                for (int l = 0; l < count; l++)
                {
                    Spieler[2].Karten.Insert(0, Tisch[0]);
                    Tisch.RemoveAt(0);
                }
                
                runde = 0;
                rundeKarten = 0;

                player1 = 0;
                player2 = 0;
                player3 = 0;
                player4 = 0;
            }
            else
            {
                if (player >= 2)
                {
                    Spieler[1].Karten.Insert(0, Spieler[2].Karten[0]);
                    Spieler[2].Karten.RemoveAt(0);
                }

                if (player >= 3)
                {
                    Spieler[3].Karten.Insert(0, Spieler[2].Karten[0]);
                    Spieler[2].Karten.RemoveAt(0);
                }

                if (player >= 4)
                {
                    Spieler[0].Karten.Insert(0, Spieler[2].Karten[0]);
                    Spieler[2].Karten.RemoveAt(0);
                }
            }
            geklingelt = false;
        }
        private void Spieler3_Click(object sender, EventArgs e)
        {
            if (Deck.Check(Tisch, player))
            {
                int count = Tisch.Count;

                for (int l = 0; l < count; l++)
                {
                    Spieler[3].Karten.Insert(0, Tisch[0]);
                    Tisch.RemoveAt(0);
                }
               
                runde = 0;
                rundeKarten = 0;

                player1 = 0;
                player2 = 0;
                player3 = 0;
                player4 = 0;
            }
            else
            {

                    

                if (player >= 3)
                {
                    Spieler[2].Karten.Insert(0, Spieler[3].Karten[0]);
                    Spieler[3].Karten.RemoveAt(0);

                    Spieler[1].Karten.Insert(0, Spieler[3].Karten[0]);
                    Spieler[3].Karten.RemoveAt(0);
                }

                if (player >= 4)
                {
                    Spieler[0].Karten.Insert(0, Spieler[3].Karten[0]);
                    Spieler[3].Karten.RemoveAt(0);
                }
            }
            geklingelt = false;
        }

        private void Spieler4_Click(object sender, EventArgs e)
        {
            if (Deck.Check(Tisch, player))
            {
                int count = Tisch.Count;

                for (int l = 0; l < count; l++)
                {
                    Spieler[0].Karten.Insert(0, Tisch[0]);
                    Tisch.RemoveAt(0);
                }
               
                runde = 0;
                rundeKarten = 0;

                player1 = 0;
                player2 = 0;
                player3 = 0;
                player4 = 0;
            }
            else
            {
                Spieler[1].Karten.Insert(0, Spieler[0].Karten[0]);
                Spieler[0].Karten.RemoveAt(0);

                Spieler[2].Karten.Insert(0, Spieler[0].Karten[0]);
                Spieler[0].Karten.RemoveAt(0);

                Spieler[3].Karten.Insert(0, Spieler[0].Karten[0]);
                Spieler[0].Karten.RemoveAt(0);
            }
            geklingelt = false;
        }
        public override void Update(GameTime gameTime)
        {

            if (lastTimeAttack + intervalBetweenAttack < gameTime.TotalGameTime)
            {
                lastTimeAttack = gameTime.TotalGameTime;
                nextCard = true;
            }
                

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                geklingelt = true;

            foreach (var item in _Buttons12)
                item.Update(gameTime);

            foreach (var item in _Button3)
                item.Update(gameTime);

            foreach (var item in _Button4)
                item.Update(gameTime);
            //base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            

            spriteBatch.Begin();




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


            spriteBatch.Draw(klingel, new Vector2(960 - (klingel.Width / 2), 540 - (klingel.Height / 2)), Color.White);

            Rectangle sourceRectangle = new Rectangle(0, 0, kartenrückseite.Width, kartenrückseite.Height);
            Vector2 origin = new Vector2(kartenrückseite.Width / 2, 2);

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

            if (player == 2)
            {
                spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 540 + 190), sourceRectangle, Color.White, 1.57f, origin, 1.0f, SpriteEffects.None, 1);
                spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 540 - 190), sourceRectangle, Color.White, 1.57f * 3, origin, 1.0f, SpriteEffects.None, 1);
            }
            else if (player == 3)
            {
                spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 1080 * 2 / 3), sourceRectangle, Color.White, 1.57f / 2, origin, 1.0f, SpriteEffects.None, 1);
                spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 1080 * 2 / 3), sourceRectangle, Color.White, (1.57f * 3) + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
                spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 2, 320), sourceRectangle, Color.White, 1.57f * 2, origin, 1.0f, SpriteEffects.None, 1);
            }
            else if (player == 4)
            {
                spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 1080 * 2 / 3), sourceRectangle, Color.White, 1.57f / 2, origin, 1.0f, SpriteEffects.None, 1);
                spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 1080 * 2 / 3), sourceRectangle, Color.White, (1.57f * 3) + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
                spriteBatch.Draw(kartenrückseite, new Vector2(1920 / 4, 1080 / 3), sourceRectangle, Color.White, 1.57f + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
                spriteBatch.Draw(kartenrückseite, new Vector2(1920 * 3 / 4, 1080 / 3), sourceRectangle, Color.White, (1.57f * 3) - (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);
            }



            if (player == 2)
            {
                if (runde > 0)
                    spriteBatch.Draw(Früchte[player1], new Vector2(1920 / 4, 540), sourceRectangle, Color.White, 1.57f, origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 1)
                    spriteBatch.Draw(Früchte[player2], new Vector2(1920 * 3 / 4, 540), sourceRectangle, Color.White, 1.57f * 3, origin, 1.0f, SpriteEffects.None, 1);

                spriteBatch.Draw(Schatten, new Vector2(340 - 22, 705 - 25), Color.White);
                spriteBatch.Draw(Schatten, new Vector2(1560 - 22, 325 -25), Color.White);



                spriteBatch.DrawString(font1, Convert.ToString(Spieler[1].Karten.Count), new Vector2(340 + 17 - font.MeasureString(Convert.ToString(Spieler[1].Karten.Count)).X, 705), Color.Black);
                spriteBatch.DrawString(font1, Convert.ToString(Spieler[0].Karten.Count), new Vector2(1560 + 17 - font.MeasureString(Convert.ToString(Spieler[0].Karten.Count)).X, 325), Color.Black);
            }
            else if (player == 3)
            {
                if (runde > 0)
                    spriteBatch.Draw(Früchte[player1], new Vector2(1920 / 4 + 120, 1080 * 2 / 3 + 120), sourceRectangle, Color.White, 1.57f / 2, origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 2)
                    spriteBatch.Draw(Früchte[player3], new Vector2(1920 * 3 / 4 - 120, 1080 * 2 / 3 + 120), sourceRectangle, Color.White, (1.57f * 3) + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 1)
                    spriteBatch.Draw(Früchte[player2], new Vector2(1920 / 2 - 170, 320), sourceRectangle, Color.White, 1.57f * 2, origin, 1.0f, SpriteEffects.None, 1);

                spriteBatch.Draw(Schatten, new Vector2(390 - 22, 780 - 25), Color.White);
                spriteBatch.Draw(Schatten, new Vector2(950 - 22, 170 - 25), Color.White);
                spriteBatch.Draw(Schatten, new Vector2(1520 - 22, 780 - 25), Color.White);

                spriteBatch.DrawString(font1, Convert.ToString(Spieler[1].Karten.Count), new Vector2(390 + 17 - font.MeasureString(Convert.ToString(Spieler[1].Karten.Count)).X, 780), Color.Black);
                spriteBatch.DrawString(font1, Convert.ToString(Spieler[2].Karten.Count), new Vector2(950 + 17 - font.MeasureString(Convert.ToString(Spieler[2].Karten.Count)).X, 170), Color.Black);
                spriteBatch.DrawString(font1, Convert.ToString(Spieler[0].Karten.Count), new Vector2(1520 + 17 - font.MeasureString(Convert.ToString(Spieler[0].Karten.Count)).X, 780), Color.Black);

            }
            else if (player == 4)
            {
                if (runde > 0)
                    spriteBatch.Draw(Früchte[player1], new Vector2(1920 / 4 + 120, 1080 * 2 / 3 + 120), sourceRectangle, Color.White, 1.57f / 2, origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 3)
                    spriteBatch.Draw(Früchte[player4], new Vector2(1920 * 3 / 4 - 120, 1080 * 2 / 3 + 120), sourceRectangle, Color.White, (1.57f * 3) + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 1)
                    spriteBatch.Draw(Früchte[player2], new Vector2(1920 / 4 + 120, 1080 / 3 - 120), sourceRectangle, Color.White, 1.57f + (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);

                if (runde > 2)
                    spriteBatch.Draw(Früchte[player3], new Vector2(1920 * 3 / 4 - 120, 1080 / 3 - 120), sourceRectangle, Color.White, (1.57f * 3) - (1.57f / 2), origin, 1.0f, SpriteEffects.None, 1);

                spriteBatch.Draw(Schatten, new Vector2(390 - 22, 780 - 25), Color.White);
                spriteBatch.Draw(Schatten, new Vector2(390 - 22, 250 - 25), Color.White);
                spriteBatch.Draw(Schatten, new Vector2(1520 - 22, 250 - 25), Color.White);
                spriteBatch.Draw(Schatten, new Vector2(1520 - 22, 780 - 25), Color.White);

                spriteBatch.DrawString(font1, Convert.ToString(Spieler[1].Karten.Count), new Vector2(390 + 17 - font.MeasureString(Convert.ToString(Spieler[1].Karten.Count)).X, 780), Color.Black);
                spriteBatch.DrawString(font1, Convert.ToString(Spieler[2].Karten.Count), new Vector2(390 + 17 - font.MeasureString(Convert.ToString(Spieler[2].Karten.Count)).X, 250), Color.Black);
                spriteBatch.DrawString(font1, Convert.ToString(Spieler[3].Karten.Count), new Vector2(1520 + 17 - font.MeasureString(Convert.ToString(Spieler[3].Karten.Count)).X, 250), Color.Black);
                spriteBatch.DrawString(font1, Convert.ToString(Spieler[0].Karten.Count), new Vector2(1520 + 17 - font.MeasureString(Convert.ToString(Spieler[0].Karten.Count)).X, 780), Color.Black);
            }

            spriteBatch.DrawString(font, "" + Tisch.Count, new Vector2(900, 500), Color.Black);

            if (geklingelt == false)
            {

                if (nextCard)
                {
                    runde++;
                    rundeKarten++;
                }


                



                if (nextCard)
                {
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

                    nextCard = false;
                }
            }
            else {
                spriteBatch.Draw(leertaste, new Vector2(234, 30), Color.White);

                if(player >= 2)
                foreach (var item in _Buttons12)
                {
                    item.Draw(gameTime, spriteBatch);
                }

                if (player >= 3)
                    foreach (var item in _Button3)
                    {
                        item.Draw(gameTime, spriteBatch);
                    }

                if (player >= 4)
                    foreach (var item in _Button4)
                    {
                        item.Draw(gameTime, spriteBatch);
                    }
            }
            

            
            spriteBatch.End();

            
        }

        public override void PostUpdate(GameTime gameTime)
        {
           
        }
    }
}
