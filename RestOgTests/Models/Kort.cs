using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RestOgTests.Models
{
    public class Kort
    {
        [Key]
        
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

        public void ValidateKort_Ejer()
        {
            if (Kort_Ejer == null)
            {
                throw new IllegalKortException("Card owner must not be null!");
            }
            else if (Kort_Ejer.Length < 2)
            {
                throw new IllegalKortException($"Card owner length is required to be higher than 1: '{Kort_Ejer.Length}', '{Kort_Ejer}'");
            }
            else if (Kort_Ejer.Length >= 255)
            {
                throw new IllegalKortException($"LokaleId's length is required to be lower than 256: '{Kort_Ejer.Length}', '{Kort_Ejer}'");
            }
        }

        public void ValidateCardId()
        {
            if(CardId == null)
            {
                throw new IllegalKortException("Card Id must not be null!");
            }
        }

        public void Validate()
        {
            ValidateCardId();
            ValidateKort_Ejer();
        }
    }
    public class IllegalKortException : Exception
    {
        public IllegalKortException(string message)
            : base(message)
        {
        }
    }
}
