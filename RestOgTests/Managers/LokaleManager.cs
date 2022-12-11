using RestOgTests.Models;

namespace RestOgTests.Managers
{
    public class LokaleManager : ILokaleManager
    {
        private static readonly List<Lokale> _lokale = new List<Lokale>()
        {
            new Lokale{LokaleId = "D2.08", Occupied = true},
            new Lokale{LokaleId = "D3.11", Occupied = false},
        };

        public List<Lokale> GetAll()
        {
            return _lokale;
        }

        public Lokale? GetById(string LokaleId)
        {
            return _lokale.Find(lokale => lokale.LokaleId == LokaleId);
        }

        public Lokale Add(Lokale newLokale)
        {
            newLokale.Validate();
            _lokale.Add(newLokale);
            return newLokale;
        }

        public Lokale? Update(string LokaleId, Lokale updates)
        {
            updates.Validate();
            Lokale? oldLokale = GetById(LokaleId);
            if (oldLokale == null) return null;
            oldLokale.LokaleId = updates.LokaleId;
            oldLokale.Occupied = updates.Occupied;
            return oldLokale;
        }

        public Lokale? Delete(string LokaleId)
        {
            Lokale? toBeDeleted = GetById(LokaleId);
            if (toBeDeleted == null) return null;
            _lokale.Remove(toBeDeleted);
            return toBeDeleted;
        }
    }
}
