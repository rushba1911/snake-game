using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.GameGL
{
     class RandomG : Enemy
     {
        public GameDirection direction;
        public RandomG(char displayChar, GameCell start) : base(displayChar, start) { }
    
        public void setDirection()
        {
            int val = randDirection();
            if(val==0 )
            {
                direction = GameDirection.Left;
            }
            if(val==1)
            {
                direction = GameDirection.Right;

            }
            if (val == 2)
            {
                direction = GameDirection.Up;

            }
            if (val == 3)
            {
                direction = GameDirection.Down;

            }
        }
        public override void checkdirection()
        {
            if(direction == GameDirection.Left)
            {
                direction = GameDirection.Right;
            }
            else if(direction == GameDirection.Right)
            {
                direction = GameDirection.Left;
            }
            if (direction == GameDirection.Up)
            {
                direction = GameDirection.Down;
            }
            else if (direction == GameDirection.Down)
            {
                direction = GameDirection.Up;
            }
        }
        public override GameCell Move()
        {
            setDirection();
            GameCell nextCell = this.currentCell.nextCell(direction);
            return nextCell;
        }
        public  int randDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
    }
}
