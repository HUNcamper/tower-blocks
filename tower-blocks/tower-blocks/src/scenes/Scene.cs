using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tower_blocks;

namespace Scenes
{
    /// <summary>
    /// Defines a Scene
    /// </summary>
    public abstract class Scene
    {
        /// <summary>
        /// Window to load the scene in
        /// </summary>
        public Window window
        {
            get;
            set;
        }

        /// <summary>
        /// List of elements in the scene
        /// </summary>
        public List<SceneElement> element_list
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a scene
        /// </summary>
        /// <param name="_window">Window to open the Scene in</param>
        public Scene(Window _window)
        {
            window = _window;
            window.scene = this;

            element_list = new List<SceneElement>();
        }

        /// <summary>
        /// Updates the scene
        /// </summary>
        public void UpdateScene()
        {
            HandleScene();
            DrawScene();
        }

        /// <summary>
        /// Handles the scene elements
        /// </summary>
        public abstract void HandleScene();

        /// <summary>
        /// Draws the scene on the given window
        /// </summary>
        public abstract void DrawScene();

        /// <summary>
        /// Handles events
        /// </summary>
        /// <param name="e">Event data</param>
        public void HandleEvent(SDL.SDL_Event e)
        {
            foreach (SceneElement element in element_list)
            {
                element.HandleEvent(e);
            }

            OnHandleEvent(e);
        }

        /// <summary>
        /// Gets called when HandleEvent finishes
        /// </summary>
        /// <param name="e">Event data</param>
        protected virtual void OnHandleEvent(SDL.SDL_Event e)
        {
        }
    }
}
