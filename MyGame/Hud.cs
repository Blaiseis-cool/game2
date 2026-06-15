using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    public class Hud : GameObject
    {
        private readonly Text _statusText;
        private readonly GameState _gameState;

        public Hud(GameState gameState)
        {
            _gameState = gameState;

            Font font = Game.GetFont("Resources/Courneuf-Regular.ttf");

            _statusText = new Text("", font, 24);
            _statusText.Position = new Vector2f(16, 12);
            _statusText.FillColor = Color.White;

        }

        public override void Update(Time elapsed)
        {
            _statusText.DisplayedString = "Score: " + _gameState.Score + "   Lives: " + _gameState.Lives;
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_statusText);

        }
    }
}
