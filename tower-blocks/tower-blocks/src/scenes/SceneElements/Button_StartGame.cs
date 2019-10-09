using Scenes;
using SDL2;

namespace UI
{
    /// <summary>
    /// Start game button
    /// </summary>
    public class Button_StartGame : MenuButton
    {
        /// <summary>
        /// Creates a start game button
        /// </summary>
        /// <param name="_scene">Scene to create the button in</param>
        /// <param name="_text">Text to display</param>
        /// <param name="_x">X position of the element</param>
        /// <param name="_y">Y position of the element</param>
        /// <param name="_width">Width of the element (leave on 0 for auto)</param>
        /// <param name="_height">Height of the element (leave on 0 for auto)</param>
        public Button_StartGame(Scene _scene, string _text, int _x, int _y, int _width = 0, int _height = 0) : base (_scene, _text, _x, _y, _width, _height)
        {
            
        }

        /// <summary>
        /// Called when the element got clicked
        /// </summary>
        /// <param name="e">Event data</param>
        protected override void OnReleaseAbove(SDL.SDL_Event e)
        {
            scene = new Scene_DifficultySelect(scene.window);
        }
    }
}
