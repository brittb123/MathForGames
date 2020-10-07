using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    
    class Scene
    {
        private Actor[] _actors;
        public Scene()
        {
            _actors = new Actor[0];
        }

        public void AddActor(Actor actor)
        {
            Actor[] someArray = new Actor[_actors.Length + 1];
            for(int i = 0; i < _actors.Length; i++)
            {
                someArray[i] = _actors[i];

            }
            someArray[_actors.Length] = actor;
            _actors = someArray;
        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

        public void End()
        {

        }
    }

    
}
