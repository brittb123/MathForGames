using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using Math_Library;
namespace MathForGames
{
   public class Player : Actor
    {
        private Sprite sprite;
        private float _speed = 1;
       
        
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
            _collideradius = 2;
        }
        public Player(float x, float y, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, raycolor, icon, color)
        {
            sprite = new Sprite("Images/player.png");
            _collideradius = 2;
        }

        public override void Update(float deltaTime)
        {
           int xDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));
            int yDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));


            Accelration = new Vector2(xDirection, yDirection);
            if (Velocity.Magnitude > MaxSpeed)
            {
                Velocity = Velocity.Normalized * MaxSpeed;
            }

            Velocity = Velocity.Normalized * Speed;

            base.Update(deltaTime);

        }

        public override void Draw()
        {
            sprite.Draw(_localtransform);
            base.Draw();
        }
    }
}
