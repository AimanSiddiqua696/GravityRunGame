using SemiFinalGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiFinalGame.Interfaces
{
    internal class ICollidable
    {
        // Bounds of the object for collision detection
        RectangleF Bounds { get; }

        // Method to handle collision with another object

        // Reaction hook invoked when a collision occurs; objects decide their own responses.
        void OnCollision(GameObject other);
    }
}
