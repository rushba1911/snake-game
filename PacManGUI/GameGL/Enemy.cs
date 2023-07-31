using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    abstract class Enemy : GameObject
    {
        public Enemy(Image image, GameCell startCell):base (GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
        }
        public abstract GameCell Move();
        public abstract void checkdirection();

    }
}

