using SDL2;
using tower_blocks;
using UI;
using System;

namespace Scenes
{
    /// <summary>
    /// Main Menu scene
    /// </summary>
    public class Scene_Game : Scene
    {
        private TextElement fps_counter;
        private TextElement collision;

        private CollisionDetector collision_detector;

        private int mx;
        private int my;

        private int current_tower_width;
        /// <summary>
        /// Current tower width
        /// </summary>
        public int Current_Tower_Width
        {
            get
            {
                return current_tower_width;
            }
            set
            {
                current_tower_width = value;
                moving_tower_block.width = 50 * value;
            }
        }

        /// <summary>
        /// Starting tower width
        /// </summary>
        public int start_tower_width;

        public Element_Tower_Moving moving_tower_block;

        /// <summary>
        /// Creates the main menu on the given window
        /// </summary>
        /// <param name="_window">Window to open the Scene in</param>
        public Scene_Game(Window _window) : base (_window)
        {
            int w_width, w_height;
            SDL.SDL_GetWindowSize(this.window.windowPtr, out w_width, out w_height);

            moving_tower_block = new Element_Tower_Moving(this);
            moving_tower_block.x = 0;
            moving_tower_block.y = w_height-moving_tower_block.height;

            Current_Tower_Width = 10;

            fps_counter = new TextElement(this, "FPS:", 0, 0);
            collision = new TextElement(this, "Collision:", 0, 40);

            collision_detector = new CollisionDetector(this);
        }

        /// <summary>
        /// Handles the scene elements
        /// </summary>
        public override void HandleScene()
        {
            fps_counter.Text = "FPS: " + this.fps.ToString();

            bool collide = collision_detector.CheckPoint(mx, my);

            collision.Text = "Collision: " + collide.ToString();
        }

        /// <summary>
        /// Draws the scene
        /// </summary>
        public override void DrawScene()
        {
            foreach (SceneElement element in element_list)
            {
                element.Draw();
            }

            SDL.SDL_SetRenderDrawColor(window.renderer, 0, 0, 0, 255);
        }

        /// <summary>
        /// Handles events
        /// </summary>
        /// <param name="e">Event data</param>
        protected override void OnHandleEvent(SDL.SDL_Event e)
        {
            mx = e.motion.x;
            my = e.motion.y;

            if (e.type == SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN)
            {
                moving_tower_block.SceneClicked();
            }
        }
    }
}
