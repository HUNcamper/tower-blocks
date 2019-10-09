using SDL2;
using UI;

namespace Scenes
{
    /// <summary>
    /// Main Menu scene
    /// </summary>
    public class Scene_Game : Scene
    {
        private TextElement fps_counter;

        /// <summary>
        /// Creates the main menu on the given window
        /// </summary>
        /// <param name="_window">Window to open the Scene in</param>
        public Scene_Game(Window _window) : base (_window)
        {
            SceneElement block = new Element_Block(this);
            block.x = 0;
            block.y = 100;

            fps_counter = new TextElement(this, "FPS:", 0, 0);
        }

        /// <summary>
        /// Handles the scene elements
        /// </summary>
        public override void HandleScene()
        {
            fps_counter.Text = "FPS: " + this.fps.ToString();
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
