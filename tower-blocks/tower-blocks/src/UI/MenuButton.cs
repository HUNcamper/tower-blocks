using Scenes;
using SDL2;

namespace UI
{
    /// <summary>
    /// A button for a menu
    /// </summary>
    public class MenuButton : SceneElement
    {
        /// <summary>
        /// Text handler object
        /// </summary>
        private Text text_handler;

        /// <summary>
        /// Creates a menu button
        /// </summary>
        /// <param name="_scene">Scene to create the button in</param>
        /// <param name="_text">Text to display</param>
        /// <param name="_x">X position of the element</param>
        /// <param name="_y">Y position of the element</param>
        public MenuButton(Scene _scene, string _text, int _x, int _y)
        {
            scene = _scene;
            text = _text;

            x = _x;
            y = _y;

            text_handler = new Text(this, text);

            this.width = text_handler.width;
            this.height = text_handler.height;
        }

        /// <summary>
        /// Draws the element on the scene it's on
        /// </summary>
        public override void Draw()
        {
            text_handler.Draw();

            SDL.SDL_Rect rect;
            rect.x = x;
            rect.y = y;
            rect.w = width;
            rect.h = height;

            if (hovered)
                SDL.SDL_SetRenderDrawColor(scene.window.renderer, 255, 255, 255, 255);
            if (!hovered)
                SDL.SDL_SetRenderDrawColor(scene.window.renderer, 255, 0, 0, 255);

            SDL.SDL_RenderDrawRect(scene.window.renderer, ref rect);
        }

        /// <summary>
        /// Called when mouse hovered over
        /// </summary>
        /// <param name="e">Event data</param>
        public override void OnHover(SDL.SDL_Event e)
        {

        }
        
        /// <summary>
        /// Called every frame
        /// </summary>
        public override void Update()
        {
            text_handler.x = x;
            text_handler.y = y;
        }
    }
}
