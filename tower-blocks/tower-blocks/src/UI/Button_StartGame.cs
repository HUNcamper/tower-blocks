using Scenes;

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
        public Button_StartGame(Scene _scene, string _text, int _x, int _y) : base (_scene, _text, _x, _y)
        {
            
        }
    }
}
