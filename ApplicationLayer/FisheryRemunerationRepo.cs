using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace ApplicationLayer
{
    public class FisheryRemunerationRepo
    {
        private List<FisheryRemuneration> fisheryRemunerations = new List<FisheryRemuneration>();

        public void AddFisheryRemuneration(FisheryRemuneration fisheryRemuneration)
        {
            fisheryRemunerations.Add(fisheryRemuneration);
        }
    }
}