using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacMan.GameGL;
using EZInput;
using PacManGUI.Properties;

namespace PacManGUI
{
    public partial class Form1 : Form
    {
        public static int Score = 0;
        public static int Health = 5;

        GamePacManPlayer pacman;
        verEnemy verenemy;
        horEnemy horenemy;
        RandomG randenemy;
        Smart smartenemy;
        public Form1()
        {
            InitializeComponent();
        }        
        private void Form1_Load(object sender, EventArgs e)
        {
            GameGrid grid = new GameGrid("maze.txt", 22, 58);
            Image pacManImage = Game.getGameObjectImage('P');
            Image verGhostImg = Game.getGameObjectImage('V');
            Image horGhostImg = Game.getGameObjectImage('H');
            Image ranGhostImg = Game.getGameObjectImage('R');
            Image smartGhostImg = Game.getGameObjectImage('S');

            GameCell startCell = grid.getCell(12,22);
            GameCell verstartCell = grid.getCell(2,33);
            GameCell horstartCell = grid.getCell(16,45);
            GameCell randstartCell = grid.getCell(8,40);
            GameCell smartstartCell = grid.getCell(5,4);

            pacman    = new GamePacManPlayer(pacManImage, startCell);
            verenemy  = new verEnemy(verGhostImg, verstartCell);
            horenemy  = new horEnemy(horGhostImg, horstartCell);
            randenemy = new RandomG(ranGhostImg, randstartCell);
            smartenemy= new Smart(smartGhostImg, smartstartCell,pacman);

            printMaze(grid);
        }



        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
               
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);          
                }

            }
        }
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                pacman.move(GameDirection.Up);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                pacman.move(GameDirection.Down);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                pacman.move(GameDirection.Right);
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pacman.move(GameDirection.Left);
            }
            verenemy.Move();
            horenemy.Move();
            smartenemy.Move();
            randenemy.Move();
            textBox1.Text = Score.ToString();
            textBox2.Text = Health.ToString();
        }
        public static void DecreaseHealth()
        {
            if (Health == 0)
            {
                Lose l = new Lose();
                Form1 form1 = new Form1();
                form1.Close();
                l.Show();
            }
            Health -= 1;
        }
        public static void increaseScore()
        {
            if (Score == 100)
            {
                Win w = new Win();
                Form1 form1 = new Form1();
                form1.Close();
                w.Show();
            }
            Score += 1;
        }
        public static void increaseScoreBY2()
        {
            if (Score == 100)
            {
                Win w = new Win();
                Form1 form1 = new Form1();
                form1.Close();
                w.Show();
            }
            Score += 2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblLive_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
