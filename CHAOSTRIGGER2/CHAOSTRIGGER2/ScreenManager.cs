using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CHAOSTRIGGER2
{
    public class ScreenManager : GameScreen
    {
        public ScreenManager()
        {
            
        }
        #region Variables
        /// <summary>
        /// Creating custom content manager
        /// </summary>
        ContentManager content;

        GameScreen currentScreen = new GameScreen();
        GameScreen newScreen;

        /// <summary>
        /// ScreenManager instance
        /// </summary>
        
        private static ScreenManager instance;
 
        /// <summary>
        /// Screen stack
        /// </summary>
        
        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        /// <summary>
        /// Screens width and height
        /// </summary>

        Vector2 dimensions;

        #endregion

        #region Properties

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }
        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        #endregion

        #region Main Methods
        public void AddScreen(GameScreen screen)
        {
            newScreen = screen;
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = newScreen;
            currentScreen.LoadContent(content);
         
        }

        public void Initialize()
        {

        }
        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
        }
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
         //   currentScreen.Draw(spriteBatch);
        }

        #endregion
    }
}