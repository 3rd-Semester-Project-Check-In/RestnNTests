namespace RestOgTests.Models
{
    public class Kort
    {
        public int CardId { get; set; }
        public string Kort_Ejer { get; set; }

        public Kort()
        {

        }

        public Kort(int cardId, string kort_Ejer)
        {
            CardId = cardId;
            Kort_Ejer = kort_Ejer;
        }
    }
}
