namespace PlainGame.Models.Entities;

public abstract class Entity
{
    public AbsDirection AbsDirection;
    public int X, Y;

    public Entity(AbsDirection dir, int x, int y)
    {
        AbsDirection = dir;
        X = x;
        Y = y;
    }

}