namespace PlainGame.Models.Map;

public class Block
{
    private BlockType _type;
    public BlockType Type => _type;

    public Block(BlockType type)
    {
        _type = type;
    }
}