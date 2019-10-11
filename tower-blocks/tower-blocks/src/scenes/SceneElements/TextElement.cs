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
        
        private string text;
        /// <summary>
        /// Text to display
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text_handler.text = value;
                text = value;
            }
        }

        private int fontsize;
        /// <summary>
        /// Font size
        /// </summary>
        public int FontSize
        {
            get { return fontsize; }
            set
            {
                text_handler.fontsize = value;

                // Updating the font size will change the
                // element size so update the width and height
                Draw();

                this.width = text_handler.width;
                this.height = text_handler.height;

                fontsize = value;
            }
        }

        private string fontname;

        /// <summary>
        /// Font name
        /// </summary>
        public string FontName
        {
            get { return fontname; }
            set
            {
                fontname = value;
                text_handler.fontname = value;

                // Update the width and height
                text_handler.Draw();

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
        public TextElement(Scene _scene, string _text, int _x, int _y) : base (_scene)
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
        /// Called every frame
        /// </summary>
        protected override void OnUpdate()
        {
            text_handler.x = x;
            text_handler.y = y;
        }
    }
}
