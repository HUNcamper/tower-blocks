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
        /// Draws the scene on the given window
        /// </summary>
        void DrawScene();
    }
}
