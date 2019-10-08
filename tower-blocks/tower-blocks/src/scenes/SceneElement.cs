using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Scenes
{
    public abstract class SceneElement
    {
        /// <summary>
        /// Scene the element is in
        /// </summary>
        public Scene scene { get; set; }

        /// <summary>
        /// X position of the element
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// Y position of the element
        /// </summary>
        public int y { get; set; }

        /// <summary>
        /// Width of the element
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// Height of the element
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// Text on the button
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Is the element hovered by the mouse
        /// </summary>
        private bool hovered;

        /// <summary>
        /// Handles events
        /// </summary>
        public void HandleEvent(SDL.SDL_Event e)
        {
            if (e.type == SDL.SDL_EventType.SDL_MOUSEMOTION)
            {
                // Check for mouse hover
                int m_x = e.motion.x;
                int m_y = e.motion.y;

                if (!(m_x < this.x || m_x > this.x + this.width ||
                    m_y < this.y || m_y > this.y + this.height))
                {
                    if (!hovered)
                    {
                        OnHover(e);
                    }
                }
                else if (hovered)
                    hovered = false;
            }
        }

        /// <summary>
        /// Draws the element on the scene it's on
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Called when mouse hovered over
        /// </summary>
        public abstract void OnHover(SDL.SDL_Event e);
    }
}
