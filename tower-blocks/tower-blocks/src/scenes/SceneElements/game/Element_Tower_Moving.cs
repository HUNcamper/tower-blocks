using SDL2;
using System;
using System.Collections.Generic;
using tower_blocks;

namespace Scenes
{
    /// <summary>
    /// Defines the moving tower block
    /// </summary>
    public class Element_Tower_Moving : SceneElement
    {
        /// <summary>
        /// Should the block move left or right
        /// </summary>
        private bool left;

        /// <summary>
        /// Last dropped tower block
        /// </summary>
        private Stack<Element_Tower_Dropped> dropped_stack;

        /// <summary>
        /// Speed of movement
        /// </summary>
        public int speed;

        /// <summary>
        /// Called every frame
        /// </summary>
        protected override void OnUpdate()
        {
            // Move left and right
            int w_width, w_height;
            SDL.SDL_GetWindowSize(scene.window.windowPtr, out w_width, out w_height);

            if (!left)
            {
                if ((x + speed) + width > w_width)
                {
                    left = true;
                }
                else
                {
                    x += speed;
                }
            }
            else
            {
                if (x - speed < 0)
                {
                    x = 0;
                    left = false;
                }
                else
                {
                    x -= speed;
                }
            }
        }

        /// <summary>
        /// Draws the element on the scene it's on
        /// </summary>
        public override void Draw()
        {
            // Rectangle
            SDL.SDL_Rect rect;
            rect.x = drawx;
            rect.y = drawy;
            rect.w = width;
            rect.h = height;

            // Color
            SDL.SDL_SetRenderDrawColor(scene.window.renderer, 0, 255, 0, 255);

            // Drawing the rectangle
            SDL.SDL_RenderFillRect(scene.window.renderer, ref rect);
        }

        /// <summary>
        /// Creates a Scene Element
        /// </summary>
        /// <param name="_scene">Scene to create in</param>
        public Element_Tower_Moving(Scene _scene) : base (_scene)
        {
            dropped_stack = new Stack<Element_Tower_Dropped>();

            scene.SubscribeToEventHandler(this);
            left = false;

            width = 50;
            height = 50;

            speed = 10;
        }

        /// <summary>
        /// Called by the scene when it's clicked
        /// </summary>
        public void SceneClicked()
        {
            int new_x = x;
            int new_width = width;
            
            if (dropped_stack.Count != 0)
            {
                Element_Tower_Dropped last_dropped = dropped_stack.Peek();

                if (last_dropped.x != x)
                {
                    int difference = Math.Abs(last_dropped.x - x);
                    Console.WriteLine("Difference: {0}", difference);
                    // Remove the fallen off parts
                    new_width -= difference;

                    if (last_dropped.x > x)
                    {
                        new_x += difference;
                    }
                    else
                    {
                        new_x = x;
                    }
                }
                else
                {
                    Console.WriteLine("Perfect!");
                }
            }

            width = new_width;

            Console.WriteLine("Tower Placed");
            Element_Tower_Dropped new_dropped = new Element_Tower_Dropped(scene);
            new_dropped.x = new_x;
            new_dropped.y = y;
            new_dropped.width = width;
            new_dropped.height = height;

            dropped_stack.Push(new_dropped);

            y -= height;

            if (dropped_stack.Count > 5)
            {
                scene.camera.y += height;
            }
        }

        #region Events

        #endregion
    }
}
