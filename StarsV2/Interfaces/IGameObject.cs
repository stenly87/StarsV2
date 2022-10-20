using StarsV2.Model;
using System.Numerics;

namespace StarsV2.Interfaces
{
    internal interface IGameObject
    {
        MoveDirection Direction { get; set; }
        Vector2 Position { get; set; }
        int Width { get; }
        int Height { get; }
        bool IsOnField { get; set; }
        Vector2 Speed { get; }
    }
}