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
        private List<Component> _components;
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
            var backButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1850, 950),
                Text = "weiter"
            };

            backButton.Click += forward_Click;

            _components = new List<Component>
            {
                backButton
            };
        }

        private void forward_Click(object sender, EventArgs e)
        {
            Seite++;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();



            if(Seite == 1)
                spriteBatch.Draw(Hilfe1, new Rectangle(0, 0, 1920, 1080), Color.White);

            if(Seite == 2)
                spriteBatch.Draw(Hilfe2, new Rectangle(0, 0, 1920, 1080), Color.White);

            if (Seite == 3)
                spriteBatch.Draw(Hilfe2, new Rectangle(0, 0, 1920, 1080), Color.White);


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
