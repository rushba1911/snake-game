using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGUI.Properties
{
    public static class Collision
    {
        public static bool CheckCollision(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.ENERGIZERS || cell.CurrentGameObject.GameObjectType == GameObjectType.REWARD || cell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
            {
                return true;
            }
            return false;
        }
    }
}
