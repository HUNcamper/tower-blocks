using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace tower_blocks
{
    public class Window
    {
        /// <summary>
        /// Pointer of the window
        /// </summary>
        public IntPtr windowPtr { get; set; }

        /// <summary>
        /// Pointer of the renderer
        /// </summary>
        public IntPtr renderer { get; set; }

        /// <summary>
        /// Creates an SDL2 window
        /// </summary>
        /// <param name="w_title">Window title</param>
        /// <param name="w_width">Window width</param>
        /// <param name="w_height">Window height</param>
        /// <param name="w_h_windowpos">Window's horizontal position</param>
        /// <param name="w_v_windowpos">Window's vertical position</param>
        /// <param name="w_windowflags">Window's flags</param>
        public Window(string w_title, int w_width, int w_height, int w_h_windowpos = SDL.SDL_WINDOWPOS_CENTERED, int w_v_windowpos = SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WindowFlags w_windowflags = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE)
        {
            windowPtr = IntPtr.Zero;

            windowPtr = SDL.SDL_CreateWindow(w_title,
                w_h_windowpos,
                w_v_windowpos,
                w_width,
                w_height,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
            );

            renderer = SDL.SDL_CreateRenderer(windowPtr, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        }

        /// <summary>
        /// Destroy the window
        /// </summary>
        public void Destroy()
        {
            SDL.SDL_DestroyWindow(windowPtr);
            windowPtr = IntPtr.Zero;
        }

        /// <summary>
        /// Called when an SDL Window event happens
        /// </summary>
        /// <param name="e">Event parameter</param>
        public void HandleEvent(SDL.SDL_Event e)
        {
            // It's this window
            if (SDL.SDL_GetWindowFromID(e.window.windowID) == windowPtr)
            {
                switch (e.window.windowEvent)
                {
                    // Close window when X is pressed
                    case SDL.SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE:
                        Destroy();
                        break;
                }
            }
        }
    }
}
