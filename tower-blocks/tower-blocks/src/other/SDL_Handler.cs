using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace tower_blocks
{
    /// <summary>
    /// Handles certain SDL functions
    /// </summary>
    public class SDL_Handler
    {
        private List<IntPtr> window_list = new List<IntPtr>();

        /// <summary>
        /// Is the SDL handler done
        /// </summary>
        public bool quit { get; set; }

        public SDL_Handler()
        {
            // Initialize SDL2
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
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
        public IntPtr CreateWindow(string w_title, int w_width, int w_height, int w_h_windowpos = SDL.SDL_WINDOWPOS_CENTERED, int w_v_windowpos = SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WindowFlags w_windowflags = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE)
        {
            IntPtr window = IntPtr.Zero;

            window = SDL.SDL_CreateWindow(w_title,
                w_h_windowpos,
                w_v_windowpos,
                w_width,
                w_height,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
            );

            window_list.Add(window);

            return window;
        }

        /// <summary>
        /// Destroy a given window
        /// </summary>
        /// <param name="window">window's pointer</param>
        public void DestroyWindow(IntPtr window)
        {
            SDL.SDL_DestroyWindow(window);
            window_list.Remove(window);
        }

        /// <summary>
        /// Destroy a given window
        /// </summary>
        /// <param name="windowID">window's ID</param>
        public void DestroyWindow(uint windowID)
        {
            IntPtr window = SDL.SDL_GetWindowFromID(windowID);
            DestroyWindow(window);
        }

        /// <summary>
        /// Handles events
        /// </summary>
        public void HandleEvents(SDL.SDL_Event e)
        {
            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    quit = true;
                    break;
            }
        }

        /// <summary>
        /// Handles window events
        /// </summary>
        public void HandleWindowEvents(SDL.SDL_Event e)
        {
            if (e.type == SDL.SDL_EventType.SDL_WINDOWEVENT)
            {
                switch (e.window.windowEvent)
                {
                    // Close window when X is pressed
                    case SDL.SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE:
                        DestroyWindow(e.window.windowID);
                        break;
                }
            }
        }
    }
}
