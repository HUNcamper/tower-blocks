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
    class SDL_Handler
    {
        private List<IntPtr> window_list = new List<IntPtr>();

        public SDL_Handler()
        {
            // Initialize SDL2
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
        }

        /// <summary>
        /// Creates an SDL2 window
        /// </summary>
        /// <param name="w_title">Window title</param>
        /// <param name="w_width">Window width</param>
        /// <param name="w_height">Window height</param>
        /// <param name="w_h_windowpos">Window's horizontal position</param>
        /// <param name="w_v_windowpos">Window's vertical position</param>
        /// <param name="w_windowflags">Window's SDL.SDL_WindowFlags flags</param>
        public void CreateWindow (string w_title, int w_width, int w_height, int w_h_windowpos = SDL.SDL_WINDOWPOS_CENTERED, int w_v_windowpos = SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WindowFlags w_windowflags = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE)
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
        }
    }
}
