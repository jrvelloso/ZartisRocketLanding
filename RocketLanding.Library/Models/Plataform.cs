using System;
using System.Collections.Generic;

namespace RocketLanding.Library.Models
{
    public class Plataform
    {
        public Plataform(int landingAreaX, int landingAreaY)
        {
            CheckedPositions = new List<Tuple<int, int>>();
            PlataformArea = new Tuple<int, int>(landingAreaX, landingAreaY);
        }

        public Tuple<int, int> PlataformArea { get; set; }
        public Tuple<int, int> LastPositionChecked { get; set; }
        public List<Tuple<int, int>> CheckedPositions { get; set; }
    }
}
