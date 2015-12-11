using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Project_Tetra
{
    class Zinv : Formes
    {
        public override void initForme(Rectangle[,] grille)
        {
            for (int i = 0; i < this.CoordoneesX.Count; i++)
            {
                for (int j = 0; j < this.CoordoneesY.Count; j++)
                {
                    if (i == 0 && j == 0)
                    { }
                    else if (i == 1 && j == 2)
                    { }
                    else
                    {
                        grille[this.CoordoneesX[i], this.CoordoneesY[j]].Fill = Brushes.BlueViolet;
                    }
                }
            }
        }

        public override void SetCoordoneesX()
        {
            CoordoneesX.Add(0);
            CoordoneesX.Add(1);
        }
        public override void SetCoordoneesY()
        {
            CoordoneesY.Add(4);
            CoordoneesY.Add(5);
            CoordoneesY.Add(6);
        }

        public override void DownCoordonees(Rectangle[,] grille)
        {
            grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.White;
            grille[this.CoordoneesX[0], this.CoordoneesY[1]].Fill = Brushes.White;
            grille[this.CoordoneesX[0], this.CoordoneesY[2]].Fill = Brushes.White;

            for (int i = 0; i < this.CoordoneesX.Count; i++)
            {

                this.CoordoneesX[i] = this.CoordoneesX[i] + 1;

            }
            grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.BlueViolet;
            grille[this.CoordoneesX[1], this.CoordoneesY[1]].Fill = Brushes.BlueViolet;
            grille[this.CoordoneesX[0], this.CoordoneesY[2]].Fill = Brushes.BlueViolet;
            grille[this.CoordoneesX[0], this.CoordoneesY[1]].Fill = Brushes.BlueViolet;
        }

        public override void RightCoordonee(Rectangle[,] grille)
        {
            if (this.CoordoneesY[2] != 9)
            {
                grille[this.CoordoneesX[0], this.CoordoneesY[1]].Fill = Brushes.White;
                grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.White;
                for (int i = 0; i < this.CoordoneesY.Count; i++)
                {

                    this.CoordoneesY[i] = this.CoordoneesY[i] + 1;

                }
                grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.BlueViolet;
                grille[this.CoordoneesX[1], this.CoordoneesY[1]].Fill = Brushes.BlueViolet;
                grille[this.CoordoneesX[0], this.CoordoneesY[2]].Fill = Brushes.BlueViolet;
                grille[this.CoordoneesX[0], this.CoordoneesY[1]].Fill = Brushes.BlueViolet;
            }
        }
        public override void LeftCoordonee(Rectangle[,] grille)
        {

            if (this.CoordoneesY[0] != 0)
            {
                grille[this.CoordoneesX[0], this.CoordoneesY[2]].Fill = Brushes.White;
                grille[this.CoordoneesX[1], this.CoordoneesY[1]].Fill = Brushes.White;
                for (int i = 0; i < this.CoordoneesY.Count; i++)
                {

                    this.CoordoneesY[i] = this.CoordoneesY[i] - 1;

                }
                grille[this.CoordoneesX[1], this.CoordoneesY[0]].Fill = Brushes.BlueViolet;
                grille[this.CoordoneesX[1], this.CoordoneesY[1]].Fill = Brushes.BlueViolet;
                grille[this.CoordoneesX[0], this.CoordoneesY[2]].Fill = Brushes.BlueViolet;
                grille[this.CoordoneesX[0], this.CoordoneesY[1]].Fill = Brushes.BlueViolet;
            }
        }
        public override bool GaucheForme(Rectangle[,] grille)
        {
            if (grille[this.CoordoneesX[1], this.CoordoneesY[0] - 1].Fill == Brushes.White && grille[this.CoordoneesX[0], this.CoordoneesY[1] - 1].Fill == Brushes.White)
            {
                return true;
            }
            return false;
        }

        public override bool DroiteForme(Rectangle[,] grille)
        {
            if (grille[this.CoordoneesX[0], this.CoordoneesY[2] + 1].Fill == Brushes.White && grille[this.CoordoneesX[1], this.CoordoneesY[1] + 1].Fill == Brushes.White)
            {
                return true;
            }
            return false;
        }
        public override bool ArretForme(Rectangle[,] grille)
        {
            if (grille[this.CoordoneesX[1] + 1, this.CoordoneesY[0]].Fill == Brushes.White && grille[this.CoordoneesX[1] + 1, this.CoordoneesY[1]].Fill == Brushes.White && grille[this.CoordoneesX[0] + 1, this.CoordoneesY[2]].Fill == Brushes.White)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
