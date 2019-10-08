using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using Scenes;

namespace tower_blocks
{
    /// <summary>
    /// Handles certain SDL functions
    /// </summary>
    public class SDL_Handler
    {
        /// <summary>
        /// List of windows
        /// </summary>
        private List<Window> window_list = new List<Window>();

        /// <summary>
        /// Is the SDL handler done
        /// </summary>
        public bool quit { get; set; }

        /// <summary>
        /// Initialize the SDL Handler
        /// </summary>
        public SDL_Handler()
        {
            // Initialize SDL2
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            // Initialize SDL_ttf
            SDL_ttf.TTF_Init();

            quit = false;
        }

        /// <summary>
        /// Update function, has to be called in a loop
        /// </summary>
        public void Update()
        {
            SDL.SDL_Event e;
            if (SDL.SDL_PollEvent(out e) != 0)
            {
                HandleEvents(e);
                HandleWindowEvents(e);
            }
        }

        /// <summary>
        /// Creates an SDL2 window
        /// </summary>
        /// <param name="w_title">Window title</param>
        /// <param name="w_width">Window width</param>
        /// <param name="w_height">Window height</param>
        /// <param name="w_h_windowpos">Window's horizontal position</param>
        /// <param name="w_v_windowpos">Window's vertical position</param>
        /// <param name="w_windowflags">Window's flags</param>
        /// <returns>Created window</returns>
        public Window CreateWindow(string w_title, int w_width, int w_height, int w_h_windowpos = SDL.SDL_WINDOWPOS_CENTERED, int w_v_windowpos = SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WindowFlags w_windowflags = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE)
        {
            Window window = new Window(w_title, w_width, w_height, w_h_windowpos, w_v_windowpos, w_windowflags);

            window_list.Add(window);

            return window;
        }

        /// <summary>
        /// Destroy a given window
        /// </summary>
        /// <param name="window">Given window</param>
        public void DestroyWindow(Window window)
        {
            window.Destroy();
            window_list.Remove(window);
        }

        /// <summary>
        /// Handles events
        /// </summary>
        public void HandleEvents(SDL.SDL_Event e)
        {
            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    Quit();
                    break;
            }
        }

        /// <summary>
        /// Frees up resources and quits the program
        /// </summary>
        public void Quit()
        {
            quit = true;
            SDL_ttf.TTF_Quit();
        }

        /// <summary>
        /// Handles window events
        /// </summary>
        public void HandleWindowEvents(SDL.SDL_Event e)
        {
            if (e.type == SDL.SDL_EventType.SDL_WINDOWEVENT)
            {
                foreach (Window window in window_list)
                {
                    window.HandleEvent(e);
                }
            }
        }

        /// <summary>
        /// Draws a scene
        /// </summary>
        /// <param name="scene">Scene to draw</param>
        public void DrawScene(IScene scene)
        {
            SDL.SDL_RenderClear(scene.window.renderer);

            scene.DrawScene();

            SDL.SDL_RenderPresent(scene.window.renderer);
        }
    }
}
