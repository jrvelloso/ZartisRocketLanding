// Author notes:

// I didn't understand if by "Please, write automated tests for the library" you meant unit tests
// So besides the unit tests I'm also delivering this Program with some tests for you to run
// :)

using System;
using System.Threading.Tasks;
using RocketLanding.Library;
using RocketLanding.Library.Constants;

namespace RocketLanding.Console
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            int x = 10;
            int y = 10;

            var rocketPlataform = new RocketPlataform();
            var plataform = await rocketPlataform.CreatePlataformAsync(x, y);

            var postition = new Tuple<int, int>(5, 5);
            var check = await rocketPlataform.CheckPositionAsync(postition, plataform);

            var postition2 = new Tuple<int, int>(5, 6);
            var check2 = await rocketPlataform.CheckPositionAsync(postition2, plataform);

            var postition3 = new Tuple<int, int>(6, 5);
            var check3 = await rocketPlataform.CheckPositionAsync(postition3, plataform);

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    var postition4 = new Tuple<int, int>(i, j);
                    check = await rocketPlataform.CheckPositionAsync(postition4, plataform);
                    switch (check)
                    {
                        case ConstantsPlataformResponses.OutOfPlataform:
                            {
                                break;
                            }
                        case ConstantsPlataformResponses.OkForLanding:
                            {
                                break;
                            }
                        case ConstantsPlataformResponses.Clash:
                            {
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }
}
