using Microsoft.EntityFrameworkCore;
using RestOgTests.Models;

namespace RestOgTests.Managers
{
    public class LokaleManager : ILokaleManager
    {
        private static readonly List<Lokale> _lokale = new List<Lokale>()
        {
            new Lokale{LokaleId = "D2.08"},
            new Lokale{LokaleId = "D3.11"},
        };

        public IEnumerable<Lokale> GetAll()
        {
            List<Lokale> lokales= new List<Lokale>(_lokale);
            return lokales;
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
            return oldLokale;
        }

        public Lokale? Delete(string LokaleId)
        {
            Lokale? toBeDeleted = GetById(LokaleId);
            toBeDeleted.Validate();
            if (toBeDeleted == null) return null;
            _lokale.Remove(toBeDeleted);
            return toBeDeleted;
        }
    }
}
