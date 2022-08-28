using System;
using System.Threading.Tasks;
using RocketLanding.Library.Constants;
using RocketLanding.Library.Models;
using RocketLanding.Library.Validators;

namespace RocketLanding.Library
{
    public class RocketPlataform : IRocketPlataform
    {
        public async Task<string> CheckPositionAsync(Tuple<int, int> postionToCheck, Plataform plataform)
        {
            if (plataform.LastPositionChecked != null && plataform.LastPositionChecked.Equals(postionToCheck))
                return ConstantsPlataformResponses.Clash;

            if (PlataformValidator.CheckIsOutOfPlataform(postionToCheck, plataform))
                return ConstantsPlataformResponses.OutOfPlataform;

            if (PlataformValidator.CheckIsNeighbouring(postionToCheck, plataform))
                return ConstantsPlataformResponses.Clash;

            await AddCheckedPositions(postionToCheck, plataform);

            return ConstantsPlataformResponses.OkForLanding;
        }

        public async Task AddCheckedPositions(Tuple<int, int> postionToCheck, Plataform plataform)
        {
            plataform.LastPositionChecked = postionToCheck;
            plataform.CheckedPositions.Add(postionToCheck);
        }

        public async Task<Plataform> CreatePlataformAsync(int sizeX, int sizeY)
        {
            if (sizeX != sizeY)
                throw new Exception("Plataform must have a squared area");

            var maxSize = 100 - ConstantValues.StartPosition;

            if (sizeX > maxSize || sizeY > maxSize)
                throw new Exception($"Plataform must be smaller than {100 - ConstantValues.StartPosition}");

            var plataform = new Plataform(sizeX, sizeY);

            return plataform;
        }
    }
}