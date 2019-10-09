using SDL2;

namespace Scenes
{
    /// <summary>
    /// Defines a scene element
    /// </summary>
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
        public bool hovered { get; set; }

        /// <summary>
        /// Called every frame
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Draws the element on the scene it's on
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Handles events
        /// </summary>
        public void HandleEvent(SDL.SDL_Event e)
        {
            int m_x = 0; // Mouse X
            int m_y = 0; // Mouse Y

            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_MOUSEMOTION:
                    // Check for mouse hover
                    m_x = e.motion.x;
                    m_y = e.motion.y;

                    if (!(m_x < this.x || m_x > this.x + this.width ||
                        m_y < this.y || m_y > this.y + this.height))
                    {
                        if (!hovered)
                        {
                            OnHover(e);
                            hovered = true;
                        }
                    }
                    else if (hovered)
                        hovered = false;

                    break;

                case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                    // Check for mouse click
                    m_x = e.motion.x;
                    m_y = e.motion.y;

                    if (!(m_x < this.x || m_x > this.x + this.width ||
                        m_y < this.y || m_y > this.y + this.height))
                    {
                        OnClick(e);
                    }

                    break;
            }
        }

        #region Events

        /// <summary>
        /// Called when mouse hovered over
        /// </summary>
        /// <param name="e">Event data</param>
        protected virtual void OnHover(SDL.SDL_Event e)
        {

        }

        /// <summary>
        /// Called when the element got clicked
        /// </summary>
        /// <param name="e">Event data</param>
        protected virtual void OnClick(SDL.SDL_Event e)
        {

        }

        #endregion
    }
}
