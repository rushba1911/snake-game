using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PacManGUI;

namespace PacMan.GameGL
{
    public class Game
    {
        public static GameObject getBlankGameObject(){
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, PacManGUI.Properties.Resources.simplebox);
            return blankGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = PacManGUI.Properties.Resources.simplebox;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                img = Resource1.VerBar;
            }

            if (displayCharacter == '#')
            {
                img = Resource1.HorBar;
            }

            if (displayCharacter == '.')
            {
                img = Resource1.cake;
            }
            if (displayCharacter == '-')
            {
                img = Resource1.energizer;
            }
            if (displayCharacter == 'P' || displayCharacter == 'p') {
                img = Resource1.cutesnake;
            }
            if (displayCharacter == 'V' || displayCharacter == 'v')
            {
                img = Resource1.bluesnake;
            }
            if (displayCharacter == 'H' || displayCharacter == 'h')
            {
                img = Resource1.angrysnake;
            }
            if (displayCharacter == 'R' || displayCharacter == 'r')
            {
                img = Resource1.cobra;
            }
            if (displayCharacter == 'S' || displayCharacter == 's')
            {
                img = Resource1.dragon;
            }

            return img;
        }
    }
}
