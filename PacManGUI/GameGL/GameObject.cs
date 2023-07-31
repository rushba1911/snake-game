﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace PacMan.GameGL
{
    public class GameObject
    {
        public char displayCharacter;
        GameObjectType gameObjectType;
        GameCell currentCell;
        Image image;
        public GameObject(GameObjectType type, Image image)
        {
            this.gameObjectType = type;
            this.Image = image; 
        }
       
        public static GameObjectType getGameObjectType(char displayCharacter) { 

            if (displayCharacter == '|' || displayCharacter == '%' || displayCharacter == '#') {
                return GameObjectType.WALL;
            }
            if (displayCharacter == '.') {
                return GameObjectType.REWARD;
            }
            if (displayCharacter == '-')
            {
                return GameObjectType.ENERGIZERS;
            }

            return GameObjectType.NONE;
        }
        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value; }
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }
        public GameCell CurrentCell { 
            get => currentCell; 
            set  { 
                currentCell = value;
                currentCell.setGameObject(this);
            }
        }

        public Image Image { get => image; set => image = value; }
    }
}
