using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    public class Platform : GameObject
    {
        private readonly RectangleShape _shape;

        public Platform(float x, float y, float width)
        {
            AssignTag("platform");

            _shape = new RectangleShape(new Vector2f(width, 18));
            _shape.Position = new Vector2f(x, y);
            _shape.FillColor = new Color(95, 211, 168);
            _shape.OutlineColor = new Color(226, 252, 219);
            _shape.OutlineThickness = 2;
        }

        public float Top
        {
            get { return _shape.Position.Y; }
        }

        public override void Update(Time elapsed)
        {
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_shape);
        }

        public override FloatRect GetCollisionRect()
        {
            return _shape.GetGlobalBounds();
        }
    }
}
