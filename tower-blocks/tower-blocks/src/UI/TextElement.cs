using Scenes;
using SDL2;

namespace UI
{
    /// <summary>
    /// Text only element
    /// </summary>
    class TextElement : SceneElement
    {
        /// <summary>
        /// Text handler object
        /// </summary>
        private Text text_handler;

        /// <summary>
        /// Font size
        /// </summary>
        public int fontsize
        {
            get { return fontsize; }
            set
            {
                text_handler.fontsize = value;

                // Update the width and height
                Draw();

                this.width = text_handler.width;
                this.height = text_handler.height;
            }
        }

        /// <summary>
        /// Creates a text only element
        /// </summary>
        /// <param name="_scene">Scene to create the button in</param>
        /// <param name="_text">Text to display</param>
        /// <param name="_x">X position of the element</param>
        /// <param name="_y">Y position of the element</param>
        public TextElement(Scene _scene, string _text, int _x, int _y)
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
