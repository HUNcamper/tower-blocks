using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scenes;
using SDL2;
using tower_blocks;

namespace Scenes
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuButton : SceneElement
    {
        /// <summary>
        /// Creates a menu button
        /// </summary>
        /// <param name="_scene">Scene to create the button in</param>
        /// <param name="_text">Text to display</param>
        /// <param name="_fontsize">Font size</param>
        /// <param name="_fontcolor">Font size</param>
        public MenuButton(IScene _scene, string _text)
        {
            scene = _scene;
            text = _text;
        }

        /// <summary>
        /// Draws the element on the scene it's on
        /// </summary>
        public new void DrawElement()
        {
            Text text_handler = new Text(this, text);

            text_handler.Draw();

            SDL.SDL_Rect rect;
            rect.x = text_handler.x;
            rect.y = text_handler.y;
            rect.w = text_handler.width;
            rect.h = text_handler.height;

            SDL.SDL_SetRenderDrawColor(scene.window.renderer, 255, 255, 255, 255);
            SDL.SDL_RenderDrawRect(scene.window.renderer, ref rect);
        }
    }
}
