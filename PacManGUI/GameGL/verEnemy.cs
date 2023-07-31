using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class verEnemy : Enemy
    {
        public GameDirection direction = GameDirection.Down;
        public verEnemy(Image displayChar, GameCell start) : base(displayChar, start)
        {
            this.CurrentCell=start;
        }

        public override void checkdirection()
        {
            if (direction == GameDirection.Down)
            {
                direction = GameDirection.Up;
            }
            else if (direction == GameDirection.Up)
            {
                direction = GameDirection.Down;
            }
        }
        public override GameCell Move()
        {
            GameCell CurrentCell = this.CurrentCell;
            GameCell nextCell = CurrentCell.nextCell(direction);
            this.CurrentCell = nextCell;
            if (CurrentCell==nextCell)
            {
                checkdirection();
            }
            if(CurrentCell!=nextCell && (nextCell.CurrentGameObject?.GameObjectType != GameObjectType.WALL))
            {
                CurrentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;
        }
    }
}
