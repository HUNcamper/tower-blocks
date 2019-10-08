using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using tower_blocks;

namespace Scenes
{
    /// <summary>
    /// Defines a Scene
    /// </summary>
    public interface IScene
    {
        /// <summary>
        /// Window to load the scene in
        /// </summary>
        Window window
        {
            get;
            set;
        }

        /// <summary>
        /// Screen surface
        /// </summary>
        IntPtr screen
        {
            get;
            set;
        }

        /// <summary>
        /// Updates the scene
        /// </summary>
        void UpdateScene();

        /// <summary>
        /// Handles the scene elements
        /// </summary>
        void HandleScene();

        /// <summary>
        /// Draws the scene on the given window
        /// </summary>
        void DrawScene();
    }
}
