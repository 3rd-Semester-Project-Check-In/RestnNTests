using RestOgTests.Models;
using Microsoft.EntityFrameworkCore;
using RestOgTests.DBContext;

namespace RestOgTests.Managers
{
    public class DBManager : ILokaleManager
    {

        private CheckInEasyContext _context;
        public DBManager(CheckInEasyContext context)
        {
                _context = context;
        }

        public Lokale Add(Lokale newLokale)
        {
            newLokale.LokaleId = "";
            _context.Lokaler.Add(newLokale);
            _context.SaveChanges();
            return newLokale;  
        }

        public Lokale? Delete(string LokaleId)
        {
            Lokale deleteLokale = GetById(LokaleId);
            if (deleteLokale != null)
            {
                _context.Lokaler.Remove(deleteLokale);
                _context.SaveChanges();
            }
            return deleteLokale;
        }

        public List<Lokale> GetAll()
        {
            throw new NotImplementedException();
        }

        public Lokale? GetById(string LokaleId)
        {
            return _context.Lokaler.FirstOrDefault(lokale => lokale.LokaleId == LokaleId);
        }

        public Lokale? Update(string LokaleId, Lokale updates)
        {
            Lokale LokaleUpdate = GetById(LokaleId);
            LokaleUpdate.LokaleId = updates.LokaleId;
            _context.SaveChanges();
            return LokaleUpdate;
        }
    }
}
