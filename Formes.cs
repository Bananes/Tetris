using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Project_Tetra
{
    abstract class Formes
    {
        public List<int> CoordoneesX = new List<int>();
        public List<int> CoordoneesY = new List<int>();
        public Formes()
        { }

        public virtual void initForme(Rectangle[,] grille)
        {
        }

        public virtual void SetCoordoneesX()
        {
        }
        public virtual void SetCoordoneesY()
        {
        }

        public virtual void DownCoordonees(Rectangle[,] grille)
        {
        }

        public virtual void RightCoordonee(Rectangle[,] grille)
        {
        }
        public virtual void LeftCoordonee(Rectangle[,] grille)
        {}
        public virtual bool DroiteForme(Rectangle[,] grille)
        {
            return true;
        }
        public virtual bool GaucheForme(Rectangle[,] grille)
        {
            return true;
        }
        public virtual bool ArretForme(Rectangle[,] grille)
        {
            return true;
        }
    }
}
