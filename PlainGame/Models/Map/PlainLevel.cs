using System;
using System.Collections.Generic;

namespace PlainGame.Models.Map;

public class PlainLevel
{
    
    private Block[,] _map;

    public Block[,] Map => _map;

    public readonly int X, Y;
    public PlainLevel(int x, int y)
    {
        X = x;
        Y = y;
        _map = new Block[x, y];
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++)
            {
                if (i == 0 || j == 0 || i == x-1 || j == y-1)
                {
                    _map[i, j] = new Block(BlockType.Solid);
                }
                else
                {
                    _map[i, j] = new Block(BlockType.Empty);
                }
            }
    }
    
    

}