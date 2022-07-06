namespace PlainGame.Models.Entities;

public class Player : Entity
{
    public AbsDirection MoveDirection;
    public AbsDirection ViewDirection;
    public Player(AbsDirection dir, int x, int y) : base(dir, x, y)
    {
        AbsDirection = dir;
    }

    public void RotateViewLeft()
    {
        ViewDirection = (AbsDirection) (((int) ViewDirection + 4 - 1) % 4);
    }
    
    public void RotateViewRight()
    {
        ViewDirection = (AbsDirection) (((int) ViewDirection + 1) % 4);
    }
    
    public void RotateMoveLeft()
    {
        MoveDirection = (AbsDirection) (((int) MoveDirection + 4 - 1) % 4);
    }
    
    public void RotateMoveRight()
    {
        MoveDirection = (AbsDirection) (((int) MoveDirection + 1) % 4);
    }

    public void ReflectMove()
    {
        MoveDirection = (AbsDirection) (((int) MoveDirection + 2) % 4);

    }
}