using Scenes;
using SDL2;
using System;

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
        /// Text on the button
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Creates a menu button
        /// </summary>
        /// <param name="_scene">Scene to create the button in</param>
        /// <param name="_text">Text to display</param>
        /// <param name="_x">X position of the element</param>
        /// <param name="_y">Y position of the element</param>
        /// <param name="_width">Width of the element (leave on 0 for auto)</param>
        /// <param name="_height">Height of the element (leave on 0 for auto)</param>
        public MenuButton(Scene _scene, string _text, int _x, int _y, int _width=0, int _height=0) : base(_scene)
        {
            scene = _scene;
            text = _text;

            x = _x;
            y = _y;

            text_handler = new Text(this, text);

            width = _width;
            height = _height;

            // If 0, auto size the element to the text
            if (width == 0)     this.width = text_handler.width;
            if (height == 0)    this.height = text_handler.height;

            // Subscribe to the event handler
            scene.SubscribeToEventHandler(this);
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
            
            if (clicked)
                SDL.SDL_SetRenderDrawColor(scene.window.renderer, 0, 255, 255, 255);
            else if (hovered)
                SDL.SDL_SetRenderDrawColor(scene.window.renderer, 255, 255, 255, 255);
            else
                SDL.SDL_SetRenderDrawColor(scene.window.renderer, 255, 0, 0, 255);

            SDL.SDL_RenderDrawRect(scene.window.renderer, ref rect);
        }

        /// <summary>
        /// Called when the element got clicked
        /// </summary>
        /// <param name="e">Event data</param>
        protected override void OnClick(SDL.SDL_Event e)
        {
            System.Console.WriteLine("Clicked: {0}", this.text);
        }

        /// <summary>
        /// Called when the elements stops being clicked
        /// </summary>
        /// <param name="e">Event data</param>
        protected override void OnRelease(SDL.SDL_Event e)
        {
            System.Console.WriteLine("Released: {0}", this.text);
        }

        /// <summary>
        /// Called when mouse hovered over the element
        /// </summary>
        /// <param name="e">Event data</param>
        protected override void OnHover(SDL.SDL_Event e)
        {
            IntPtr c = SDL.SDL_CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_HAND);
            SDL.SDL_SetCursor(c);
        }

        /// <summary>
        /// Called when mouse stopped hovering over the element
        /// </summary>
        /// <param name="e">Event data</param>
        protected override void OnUnHover(SDL.SDL_Event e)
        {
            IntPtr c = SDL.SDL_CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_ARROW);
            SDL.SDL_SetCursor(c);
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        public override void Update()
        {
            // Center the text

            text_handler.x = x + ((width / 2) - (text_handler.width / 2));
            text_handler.y = y + ((height / 2) - (text_handler.height / 2));
        }
    }
}
