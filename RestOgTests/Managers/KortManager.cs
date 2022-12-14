using RestOgTests.Models;
using System.Xml.Linq;

namespace RestOgTests.Managers
{
    public class KortManager : IKortManager
    {
        private static readonly List<Kort> _korts = new List<Kort>()
        {
            new Kort{CardId = 1,  Kort_Ejer = "Lowbob Casper"},
            new Kort{CardId = 2,  Kort_Ejer = "Casper Lowbob"},
        };

        public IEnumerable<Kort> GetAll()
        {
            List<Kort> korts = new List<Kort>(_korts);
            return korts;
        }

        public Kort? GetById(int cardId)
        {
            return _korts.Find(kort => kort.CardId == cardId);
        }

        public Kort Add(Kort newKort)
        {
            newKort.Validate();
            _korts.Add(newKort);
            return newKort;
        }

        public Kort? Update(int cardId, Kort updates)
        {
            updates.Validate();
            Kort? oldKort = GetById(cardId);
            if (oldKort == null) return null;
            oldKort.CardId = updates.CardId;
            oldKort.Kort_Ejer = updates.Kort_Ejer;
            return oldKort;
        }

        public Kort? Delete(int CardId)
        {
            Kort? toBeDeleted = GetById(CardId);
            toBeDeleted.ValidateKort_Ejer();
            if (toBeDeleted == null) return null;
            _korts.Remove(toBeDeleted);
            return toBeDeleted;
        }
    }
}
