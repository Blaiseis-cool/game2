using GameEngine;

namespace MyGame
{
    public class GameOverScene : Scene
    {
        public GameOverScene(int score)
        {
            AddGameObject(new GameOverMessage(score));
        }
    }
}
