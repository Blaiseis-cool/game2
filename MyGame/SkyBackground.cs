using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    public class SkyBackground : GameObject
    {
        private readonly RectangleShape _sky = new RectangleShape(new Vector2f(800, 600));
        private readonly CircleShape _star1 = new CircleShape(2);
        private readonly CircleShape _star2 = new CircleShape(2);
        private readonly CircleShape _star3 = new CircleShape(2);
        private readonly CircleShape _star4 = new CircleShape(2);
        private readonly CircleShape _star5 = new CircleShape(2);
        private readonly CircleShape _star6 = new CircleShape(2);
        private readonly CircleShape _star7 = new CircleShape(2);
        private readonly CircleShape _star8 = new CircleShape(2);

        public SkyBackground()
        {
            _sky.FillColor = Color.Black;

            SetupStar(_star1, 80, 80);
            SetupStar(_star2, 240, 170);
            SetupStar(_star3, 410, 60);
            SetupStar(_star4, 690, 130);
            SetupStar(_star5, 130, 330);
            SetupStar(_star6, 520, 270);
            SetupStar(_star7, 730, 390);
            SetupStar(_star8, 340, 460);
        }

        public override void Update(Time elapsed)
        {
            float move = 35 * elapsed.AsSeconds();

            MoveStar(_star1, move);
            MoveStar(_star2, move);
            MoveStar(_star3, move);
            MoveStar(_star4, move);
            MoveStar(_star5, move);
            MoveStar(_star6, move);
            MoveStar(_star7, move);
            MoveStar(_star8, move);
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sky);
            Game.RenderWindow.Draw(_star1);
            Game.RenderWindow.Draw(_star2);
            Game.RenderWindow.Draw(_star3);
            Game.RenderWindow.Draw(_star4);
            Game.RenderWindow.Draw(_star5);
            Game.RenderWindow.Draw(_star6);
            Game.RenderWindow.Draw(_star7);
            Game.RenderWindow.Draw(_star8);
        }

        private void SetupStar(CircleShape star, float x, float y)
        {
            star.Position = new Vector2f(x, y);
            star.FillColor = Color.White;
        }

        private void MoveStar(CircleShape star, float move)
        {
            star.Position = new Vector2f(star.Position.X, star.Position.Y + move);

            if (star.Position.Y > 600)
            {
                star.Position = new Vector2f(Game.Random.Next(20, 760), -10);
            }
        }
    }
}
