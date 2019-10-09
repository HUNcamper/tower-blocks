using SDL2;
using System.Collections.Generic;
using UI;

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
        /// Current framerate set by the SDL_Handler
        /// </summary>
        public uint fps;

        /// <summary>
        /// List of elements which are subscribed to the event handler
        /// </summary>
        public List<SceneElement> subscribed_elements;

        /// <summary>
        /// Creates a scene
        /// </summary>
        /// <param name="_window">Window to open the Scene in</param>
        public Scene(Window _window)
        {
            window = _window;
            window.scene = this;

            element_list = new List<SceneElement>();
            subscribed_elements = new List<SceneElement>();
        }

        /// <summary>
        /// Unload the scene
        /// </summary>
        public void Unload()
        {
            element_list.Clear();
            subscribed_elements.Clear();
            window.scene = null;
        }

        /// <summary>
        /// Updates the scene
        /// </summary>
        public void UpdateScene()
        {
            foreach (SceneElement element in element_list)
            {
                element.Update();
            }

            HandleScene();
            //DrawScene(); // this is handled by SDL_Handler
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
            // Send event data only to subscribed elements
            foreach (SceneElement element in subscribed_elements)
            {
                element.HandleEvent(e);
            }

            OnHandleEvent(e);
        }

        /// <summary>
        /// Subscribe an element to the event handler
        /// </summary>
        /// <param name="element">Element to subscribe</param>
        public void SubscribeToEventHandler(SceneElement element)
        {
            subscribed_elements.Add(element);
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
