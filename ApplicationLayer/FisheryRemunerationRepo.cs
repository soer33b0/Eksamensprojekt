using DomainLayer;
using System.Collections.Generic;

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