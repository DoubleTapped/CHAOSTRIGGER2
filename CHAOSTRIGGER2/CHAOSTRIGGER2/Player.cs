using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;

namespace CHAOSTRIGGER2
{
    public class Player : Entity
    {
        public override void LoadContent(ContentManager content, InputManager input)
        {
            base.LoadContent(content, input);
            fileManager = new FileManager();

            FileManager.LoadContent("Load/Player.ct")
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
