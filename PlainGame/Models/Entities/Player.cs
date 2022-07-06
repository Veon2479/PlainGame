namespace PlainGame.Models.Entities;

public class Player : Entity
{
    public Direction ViewDirection;
    public Player(Direction dir, int x, int y) : base(dir, x, y)
    {
        ViewDirection = dir;
    }

    public void RotateViewLeft()
    {
        ViewDirection = (Direction) (((int) ViewDirection + 4 - 1) % 4);
    }
    
    public void RotateViewRight()
    {
        ViewDirection = (Direction) (((int) ViewDirection + 1) % 4);
    }
}