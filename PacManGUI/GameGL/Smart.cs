using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    internal class Smart : Enemy
    {
        public GameDirection direction=GameDirection.Up;
        public GameObject player;
        public Smart(Image img, GameCell start, GameObject player) : base(img, start)
        {
            this.player = player;
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
            if (direction == GameDirection.Up)
            {
                direction = GameDirection.Down;
            }
            else if (direction == GameDirection.Down)
            {
                direction = GameDirection.Up;
            }
        }
        public void chkNsetDistanceVal()
        {
            double[] distance = new double[4] { 10000, 10000, 10000, 10000 };
            if (this.CurrentCell.nextCell(GameDirection.Left).CurrentGameObject.GameObjectType == GameObjectType.NONE ||
              this.CurrentCell.nextCell(GameDirection.Left).CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                distance[0] = calDistance(this.CurrentCell.nextCell(GameDirection.Left));
            }
            if (this.CurrentCell.nextCell(GameDirection.Right).CurrentGameObject.GameObjectType == GameObjectType.NONE ||
             this.CurrentCell.nextCell(GameDirection.Right).CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                distance[1] = calDistance(this.CurrentCell.nextCell(GameDirection.Right));
            }
            if (this.CurrentCell.nextCell(GameDirection.Up).CurrentGameObject.GameObjectType == GameObjectType.NONE ||
            this.CurrentCell.nextCell(GameDirection.Up).CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                distance[2] = calDistance(this.CurrentCell.nextCell(GameDirection.Up));
            }
            if (this.CurrentCell.nextCell(GameDirection.Down).CurrentGameObject.GameObjectType == GameObjectType.NONE ||
            this.CurrentCell.nextCell(GameDirection.Down).CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                distance[3] = calDistance(this.CurrentCell.nextCell(GameDirection.Down));
            }
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                this.direction = GameDirection.Left;

            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                this.direction = GameDirection.Right;

            }
            if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                this.direction = GameDirection.Up;

            }
            if (distance[3] <= distance[0] && distance[3] <= distance[1] && distance[3] <= distance[2])
            {
                this.direction = GameDirection.Down;

            }

        }
        public override GameCell Move()
        {
            chkNsetDistanceVal();
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
            else
            {
                checkdirection();
            }
            return nextCell;

        }
        public double calDistance(GameCell nextcell)
        {
            return Math.Sqrt(Math.Pow((player.CurrentCell.X - nextcell.X), 2) + Math.Pow((player.CurrentCell.Y - nextcell.Y), 2));
        }
    }
}
