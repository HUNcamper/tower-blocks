using SDL2;

namespace Scenes
{
    /// <summary>
    /// Defines a scene element
    /// </summary>
    public class Element_Block : SceneElement
    {
        private bool left;

        /// <summary>
        /// Called every frame
        /// </summary>
        public override void Update()
        {
            int w_width, w_height;
            SDL.SDL_GetWindowSize(scene.window.windowPtr, out w_width, out w_height);

            if (!left)
            {
                if ((x + 5) + width > w_width)
                {
                    left = true;
                }
                else
                {
                    x += 5;
                }
            }
            else
            {
                if (x - 5 < 0)
                {
                    left = false;
                }
                else
                {
                    x -= 5;
                }
            }
        }

        /// <summary>
        /// Draws the element on the scene it's on
        /// </summary>
        public override void Draw()
        {
            // Téglalap
            SDL.SDL_Rect rect;
            rect.x = x;
            rect.y = y;
            rect.w = width;
            rect.h = height;

            // Szín
            SDL.SDL_SetRenderDrawColor(scene.window.renderer, 0, 255, 0, 255);

            // Téglalap kirajzolása
            SDL.SDL_RenderFillRect(scene.window.renderer, ref rect);
        }

        /// <summary>
        /// Creates a Scene Element
        /// </summary>
        /// <param name="_scene">Scene to create in</param>
        public Element_Block(Scene _scene) : base (_scene)
        {
            scene.SubscribeToEventHandler(this);
            left = false;

            width = 50;
            height = 50;
        }

        #region Events

        /// <summary>
        /// Called when the elements stops being clicked
        /// </summary>
        /// <param name="e">Event data</param>
        protected override void OnRelease(SDL.SDL_Event e)
        {

        }

        #endregion
    }
}
