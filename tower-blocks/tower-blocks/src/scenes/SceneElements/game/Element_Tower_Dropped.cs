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
    /// Defines a dropped tower block
    /// </summary>
    class Element_Tower_Dropped : SceneElement
    {
        /// <summary>
        /// Creates a Scene Element
        /// </summary>
        /// <param name="_scene">Scene to create in</param>
        public Element_Tower_Dropped(Scene _scene) : base(_scene)
        {

        }

        /// <summary>
        /// Draw the element
        /// </summary>
        public override void Draw()
        {
            // Rectangle
            SDL.SDL_Rect rect;
            rect.x = x;
            rect.y = y;
            rect.w = width;
            rect.h = height;

            // Color
            SDL.SDL_SetRenderDrawColor(scene.window.renderer, 255, 255, 255, 255);

            // Drawing the rectangle
            SDL.SDL_RenderFillRect(scene.window.renderer, ref rect);
        }
    }
}
