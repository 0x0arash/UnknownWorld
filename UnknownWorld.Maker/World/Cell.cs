using UnknownWorld.Core.Interfaces;

namespace UnknownWorld.Maker.World
{
    public class Cell : IInitialize
    {
        public static int CELLTYPE_EMPTY = 0;
        public static int CELLTYPE_DIRT = 1;
        public static int CELLTYPE_GRASS = 2;
        public static int CELLTYPE_BOX = 3;
        public static int CELLTYPE_MONSTER = 4;
        public static int CELLTYPE_SHOP = 5;
        public static int CELLTYPE_HOUSE = 6;

        private Section section;

        private int cellType;
        public int CellType
        {
            get { return cellType; }
        }

        public Cell(Section s, int ct)
        {
            section = s;
            cellType = ct;
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}