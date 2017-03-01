using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace Pictures
{
    
    public class Class1
    {
        Rat[] = Minesweeper.Properties.Resources.Rat;

        private System.Drawing.Bitmap[,] Rat_enemy = new System.Drawing.Bitmap[4];
        private System.Drawing.Bitmap[,] Health = new System.Drawing.Bitmap[4];
        public int Yas()
        {
            int i = 0;
            int j = 0;
            for (j = 0; j <= 1; j++)
            {
                for (i = 0; i <= 5; i++)
                {
                    return Health[i, j].MakeTranspatent(Color.White) & Rat_enemy[i, j].MakeTransparent(Color.White);

                }
            }
        }
    }
}
    
