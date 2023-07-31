using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class horEnemy : Enemy
    {
        public GameDirection direction = GameDirection.Left;
        public horEnemy(Image displayChar, GameCell start) : base(displayChar, start) 
        { 
            this.CurrentCell = start; 
        }
        public override void checkdirection()
        {
            if (direction == GameDirection.Left)
            {
                direction = GameDirection.Right;
            }
            else if (direction == GameDirection.Right)
            {
                direction = GameDirection.Left;
            }
        }
        public override GameCell Move()
        {
            GameCell CurrentCell = this.CurrentCell;
            GameCell nextCell = CurrentCell.nextCell(direction);
            this.CurrentCell = nextCell;
            if (CurrentCell == nextCell)
            {
                checkdirection();
            }
            if (CurrentCell != nextCell && (nextCell.CurrentGameObject?.GameObjectType != GameObjectType.WALL))
            {
                CurrentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;

        }
    }
}

