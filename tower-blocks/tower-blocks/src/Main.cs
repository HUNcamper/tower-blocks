using Scenes;
using UI;

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

            Window window = sdl_handler.CreateWindow("Hello World", 1024, 800);

            Scene current_scene = new Scene_Game(window);

            while (!sdl_handler.quit)
            {
                sdl_handler.Update();
            }
        }
    }
}
