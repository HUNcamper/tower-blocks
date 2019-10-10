using Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tower_blocks
{
    /// <summary>
    /// Detects collisions
    /// </summary>
    class CollisionDetector
    {
        /// <summary>
        /// The scene the collision detector is in
        /// </summary>
        public Scene scene;

        public CollisionDetector(Scene _scene)
        {
            scene = _scene;
        }

        /// <summary>
        /// Checks a point in the scene
        /// </summary>
        /// <param name="c_x">Desired X point</param>
        /// <param name="c_y">Desired Y point</param>
        /// <returns>True if there's an object at the given point</returns>
        public bool CheckPoint(int c_x, int c_y)
        {
            // Horizontal sides
            int h_left;
            int h_right;

            // Vertical sides
            int v_top;
            int v_bottom;

            foreach (SceneElement elem in scene.element_list)
            {
                // Horizontal

                h_left =   elem.x - c_x;
                h_right = (elem.x - c_x) + elem.width;

                // One side touches 0
                if (h_left == 0 || h_right == 0)
                {
                    return true;
                }
                // One side is negative, the other is positive => 0 is inbetween both sides
                if ((h_left > 0 && h_right < 0) || (h_right > 0 && h_left < 0))
                {
                    return true;
                }

                // Vertical

                v_top =     elem.y - c_y;
                v_bottom = (elem.y - c_y) + elem.height;

                // One side touches 0
                if (v_top == 0 || v_bottom == 0)
                {
                    return true;
                }
                // One side is negative, the other is positive => 0 is inbetween both sides
                if ((v_top > 0 && v_bottom < 0) || (v_bottom > 0 && v_top < 0))
                {
                    return true;
                }
            }

            // None of the above matched
            return false;
        }
    }
}
