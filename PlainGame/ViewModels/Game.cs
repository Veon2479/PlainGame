using System;
using System.Collections.Generic;
using Avalonia.Controls;
using PlainGame.Models.Entities;
using PlainGame.Models.Map;
using PlainGame.ViewModels.Types;
using PlainGame.Views;

namespace PlainGame.ViewModels;

public class Game
{
    //line for a view object
    private Player _player;
    private PlainLevel _level;

    private EntityMover _playerMover;
    private bool _isAlive;
    public bool IsAlive => _isAlive;

    private static Game? _instance = null;
    private static readonly object locker = new object();
    public static Game GetGameInstance()
    {
        if (_instance == null)
        {
            lock (locker)
            {
                if (_instance == null)
                    _instance = new Game();
            }
        }
        return _instance;
    }
    private Game()
    {
        _player = new Player(AbsDirection.North, 1, 1);
        _level = new PlainLevel(9, 9);
        _playerMover = new EntityMover(new List<Entity> { _player }, _level);
    }

    public void Run()
    {
        Console.WriteLine("Started!");
        _isAlive = true;
        while (_isAlive)
        {
            //simply draw all?
        }
    }
    
    public void Exit()
    {
        _isAlive = !_isAlive;
        Console.WriteLine("Exited!");
    }

    public void Move(RelDirection dir)
    {
        switch (dir)
        {
            case RelDirection.Forward:
                break;
            case RelDirection.Left:
                _player.RotateMoveLeft();
                break;
            case RelDirection.Right:
                _player.RotateMoveRight();
                break;
            case RelDirection.Back:
                _player.ReflectMove();
                break;
        }
        _playerMover.Move();
        switch (dir)
        {
            case RelDirection.Forward:
                break;
            case RelDirection.Left:
                _player.RotateMoveRight();
                break;
            case RelDirection.Right:
                _player.RotateMoveLeft();
                break;
            case RelDirection.Back:
                _player.ReflectMove();
                break;
        }
    }

    public void Rotate(RelDirection dir)
    {
        if (dir == RelDirection.Left)
            _player.RotateViewLeft();
        else
            _player.RotateViewRight();
    }


    private Block?[,] GetVisibleArea()
    {
        var result = new Block?[3, 3];
        int dx = 0, dy = 0;
        switch (_player.ViewDirection)
        {
            case AbsDirection.North:
                dx = 1;
                break;
            case AbsDirection.East:
                dy = 1;
                break;
            case AbsDirection.South:
                dx -= 1;
                break;
            case AbsDirection.West:
                dy -= 1;
                break;
        }
        
        int Xc = _player.X;
        int Yc = _player.Y;
        
        
        for (int i = 0; i < 3; i++)
        {
            Xc += dx;
            Yc += dy;
           
            result[i, 1] = _level.Map?[Xc, Yc];
            result[i, 0] = _level.Map?[Xc + dy, Yc - dx];
            result[i, 3] = _level.Map?[Xc - dy, Yc + dx];
            
        }

        
        return result;
    }

    
}