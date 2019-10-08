using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scenes;
using SDL2;

namespace tower_blocks
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuButton : ISceneElement
    {
        /// <summary>
        /// Scene the element is in
        /// </summary>
        public IScene scene { get; set; }

        /// <summary>
        /// X position of the element
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// Y position of the element
        /// </summary>
        public int y { get; set; }

        /// <summary>
        /// Text on the button
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Font color
        /// </summary>
        public SDL.SDL_Color fontcolor { get; set; }

        /// <summary>
        /// Font filename
        /// </summary>
        public string fontname { get; set; }

        /// <summary>
        /// Font size
        /// </summary>
        public int fontsize { get; set; }

        /// <summary>
        /// Creates a menu button
        /// </summary>
        /// <param name="_scene">Scene to create the button in</param>
        /// <param name="_font">Font filename</param>
        /// <param name="_fontsize">Font size</param>
        /// <param name="_fontcolor">Font size</param>
        public MenuButton(IScene _scene, string _text, string _fontname="arial.ttf", int _fontsize=32)
        {
            scene = _scene;
            text = _text;
            fontname = _fontname;
            fontsize = _fontsize;

            SDL.SDL_Color temp_color = new SDL.SDL_Color();
            temp_color.r = 255;
            temp_color.g = 255;
            temp_color.b = 0;
            temp_color.a = 255;

            fontcolor = temp_color;
        }

        /// <summary>
        /// Draws the element on the scene it's on
        /// </summary>
        public void DrawElement()
        {
            IntPtr font = SDL_ttf.TTF_OpenFont(fontname, fontsize);
            IntPtr text_surface = SDL_ttf.TTF_RenderText_Blended(font, text, fontcolor);
            IntPtr text_texture = SDL.SDL_CreateTextureFromSurface(scene.window.renderer, text_surface);

            // source is a rectangle defining the area of the texture you want to draw
            int width = 0;
            int height = 0;

            // These are null values
            int int_null;
            uint uint_null;

            //SDL.SDL_Rect sourceRectangle = new SDL.SDL_Rect() { x = 0, y = 0, w = width, h = height };

            // destination is a rectangle defining the render target to which you want to draw
            //SDL.SDL_Rect destinationRectangle = new SDL.SDL_Rect() { x = 0, y = 0, w = width, h = height };

            SDL.SDL_QueryTexture(text_texture, out uint_null, out int_null, out width, out height);

            SDL.SDL_Rect desRect = new SDL.SDL_Rect() { x = 50, y = 50, w = width, h = height };

            //SDL.SDL_RenderCopy(scene.window.renderer, text_texture, ref sourceRectangle, ref destinationRectangle);

            SDL.SDL_RenderCopy(scene.window.renderer, text_texture, IntPtr.Zero, ref desRect);

            SDL.SDL_Rect rect;
            rect.x = desRect.x;
            rect.y = desRect.y;
            rect.w = desRect.w;
            rect.h = desRect.h;

            SDL.SDL_SetRenderDrawColor(scene.window.renderer, 255, 255, 255, 255);
            SDL.SDL_RenderDrawRect(scene.window.renderer, ref rect);

            // Free resources
            SDL_ttf.TTF_CloseFont(font);
            SDL.SDL_FreeSurface(text_surface);
            SDL.SDL_DestroyTexture(text_texture);
        }
    }
}
