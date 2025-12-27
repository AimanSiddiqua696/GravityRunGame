using SemiFinalGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiFinalGame.Interfaces
{
    public interface IUpdatable
    {
        // Method to update the object
        void Update(GameTime gameTime);
    }
}
