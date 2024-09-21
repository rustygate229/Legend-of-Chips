using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public interface IAnimation
{
        public void AnimUpStationary(double x, double y);
        public void AnimDownStationary(double x, double y);
        public void AnimLeftStationary(double x, double y);
        public void AnimRightStationary(double x, double y);
        public void AnimUpMoving(double x, double y);
        public void AnimDownMoving(double x, double y);
        public void AnimLeftMoving(double x, double y);
        public void AnimRightMoving(double x, double y);

    }
}
