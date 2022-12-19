using RestOgTests.Models;
using Microsoft.EntityFrameworkCore;
using RestOgTests.DBContext;

namespace RestOgTests.Managers
{
    public class LokaleDBManager : ILokaleManager
    {

        private CheckInEasyContext _context;
        public LokaleDBManager(CheckInEasyContext context)
        {
                _context = context;
        }

       

        public Lokale Add(Lokale newLokale)
        {
            newLokale.Validate();
            _context.Lokale.Add(newLokale);
            _context.SaveChanges();
            return newLokale;  
        }

        public Lokale? Delete(string LokaleId)
        {
            Lokale deleteLokale = GetById(LokaleId);
            if (deleteLokale != null)
            {
                _context.Lokale.Remove(deleteLokale);
                _context.SaveChanges();
            }
            return deleteLokale;
        }

        public IEnumerable<Lokale> GetAll()
        {
            IEnumerable<Lokale> lokales = from lok in _context.Lokale
                                          select lok;
            return lokales;
        }

        public Lokale? GetById(string LokaleId)
        {
            return _context.Lokale.FirstOrDefault(lokale => lokale.LokaleId == LokaleId);
        }

        public Lokale? Update(string LokaleId, Lokale updates)
        {
            updates.Validate();
            Lokale LokaleUpdate = GetById(LokaleId);

            if (LokaleUpdate == null) return null;

            if (updates.CardId == 0) updates.CardId = null;
            else
            {

                IEnumerable<Kort> korts = from kor in _context.Kort
                                          select kor;
                Kort kort2 = korts.FirstOrDefault(kort2 => kort2.CardId == updates.CardId);

                if (kort2 == null) return null;
            }

            LokaleUpdate.CardId = updates.CardId;
            _context.SaveChanges();
            return LokaleUpdate;
        }
    }
}
