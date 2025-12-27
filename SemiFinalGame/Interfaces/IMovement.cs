using SemiFinalGame.Core;
using SemiFinalGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiFinalGame.Interfaces
{
    internal class IMovement
    {
        void Move(GameObject obj, GameTime gameTime);
    }
}
