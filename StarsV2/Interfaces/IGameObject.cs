using StarsV2.Model;

namespace StarsV2.Interfaces
{
    internal interface IGameObject
    {
        Point Position { get; set; }
        int Width { get; }
        int Heigth { get; }
        bool IsOnField { get; }
    }
}