using System.Collections.Generic;
using PlainGame.Models.Entities;
using PlainGame.Models.Map;

namespace PlainGame.ViewModels;

public class Game
{
    //line for a view object
    private Player _player;
    private PlainLevel _level;

    private EntityMover _playerMover;
    private bool _isAlive;

    public Game()
    {
        _player = new Player(Direction.North, 1, 1);
        _level = new PlainLevel(9, 9);
        _playerMover = new EntityMover(new List<Entity> { _player }, _level);
    }

    public void Run()
    {
        _isAlive = true;
        while (_isAlive)
        {
            //simply draw all?
        }
    }

}