using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyGame
{
    public class JumperPlayer : GameObject
    {
        private const float Gravity = 1150;
        private const float MoveSpeed = 260;
        private const float JumpSpeed = -520;

        private readonly RectangleShape _shape = new RectangleShape(new Vector2f(34, 42));
        private readonly GameState _gameState;

        private Vector2f _startPosition;
        private Vector2f _velocity = new Vector2f(0, 0);
        private bool _isOnGround = false;
        private bool _wasFalling = false;
        private float _previousBottom = 0;

        public JumperPlayer(GameState gameState, float x, float y)
        {
            _gameState = gameState;
            _startPosition = new Vector2f(x, y);

            AssignTag("player");
            SetCollisionCheckEnabled(true);

            _shape.Position = _startPosition;
            _shape.FillColor = new Color(89, 169, 255);
            _shape.OutlineColor = Color.White;
            _shape.OutlineThickness = 2;
        }

        public override void Update(Time elapsed)
        {
            if (_gameState.GameOver)
            {
                return;
            }

            float seconds = elapsed.AsSeconds();
            float moveX = 0;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) || Keyboard.IsKeyPressed(Keyboard.Key.A)) moveX -= 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) || Keyboard.IsKeyPressed(Keyboard.Key.D)) moveX += 1;

            _velocity.X = moveX * MoveSpeed;

            if ((Keyboard.IsKeyPressed(Keyboard.Key.Up) || Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Space)) && _isOnGround)
            {
                _velocity.Y = JumpSpeed;
                _isOnGround = false;
            }

            _velocity.Y += Gravity * seconds;
            _wasFalling = _velocity.Y >= 0;
            _previousBottom = _shape.Position.Y + _shape.Size.Y;

            _shape.Position = new Vector2f(
                Clamp(_shape.Position.X + _velocity.X * seconds, 0, 800 - _shape.Size.X),
                _shape.Position.Y + _velocity.Y * seconds
            );

            if (_shape.Position.Y > 600)
            {
                ResetPlayer();
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
            Platform platform = otherGameObject as Platform;

            if (platform != null && _wasFalling && _previousBottom <= platform.Top + 8)
            {
                _shape.Position = new Vector2f(_shape.Position.X, platform.Top - _shape.Size.Y);
                _velocity.Y = 0;
                _isOnGround = true;
            }
        }

        private void ResetPlayer()
        {
            _gameState.Lives -= 1;

            if (_gameState.Lives <= 0)
            {
                _gameState.Lives = 0;
                _gameState.GameOver = true;
            }

            _shape.Position = _startPosition;
            _velocity = new Vector2f(0, 0);
            _isOnGround = false;
        }

        private float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
