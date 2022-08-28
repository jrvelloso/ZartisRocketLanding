using System;
using System.Threading.Tasks;
using RocketLanding.Library.Models;

namespace RocketLanding.Library
{
    public interface IRocketPlataform
    {
        Task AddCheckedPositions(Tuple<int, int> postionToCheck, Plataform plataform);
        Task<string> CheckPositionAsync(Tuple<int, int> postionToCheck, Plataform plataform);
        Task<Plataform> CreatePlataformAsync(int sizeX, int sizeY);
    }
}