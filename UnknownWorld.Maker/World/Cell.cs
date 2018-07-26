using UnknownWorld.Core.Interfaces;

namespace UnknownWorld.Maker.World
{
    public class Cell : IInitialize, IDraw
    {
        public static int CELLTYPE_EMPTY = 0;
        public static int CELLTYPE_DIRT = 1;
        public static int CELLTYPE_GRASS = 2;
        public static int CELLTYPE_BOX = 3;
        public static int CELLTYPE_MONSTER = 4;
        public static int CELLTYPE_SHOP = 5;
        public static int CELLTYPE_HOUSE = 6;
        public static int CELLTYPE_ROAD_H = 7;
        public static int CELLTYPE_ROAD_H_U = 8;
        public static int CELLTYPE_ROAD_H_D = 9;
        public static int CELLTYPE_ROAD_V = 10;
        public static int CELLTYPE_ROAD_V_R = 11;
        public static int CELLTYPE_ROAD_V_L = 12;
        public static int CELLTYPE_CROSSROAD = 13;

        public static char[] CellSymbol = new char[]
        {
            ' ',
            '░',
            '▒',
            '■',
            'δ',
            '₧',
            '¥',
            '═',
            '╩',
            '╦',
            '║',
            '╠',
            '╣',
            '╬'
        };
        
        private Section section;

        private int cellType;
        public int CellType
        {
            get { return cellType; }
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        private int x;
        private int y;

        public Cell(Section s, int ct)
        {
            section = s;
            cellType = ct;
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Draw()
        {
            section.DrawCell(CellSymbol[CellType], x, y);
        }
    }
}