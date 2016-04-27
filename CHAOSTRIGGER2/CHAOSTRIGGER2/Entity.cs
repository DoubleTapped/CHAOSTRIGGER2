using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CHAOSTRIGGER2
{
    public class Entity
    {
        protected int health;
        protected Animation moveAnimation;
        protected float moveSpeed;

        protected ContentManager content;
        protected FileManager fileManager;

        protected List<List<string>> attributes, contents;

        public virtual void LaodContent(ContentManager content, InputManager input)
        {
            this.content = new ContentManager(content.ServiceProvider, "Content");
        }
    }
}
