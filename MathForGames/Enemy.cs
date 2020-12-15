using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using Math_Library;

namespace MathForGames
{
     class Enemy : Actor
    {
        private Player Player { get; set; }
        private Actor _target;
        private Color _alertColor;
        private Sprite _sprite;
        private float enemyCount;
        
        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/Enemy.png");
            _collideradius = 1;
        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
           
            _sprite = new Sprite("Images/Enemy.png");
            _collideradius = 1;
            Velocity.Y = 6;
        }


        // The enemy will loop at a certain chosen point of the screen
        public void EnemyLoop(float x, float y, float radians)
        {
          
            if (localPosition.X == x && localPosition.Y == y)
            {
                for (int i = 0; radians < 2; i++)
                {
                    this.Velocity.X = 0;
                    this.Velocity.Y = 0;
                   Rotate(1);
                    radians++;
                }
            }
        }
       

        //Checks to see if the player or a different target is in line of sight for attacking
        public bool CheckTargetInSight(float maxAngle, float maxDistance)
        {
            if (Target == null)
                return false;


            Vector2 direction = Target.localPosition - localPosition;
            float distance = direction.Magnitude;
            float angle = (float)Math.Acos(Vector2.DotProduct(Forward, direction.Normalized));

            if (angle <= maxAngle && distance <= maxDistance)
                return true;

            return false;
        }

        public override void Update(float deltaTime)
        {
            _sprite.Draw(_localtransform);
            if (CheckTargetInSight(1.5f, 5))
            {
                _rayColor = Color.RED;
            }
            else
            {
                _rayColor = Color.BLUE;
            }

            EnemyLoop(5, 5, 0);
          
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_localtransform);
            base.Draw();
        }
    }
}