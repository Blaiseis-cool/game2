using GameEngine;

namespace MyGame
{
    public class GameScene : Scene
    {
        public GameScene()
        {
            GameState gameState = new GameState();

            AddGameObject(new SkyBackground());
            AddGameObject(new HumanPlayer());
            AddGameObject(new StarSpawner(gameState));
            AddGameObject(new Hud(gameState));
        }
    }
}
