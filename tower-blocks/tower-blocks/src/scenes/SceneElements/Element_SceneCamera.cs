using Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace UI
{
    /// <summary>
    /// The main camera for the scene
    /// </summary>
    public class Element_SceneCamera : SceneElement
    {
        public SDL2.SDL.SDL_Rect viewport;

        public Element_SceneCamera(Scene _scene, int _x, int _y, int _w, int _h) : base (_scene)
        {
            x = _x;
            y = _y;
            width = _w;
            height = _h;
        }

        public override void Draw()
        {
            viewport = new SDL2.SDL.SDL_Rect();

            viewport.x = x;
            viewport.y = y;
            viewport.h = height;
            viewport.w = width;

            SDL2.SDL.SDL_RenderSetViewport(scene.window.renderer, ref viewport);
        }
    }
}
