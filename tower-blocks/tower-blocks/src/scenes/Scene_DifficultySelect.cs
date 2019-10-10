using SDL2;
using tower_blocks;
using UI;

namespace Scenes
{
    /// <summary>
    /// Main Menu scene
    /// </summary>
    public class Scene_DifficultySelect : Scene
    {
        /// <summary>
        /// Creates the main menu on the given window
        /// </summary>
        /// <param name="_window">Window to open the Scene in</param>
        public Scene_DifficultySelect(Window _window) : base (_window)
        {
            int w, h;
            SDL.SDL_GetWindowSize(window.windowPtr, out w, out h);

            int center_x = (w / 2);
            int center_y = (h / 2);

            TextElement menu_text = new TextElement(this, "TOWER BLOCKS", 0, 0);
            menu_text.FontSize = 64;
            menu_text.FontName = "VCR_OSD_MONO_1.001.ttf";

            menu_text.x = center_x - (menu_text.width / 2);
            menu_text.y = center_y - (menu_text.height / 2) - 200;

            TextElement menu_description = new TextElement(this, "Select a difficulty", 0, 0);
            menu_description.FontSize = 32;

            menu_description.x = center_x - (menu_description.width / 2);
            menu_description.y = center_y - (menu_description.height / 2) - 150;

            MenuButton b_easy = new Button_DifficultySelect(this, "Easy", 0, 0, 300);

            b_easy.x = center_x - (b_easy.width / 2);
            b_easy.y = center_y - (b_easy.height / 2) - 50;

            MenuButton b_medium = new Button_DifficultySelect(this, "Medium", 0, 0, 300);

            b_medium.x = center_x - (b_medium.width / 2);
            b_medium.y = center_y - (b_medium.height / 2) + 50;

            MenuButton b_hard = new Button_DifficultySelect(this, "Hard", 0, 0, 300);

            b_hard.x = center_x - (b_hard.width / 2);
            b_hard.y = center_y - (b_hard.height / 2) + 150;

            Element_Image gabe = new Element_Image(this, "gabe.jpg");

            gabe.width = 360;
            gabe.height = 202;

            gabe.x = center_x - (gabe.width / 2);
            gabe.y = center_y - (gabe.height / 2) + 300;
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
