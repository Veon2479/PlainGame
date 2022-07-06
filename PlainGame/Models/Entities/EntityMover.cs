using System.Collections.Generic;
using PlainGame.Models.Map;

namespace PlainGame.Models.Entities;

public class EntityMover
{

    private List<Entity> _list;
    private PlainLevel _level;
    
    public EntityMover(List<Entity> list, PlainLevel level)
    {
        _list = list;
        _level = level;
    }

    public void Move()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            int oldX = _list[i].X;
            int oldY = _list[i].Y;

            switch (_list[i].AbsDirection)
            {
                case AbsDirection.North:
                    oldX++;
                    break;
                case AbsDirection.East:
                    oldY++;
                    break;
                case AbsDirection.South:
                    oldX--;
                    break;
                case AbsDirection.West:
                    oldY--;
                    break;
            }
            if (oldX >= 0 || oldY >= 0 || oldX < _level.X || oldY < _level.Y)
                if (_level.Map[oldX, oldY].Type == BlockType.Empty)
                {
                    _list[i].X = oldX;
                    _list[i].Y = oldY;
                }
                
        }
    }
}