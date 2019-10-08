using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Scenes
{
    public class SceneElement : ISceneElement
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
        /// Handles events
        /// </summary>
        public void HandleEvent(SDL.SDL_Event e)
        {

        }

        /// <summary>
        /// Draws the element on the scene it's on
        /// </summary>
        public void DrawElement()
        {

        }

        /// <summary>
        /// Called when mouse hovered over
        /// </summary>
        public void OnHover()
        {

        }
    }
}
