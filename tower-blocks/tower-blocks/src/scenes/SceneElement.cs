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
        /// Is the element currently being clicked
        /// </summary>
        public bool clicked { get; set; }

        /// <summary>
        /// Called every frame
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Draws the element on the scene it's on
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Creates a Scene Element
        /// </summary>
        /// <param name="scene">Scene to create in</param>
        public SceneElement(Scene scene)
        {
            scene.element_list.Add(this);
        }

        /// <summary>
        /// Handles events
        /// </summary>
        public void HandleEvent(SDL.SDL_Event e)
        {
            int m_x = e.motion.x; // Mouse X
            int m_y = e.motion.y; // Mouse Y

            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_MOUSEMOTION:
                    // Check for mouse hover

                    if (!(m_x < this.x || m_x > this.x + this.width ||
                        m_y < this.y || m_y > this.y + this.height))
                    {
                        if (!hovered)
                        {
                            hovered = true;
                            OnHover(e);
                        }
                    }
                    else if (hovered)
                    {
                        hovered = false;
                        OnUnHover(e);
                    }

                    break;

                case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                    // Check for mouse click

                    if (!(m_x < this.x || m_x > this.x + this.width ||
                        m_y < this.y || m_y > this.y + this.height))
                    {
                        clicked = true;
                        OnClick(e);
                    }

                    break;

                case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:
                    // Check for mouse release
                    if (clicked)
                    {
                        clicked = false;
                        OnRelease(e);

                        if (!(m_x < this.x || m_x > this.x + this.width ||
                            m_y < this.y || m_y > this.y + this.height))
                        {
                            OnReleaseAbove(e);
                        }
                    }
                    break;
            }
        }

        #region Events

        /// <summary>
        /// Called when mouse hovered over the element
        /// </summary>
        /// <param name="e">Event data</param>
        protected virtual void OnHover(SDL.SDL_Event e)
        {

        }

        /// <summary>
        /// Called when mouse stopped hovering over the element
        /// </summary>
        /// <param name="e">Event data</param>
        protected virtual void OnUnHover(SDL.SDL_Event e)
        {

        }

        /// <summary>
        /// Called when the element got clicked
        /// </summary>
        /// <param name="e">Event data</param>
        protected virtual void OnClick(SDL.SDL_Event e)
        {

        }

        /// <summary>
        /// Called when the elements stops being clicked
        /// </summary>
        /// <param name="e">Event data</param>
        protected virtual void OnRelease(SDL.SDL_Event e)
        {

        }

        /// <summary>
        /// Called when the elements stops being clicked and the mouse is above the element
        /// </summary>
        /// <param name="e">Event data</param>
        protected virtual void OnReleaseAbove(SDL.SDL_Event e)
        {

        }

        #endregion
    }
}
