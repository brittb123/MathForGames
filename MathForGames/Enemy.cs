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
        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/Enemy.png");
        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _alertColor = Color.RED;
            _sprite = new Sprite("Images/Enemy.png");
        }

        public void EnemyLoop(float x, float y, float radians)
        {
          
            if (this.localPosition.X == x && this.localPosition.Y == y)
            {
                for (int i = 0; radians < 2; i++)
                {
                    this.Rotate(1 / 2);
                }
            }
        }

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
          
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_localtransform);
            base.Draw();
        }
    }
}