using GameEngine;
using SFML.System;

namespace MyGame
{
    public class StarSpawner : GameObject
    {
        private readonly GameState _gameState;
        private float _timer = 1;

        public StarSpawner(GameState gameState)
        {
            _gameState = gameState;
        }

        public override void Update(Time elapsed)
        {
            if (_gameState.GameOver)
            {
                return;
            }

            _timer -= elapsed.AsSeconds();

            if (_timer <= 0)
            {
                Game.CurrentScene.AddGameObject(new FallingStar(_gameState));
                _timer = (float)Game.Random.NextDouble() + 0.4f;
            }
        }
    }
}
