using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyGame
{
    public class HumanPlayer : GameObject
    {
        private const float MoveSpeed = 320;

        private readonly RectangleShape _shape = new RectangleShape(new Vector2f(60, 60));

        private float _x = 370;

        public HumanPlayer()
        {
            AssignTag("player");
            SetCollisionCheckEnabled(true);

            _shape.Position = new Vector2f(_x, 520);
            _shape.FillColor = Color.Red;
        }

        public override void Update(Time elapsed)
        {
            float seconds = elapsed.AsSeconds();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) || Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                _x -= MoveSpeed * seconds;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) || Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                _x += MoveSpeed * seconds;
            }

            _x = Clamp(_x, 0, 740);
            _shape.Position = new Vector2f(_x, 520);
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_shape);
        }

        public override FloatRect GetCollisionRect()
        {
            return _shape.GetGlobalBounds();
        }

        private float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
