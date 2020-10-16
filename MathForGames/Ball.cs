using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Ball : Actor
    {
        public Ball(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x, y, icon, color)
        {

        }
        public bool Collide(Actor actor)
        {
            
            if (actor.Position.X == Position.X)
            {
                _position.X--;
                return true;
            }
            return false;
        }

        
        public override void Update()
        {
            
            base.Update();
        }
    }
    
}
