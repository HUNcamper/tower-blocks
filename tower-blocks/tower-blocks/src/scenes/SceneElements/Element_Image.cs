using Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace UI
{
    class Element_Image : SceneElement
    {
        private IntPtr image_texture;

        public string image { get; set; }

        public Element_Image(Scene _scene, string _image) : base (_scene)
        {
            image = _image;

            image_texture = SDL_image.IMG_LoadTexture(scene.window.renderer, image);
        }

        public override void Draw()
        {
            SDL.SDL_Rect tRect;
            tRect.x = drawx;
            tRect.y = drawy;
            tRect.w = width;
            tRect.h = height;

            /*SDL.SDL_Rect sRect;
            sRect.x = 100;
            sRect.y = 100;
            sRect.w = 64;
            sRect.h = 64;*/

            SDL.SDL_RenderCopy(scene.window.renderer, image_texture, IntPtr.Zero, ref tRect);
        }
    }
}
