using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public interface IAnimation
{
        public void AnimStationary(double x, double y);
        public void AnimMoving(double x, double y);

        public void AnimAttack(double x, double y);

        public void AnimItem(double x, double y);
        void Update();
    }
}
