using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnknownWorld.Core.Interfaces;
using UnknownWorld.Maker.World;

namespace UnknownWorld.Core.Game
{
    public class Game : IUpdate, IInitialize, IDraw
    {
        private World world;

        public Game()
        {

        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
