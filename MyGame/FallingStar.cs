using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    public class FallingStar : GameObject
    {
        private readonly CircleShape _shape = new CircleShape(14, 5);
        private readonly GameState _gameState;
        private readonly Sound _catchSound;
        private readonly float _speed;

        public FallingStar(GameState gameState)
        {
            _gameState = gameState;
            _speed = Game.Random.Next(130, 260);

            AssignTag("star");
            SetCollisionCheckEnabled(true);

            _shape.Origin = new Vector2f(14, 14);
            _shape.Position = new Vector2f(Game.Random.Next(25, 760), -30);
            _shape.FillColor = new Color(255, 225, 92);
            _shape.OutlineColor = Color.White;
            _shape.OutlineThickness = 2;

            _catchSound = new Sound(Game.GetSoundBuffer("Resources/boom.wav"));
        }

        public override void Update(Time elapsed)
        {
            if (_gameState.GameOver)
            {
                return;
            }

            _shape.Position = new Vector2f(_shape.Position.X, _shape.Position.Y + _speed * elapsed.AsSeconds());

            if (_shape.Position.Y > 620)
            {
                _gameState.Lives -= 1;

                if (_gameState.Lives <= 0)
                {
                    _gameState.Lives = 0;
                    _gameState.GameOver = true;
                    Game.SetScene(new GameOverScene(_gameState.Score));
                }

                MakeDead();
            }
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_shape);
        }

        public override FloatRect GetCollisionRect()
        {
            return _shape.GetGlobalBounds();
        }

        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("player"))
            {
                _gameState.Score += 1;
                _catchSound.Play();
                MakeDead();
            }
        }
    }
}
