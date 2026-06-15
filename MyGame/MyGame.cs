using GameEngine;

namespace MyGame
{
    public static class MyGame
    {
        private const int WindowWidth = 800;
        private const int WindowHeight = 600;

        private const string WindowTitle = "Star Catcher";

        public static void Main(string[] args)
        {
            // Initialize the game.
            Game.Initialize(WindowWidth, WindowHeight, WindowTitle);

            // Create our scene.
            GameScene scene = new GameScene();
            Game.SetScene(scene);

            // Run the game loop.
            Game.Run();
        }
    }
}
