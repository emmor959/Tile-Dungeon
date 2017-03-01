using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace Minesweeper
{
    
    public class Transparency
    {
      public Transparency()
        {

        }

        private System.Drawing.Bitmap[,] Rat_enemy = new System.Drawing.Bitmap[4];
        private System.Drawing.Bitmap[,] Health = new System.Drawing.Bitmap[1];
        public void Yas()
        {
            int i = 0;
            int j = 0;
            //     for (j = 0; j <= 1; j++)
            for (int e = 0; e <= 1; e++)
            {

                Health[e].MakeTranspatent(Color.White);
            }
           for (i = 0; i <= 4; i++)
           {

                    Rat_enemy[i].MakeTransparent(Color.White);

           }
            
            
        }
        public void clsRatEnemy()
        {
            Rat_enemy[1] = Minesweeper.Properties.Resources.Rat(Back);
            Rat_enemy[2] = Minesweeper.Properties.Resources.Rat(Left);
            Rat_enemy[3] = Minesweeper.Properties.Resources.Rat(Right);
            Rat_enemy[4] = Minesweeper.Properties.Resources.Rat(Front);

        }
        public BitConverter Rat()
        {
            return Rat_enemy[1];
        }
        public void HpPotion()
        {
            Health[1] = Minesweeper.Properties.Resources.Health_Potion;
        }
    }
}
    
