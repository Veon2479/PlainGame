namespace PlainGame.Models.Entities;

public abstract class Entity
{
    public Direction Direction;
    public int X, Y;

    public Entity(Direction dir, int x, int y)
    {
        Direction = dir;
        X = x;
        Y = y;
    }

}