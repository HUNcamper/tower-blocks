using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using tower_blocks;

namespace Scenes
{
    /// <summary>
    /// Main Menu scene
    /// </summary>
    public class Scene_MainMenu : IScene
    {
        /// <summary>
        /// Window to load the scene in
        /// </summary>
        public Window window
        {
            get;
            set;
        }

        private List<MenuButton> buttons;

        /// <summary>
        /// Creates the main menu on the given window
        /// </summary>
        /// <param name="_window">Window to open the Scene in</param>
        public Scene_MainMenu(Window _window)
        {
            window = _window;
            buttons = new List<MenuButton>();
        }

        /// <summary>
        /// Updates the scene
        /// </summary>
        public void UpdateScene()
        {
            HandleScene();
            DrawScene();
        }

        /// <summary>
        /// Handles the scene elements
        /// </summary>
        public void HandleScene()
        {

        }

        /// <summary>
        /// Draws the scene
        /// </summary>
        public void DrawScene()
        {
            MenuButton button = new MenuButton(this, "Hello World");
            button.DrawElement();

            SDL.SDL_SetRenderDrawColor(window.renderer, 0, 0, 0, 255);
        }
    }
}
