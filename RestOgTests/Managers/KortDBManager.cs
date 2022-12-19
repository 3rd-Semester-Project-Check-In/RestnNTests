using RestOgTests.DBContext;
using RestOgTests.Models;

namespace RestOgTests.Managers
{
    public class KortDBManager : IKortManager
    {
        private CheckInEasyContext _context;
        public KortDBManager(CheckInEasyContext context)
        {
            _context = context;
        }

        public Kort Add(Kort newKort)
        {
            newKort.Validate();
            newKort.CardId = 0;
            _context.Kort.Add(newKort);
            _context.SaveChanges();
            return newKort;
        }

        public Kort? Delete(int CardId)
        {
            Kort deleteKort = GetById(CardId);
            if (deleteKort != null)
            {
                _context.Kort.Remove(deleteKort);
                _context.SaveChanges();
            }
            return deleteKort;
        }

        public IEnumerable<Kort> GetAll()
        {
            IEnumerable<Kort> korts = from kort in _context.Kort
                                          select kort;
            return korts;
        }

        public Kort? GetById(int CardId)
        {
            return _context.Kort.FirstOrDefault(kort => kort.CardId == CardId);
        }

        public Kort? Update(int CardId, Kort updates)
        {
            updates.Validate();
            Kort KortUpdate = GetById(CardId);

            if (KortUpdate == null) return null;

            KortUpdate.Kort_Ejer = updates.Kort_Ejer;
            _context.SaveChanges();
            return KortUpdate;
        }
    }
}
