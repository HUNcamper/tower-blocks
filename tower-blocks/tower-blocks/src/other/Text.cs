using Scenes;
using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_blocks
{
    /// <summary>
    /// Handles text drawing
    /// </summary>
    public class Text
    {
        /// <summary>
        /// Scene element handling this text
        /// </summary>
        public SceneElement element { get; set; }

        /// <summary>
        /// Text to display
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Font filename to use
        /// </summary>
        public string fontname { get; set; }

        /// <summary>
        /// Font color
        /// </summary>
        public SDL.SDL_Color fontcolor { get; set; }

        /// <summary>
        /// Font size
        /// </summary>
        public int fontsize { get; set; }

        /// <summary>
        /// X position of the text
        /// </summary>
        public int x { get; set; }
        
        /// <summary>
        /// Y position of the text
        /// </summary>
        public int y { get; set; }

        public int width { get; set; }

        public int height { get; set; }

        /// <summary>
        /// Creates a text handler
        /// </summary>
        /// <param name="_element">Parent element</param>
        /// <param name="_text">Text to display</param>
        public Text(SceneElement _element, string _text)
        {
            element = _element;
            text = _text;
            fontsize = 32;
            fontname = "arial.ttf";

            // Default color is white
            SDL.SDL_Color temp_color = new SDL.SDL_Color();
            temp_color.r = 255;
            temp_color.g = 255;
            temp_color.b = 255;
            temp_color.a = 255;

            fontcolor = temp_color;

            width = 0;
            height = 0;
        }

        /// <summary>
        /// Draws the text
        /// </summary>
        public void Draw()
        {
            IntPtr font = SDL_ttf.TTF_OpenFont(fontname, fontsize);
            IntPtr text_surface = SDL_ttf.TTF_RenderText_Blended(font, text, fontcolor);
            IntPtr text_texture = SDL.SDL_CreateTextureFromSurface(element.scene.window.renderer, text_surface);

            // These are null values
            int int_null;
            uint uint_null;

            int new_width = 0;
            int new_height = 0;

            SDL.SDL_QueryTexture(text_texture, out uint_null, out int_null, out new_width, out new_height);

            SDL.SDL_Rect desRect = new SDL.SDL_Rect() { x = x, y = y, w = new_width, h = new_height };

            SDL.SDL_RenderCopy(element.scene.window.renderer, text_texture, IntPtr.Zero, ref desRect);

            // Update width & height
            width = new_width;
            height = new_height;

            // Free resources
            SDL_ttf.TTF_CloseFont(font);
            SDL.SDL_FreeSurface(text_surface);
            SDL.SDL_DestroyTexture(text_texture);
        }
    }
}
