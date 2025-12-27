using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiFinalGame.Interfaces
{
    public interface IMovable
    {
        // Velocity of the object
        PointF Velocity { get; set; }
    }
}
