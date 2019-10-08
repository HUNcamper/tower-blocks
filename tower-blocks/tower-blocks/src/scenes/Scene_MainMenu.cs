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
    public class Scene_MainMenu : Scene
    {
        /// <summary>
        /// Creates the main menu on the given window
        /// </summary>
        /// <param name="_window">Window to open the Scene in</param>
        public Scene_MainMenu(Window _window) : base (_window)
        {
            MenuButton button = new MenuButton(this, "Hello World");
            element_list.Add(button);
        }

        /// <summary>
        /// Handles the scene elements
        /// </summary>
        public override void HandleScene()
        {

        }

        /// <summary>
        /// Draws the scene
        /// </summary>
        public override void DrawScene()
        {
            foreach (SceneElement element in element_list)
            {
                element.Draw();
            }

            SDL.SDL_SetRenderDrawColor(window.renderer, 0, 0, 0, 255);
        }

        /// <summary>
        /// Handles events
        /// </summary>
        /// <param name="e">Event data</param>
        protected override void OnHandleEvent(SDL.SDL_Event e)
        {

        }
    }
}
