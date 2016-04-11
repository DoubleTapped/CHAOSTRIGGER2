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

        /// <summary>
        /// Lets us know if we should transition or not
        /// </summary>

        bool transition;

        FadeAnimation fade = new FadeAnimation();
        Texture2D fadeTexture;

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
            transition = true;
            newScreen = screen;
            fade.IsActive = true;
            fade.Alpha = 0.0f;
            fade.ActivateValue = 1.0f;
        }

        public void Initialize()
        {
            currentScreen = new SplashScreen(spriteBatch);
            fade = new FadeAnimation();
        }
        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
            
            fadeTexture = content.Load<Texture2D>("FadeTest");
            fade.LoadContent(content, fadeTexture, "", Vector2.Zero);
            fade.Scale = dimensions.X;
        }
        public void Update(GameTime gameTime)
        {
            if (!transition)
            {
                currentScreen.Update(gameTime);
            }
            else
            {
                Transition(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw();
            if (transition)
            {
                fade.Draw();
            }
        }

        #endregion

        #region Private Methods

        private void Transition(GameTime gameTime)
        {
            fade.Update(gameTime);
            if (fade.Alpha == 1.0f && fade.Timer.TotalSeconds == 1.0f)
            {
                screenStack.Push(newScreen);
                currentScreen.UnloadContent();
                currentScreen = newScreen;
                currentScreen.LoadContent(content);
            }
            else if(fade.Alpha == 0.0f)
            {
                transition = false;
                fade.IsActive = false;
            }
        }

        #endregion
    }
}