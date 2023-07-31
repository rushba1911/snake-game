using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PacManGUI.Properties;
using PacManGUI;

namespace PacMan.GameGL
{
    class GamePacManPlayer : GameObject
    {
        public GamePacManPlayer(Image image,GameCell startCell):base (GameObjectType.PLAYER,image) {
            this.CurrentCell = startCell;
        }
        public void move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell= currentCell.nextCell(direction);

            if (nextCell != currentCell && nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                if (Collision.CheckCollision(nextCell))
                {
                    if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                    {
                        Form1.DecreaseHealth();
                        nextCell.setGameObject(Game.getBlankGameObject());
                        return;
                    }
                    else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                    {
                        Form1.increaseScore();
                        nextCell.setGameObject(Game.getBlankGameObject());
                    }
                    else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENERGIZERS)
                    {
                        Form1.increaseScoreBY2();
                        nextCell.setGameObject(Game.getBlankGameObject());
                    }
                }

                this.CurrentCell = nextCell;
                currentCell.setGameObject(Game.getBlankGameObject());
            }
        }

    }

    
}
