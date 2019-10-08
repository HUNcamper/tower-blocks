using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;


namespace tower_blocks
{
    /// <summary>
    /// The main handling program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            SDL_Handler sdl_handler = new SDL_Handler();

            sdl_handler.CreateWindow("Hello World", 1024, 800);
            sdl_handler.CreateWindow("Hello World", 100, 500);

            //SDL.SDL_Delay(1000);

            while (!sdl_handler.quit)
            {
                /*while (SDL.SDL_PollEvent(out e) != 0)
                {
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                            quit = true;
                            break;
                    }
                }*/

                sdl_handler.Update();
            }

            //SDL.SDL_DestroyWindow(window);
        }
    }
}
