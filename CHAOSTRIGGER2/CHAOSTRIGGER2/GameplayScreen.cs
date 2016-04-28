using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;



namespace CHAOSTRIGGER2
{
    public class GameplayScreen : GameScreen
    {
        Player player;
        public virtual void LoadContent(ContentManager content, InputManager input)
        {
            this.content = new ContentManager(content.ServiceProvider, "Content");
            player = new Player();
            player.LoadContent(content, input);
        }

        public virtual void UnloadContent()
        {
            content.Unload();
            player.UnloadContent();
        }
        public virtual void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            player.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
