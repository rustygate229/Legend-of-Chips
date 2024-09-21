using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public interface IAnimation
{
        public void AnimUpStationary();
        public void AnimDownStationary();
        public void AnimLeftStationary();
        public void AnimRightStationary();
        public void AnimUpMoving();
        public void AnimDownMoving();
        public void AnimLeftMoving();
        public void AnimRightMoving();

    }
}
