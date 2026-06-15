using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    public class Gem : GameObject
    {
        private readonly CircleShape _shape = new CircleShape(10, 5);
        private readonly GameState _gameState;

        public Gem(GameState gameState, float x, float y)
        {
            _gameState = gameState;

            AssignTag("gem");
            SetCollisionCheckEnabled(true);

            _shape.Origin = new Vector2f(10, 10);
            _shape.Position = new Vector2f(x, y);
            _shape.FillColor = new Color(255, 213, 79);
            _shape.OutlineColor = new Color(255, 248, 196);
            _shape.OutlineThickness = 2;
        }

        public override void Update(Time elapsed)
        {
            _shape.Rotation += 120 * elapsed.AsSeconds();
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
                MakeDead();
            }
        }
    }
}
