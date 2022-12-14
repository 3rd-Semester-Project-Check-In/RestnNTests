using RestOgTests.Models;

namespace RestOgTests.Managers
{
    public interface ILokaleManager
    {
        Lokale Add(Lokale newLokale);
        Lokale? Delete(string LokaleId);
        IEnumerable<Lokale> GetAll();
        Lokale? GetById(string LokaleId);
        Lokale? Update(string LokaleId, Lokale updates);
    }
}