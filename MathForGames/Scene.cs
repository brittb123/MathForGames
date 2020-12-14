using Math_Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    
    public class Scene
    {
        private Actor[] _actors;
        public bool Started { get; private set; }
        private Matrix3 _transform;

        public Matrix3 World
        {
            get { return _transform; }
        }
        public Scene()
        {
            _actors = new Actor[0];
        }

        public void AddActor(Actor actor)
        {
            //Creates a new array larger than the Actor array
            Actor[] someArray = new Actor[_actors.Length + 1];
            //Copys values from old array to the new array
            for(int i = 0; i < _actors.Length; i++)
            {
                someArray[i] = _actors[i];

            }
            //Sets the actor to the last value of the array
            someArray[_actors.Length] = actor;
            //Set the old array equal to the new array
            _actors = someArray;
        }

        public bool RemoverActor(int index)
        {
            //Checks if the index is in the bounds of the array
            if(index < 0 || index >= _actors.Length)
            {
                
                return false;
            }
            bool actorRemoved = false;
            // A value to keep the temporary array from hittinh out of bounds while removing the actor
            int j = 0;
            //Create a new smaller array with one less than the base actors array
            Actor[] tempArray = new Actor[_actors.Length - 1];
            //Copies values from the old array to the new array
            for (int i = 0; i < _actors.Length; i++)
            {
                // if i does not equal index both arrays are added by 1 until i is the the index, which skips the j increment that removes
                if(i != index)
                {
                    tempArray[j] = _actors[i];
                        j++;
                }
                else
                {
                    actorRemoved = true;
                }
            }
            
            _actors = tempArray;
            return actorRemoved;
        }

        public bool RemoveActor(Actor actor)
        {
            if (actor == null)
            {
                return false;
            }
            bool actorRemoved = false;
            //Create a new smaller array with one less than the base actors array
            Actor[] tempArray = new Actor[_actors.Length - 1];

            int j = 0;
            //Copies values from the old array to the new array
            for (int i = 0; i < _actors.Length; i++)
            {
                // if the actor that needs to be removed is not equal to i of the old array, both arrays are added by 1 until i is the the index, 
                //which skips the j increment that removes
                if (actor != _actors[i])
                {
                    tempArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (_actors[i].Started)
                        _actors[i].End();
                }
            }

            _actors = tempArray;
            return actorRemoved;
        }

        private void CheckCollision()
        {
           for(int i = 0; i < _actors.Length; i++)
            {
                for(int j = 0; j < _actors.Length; j++)
                _actors[i].CheckCollision(_actors[j]);
                
            }
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Started)
                    _actors[i].Start();
                   CheckCollision();
              
                _actors[i].Update(deltaTime);
                
            }
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        public virtual void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
             if (_actors[i].Started)
                 _actors[i].End();
            }
            Started = false;
        }
    }

    
}
