using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    class SaveObject
    {
        public BallController BallController { get; set; }
        public Plane Plane { get; set; }
    }
}
