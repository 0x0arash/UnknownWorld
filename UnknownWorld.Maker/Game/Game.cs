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

        private int worldSeed;
        private int startSection;
        private int sectionCount;

        private bool started = false;

        public Game(int sectionCount=1, int startSection = 1, int worldSeed=-1)
        {
            this.worldSeed = worldSeed;
            this.startSection = startSection;
            this.sectionCount = sectionCount;
            Initialize();
        }

        public void Initialize()
        {
            world = new World(worldSeed, sectionCount, startSection);
            world.Initialize();
        }

        public void Update()
        {
            world.Update();
        }

        public void Draw()
        {
            world.Draw();
        }

        public void Start()
        {
            if (started)
                throw new Exception("Game has already started");
            else
            {
                started = true;
                //Play();
            }
        }

        public int GetWorldSeed() => world.GetSeed();
    }
}
