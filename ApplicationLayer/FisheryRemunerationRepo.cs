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
        private List<FisheryRemuneration> ListFisheryRemuneration;

        public FisheryRemunerationRepo()
        {
            ListFisheryRemuneration = new List<FisheryRemuneration>();
        }

        public void AddFisheryRemuneration(FisheryRemuneration fisheryRemuneration)
        {
            ListFisheryRemuneration.Add(fisheryRemuneration);
        }

        public List<FisheryRemuneration> GetFisheryRemuneration()
        {
            List<FisheryRemuneration> showFisheries = new List<FisheryRemuneration>();
            return showFisheries;
        }
    }
}