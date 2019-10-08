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

        /// <summary>
        /// Creates the main menu on the given window
        /// </summary>
        /// <param name="_window">Window to open the Scene in</param>
        public Scene_MainMenu(Window _window)
        {
            window = _window;
        }

        public void DrawScene()
        {
            SDL.SDL_Rect rect;
            rect.x = 250;
            rect.y = 150;
            rect.w = 200;
            rect.h = 200;

            SDL.SDL_SetRenderDrawColor(window.renderer, 255, 255, 255, 255);
            SDL.SDL_RenderDrawRect(window.renderer, ref rect);

            SDL.SDL_SetRenderDrawColor(window.renderer, 0, 0, 0, 255);
        }
    }
}
