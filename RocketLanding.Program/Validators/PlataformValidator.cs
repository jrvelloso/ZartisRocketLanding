using System;
using System.Collections.Generic;
using System.Linq;
using RocketLanding.Library.Constants;
using RocketLanding.Library.Models;

namespace RocketLanding.Library.Validators
{
    public static class PlataformValidator
    {
        public static bool CheckIsNeighbouring(Tuple<int, int> postionToCheck, Plataform plataform)
        {
            if (plataform.CheckedPositions != null && plataform.CheckedPositions.Count > 0)
            {
                foreach (var item in plataform.CheckedPositions)
                {
                    var listNeighbouring = GetNeighbouring(item).ToList();

                    if (listNeighbouring.Any(x => x.Item1 == postionToCheck.Item1 && x.Item2 == postionToCheck.Item2))
                        return true;
                }
            }
            return false;
        }
        public static bool CheckIsOutOfPlataform(Tuple<int, int> postionToCheck, Plataform plataform)
        {
            if (plataform.PlataformArea != null)
            {
                if (postionToCheck.Item1 < ConstantValues.StartPosition ||
                    postionToCheck.Item2 < ConstantValues.StartPosition)
                    return true;

                if (postionToCheck.Item1 < ConstantValues.StartPosition ||
                    postionToCheck.Item1 > plataform.PlataformArea.Item1 + ConstantValues.StartPosition ||
                    postionToCheck.Item2 < ConstantValues.StartPosition ||
                    postionToCheck.Item2 > plataform.PlataformArea.Item2 + ConstantValues.StartPosition)
                    return true;
            }
            return false;
        }

        public static IEnumerable<Tuple<int, int>> GetNeighbouring(Tuple<int, int> position)
        {
            yield return new Tuple<int, int>(position.Item1 - 1, position.Item2 - 1);
            yield return new Tuple<int, int>(position.Item1 - 1, position.Item2);
            yield return new Tuple<int, int>(position.Item1 - 1, position.Item2 + 1);
            yield return new Tuple<int, int>(position.Item1, position.Item2 + 1);
            yield return new Tuple<int, int>(position.Item1 + 1, position.Item2 + 1);
            yield return new Tuple<int, int>(position.Item1 + 1, position.Item2);
            yield return new Tuple<int, int>(position.Item1 + 1, position.Item2 - 1);
            yield return new Tuple<int, int>(position.Item1, position.Item2 - 1);
            yield return new Tuple<int, int>(position.Item1, position.Item2);
        }
    }
}
