using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using Math_Library;
namespace MathForGames
{
    class Player : Actor
    {
        private Sprite sprite;
        private float _speed = 3;
        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
        {
            sprite = new Sprite("Images/player.png");
        }
        public Player(float x, float y, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, raycolor, icon, color)
        {
            sprite = new Sprite("Images/player.png");
        }

        public override void Update(float deltaTime)
        {


            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A)) +
                Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));

            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W)) +
                Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            Accelration = new Vector2(xVelocity, yVelocity);
           

            base.Update(deltaTime);

        }

        public override void Draw()
        {
            sprite.Draw(_localtransform);
            base.Draw();
        }
    }
}
