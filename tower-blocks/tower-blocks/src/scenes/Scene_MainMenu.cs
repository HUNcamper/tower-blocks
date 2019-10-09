using SDL2;
using UI;

namespace Scenes
{
    /// <summary>
    /// Main Menu scene
    /// </summary>
    public class Scene_MainMenu : Scene
    {
        /// <summary>
        /// Creates the main menu on the given window
        /// </summary>
        /// <param name="_window">Window to open the Scene in</param>
        public Scene_MainMenu(Window _window) : base (_window)
        {
            int w, h;
            SDL.SDL_GetWindowSize(window.windowPtr, out w, out h);

            int center_x = (w / 2);
            int center_y = (h / 2);

            TextElement menu_text = new TextElement(this, "Tower Blocks", 0, 0);
            menu_text.fontsize = 64;

            menu_text.x = center_x - (menu_text.width / 2);
            menu_text.y = center_y - (menu_text.height / 2) - 150;

            MenuButton b_startgame = new Button_StartGame(this, "Start New Game", 0, 0, 300);

            b_startgame.x = center_x - (b_startgame.width / 2);
            b_startgame.y = center_y - (b_startgame.height / 2) - 50;

            MenuButton b_quitgame = new MenuButton(this, "Quit Game", 0, 0, 300);

            b_quitgame.x = center_x - (b_quitgame.width / 2);
            b_quitgame.y = center_y - (b_quitgame.height / 2) + 50;
        }

        /// <summary>
        /// Handles the scene elements
        /// </summary>
        public override void HandleScene()
        {

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

        }
    }
}
