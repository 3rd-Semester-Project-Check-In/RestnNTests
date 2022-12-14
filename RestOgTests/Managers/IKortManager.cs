using RestOgTests.Models;

namespace RestOgTests.Managers
{
    public interface IKortManager
    {
        Kort Add(Kort newKort);
        Kort? Delete(int CardId);
        IEnumerable<Kort> GetAll();
        Kort? GetById(int cardId);
        Kort? Update(int cardId, Kort updates);
    }
}