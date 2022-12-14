using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestOgTests.Models
{
    public class Lokale
    {
        [Key]
        public string LokaleId { get; set; }

        [ForeignKey("CardId")]
        public int? CardId { get; set; }

        public Lokale(string lokaleId)
        {
            LokaleId = lokaleId;
           
        }

        public Lokale()
        {

        }

        public void ValidateLokaleId()
        {
            if(LokaleId == null)
            {
                throw new IllegalLokaleIdException("Lokale Id must not be null!");
            }
            else if (LokaleId.Length < 2)
            {
                throw new IllegalLokaleIdException($"LokaleId's length is required to be higher than 1: '{LokaleId.Length}', '{LokaleId}'");
            }
            else if (LokaleId.Length >= 255)
            {
                throw new IllegalLokaleIdException($"LokaleId's length is required to be lower than 256: '{LokaleId.Length}', '{LokaleId}'");
            }
        }


        public void Validate()
        {
            ValidateLokaleId();
        }

        public override string ToString()
        {
            return $"{{{nameof(LokaleId)}={LokaleId}}}";
        }
    }
    public class IllegalLokaleIdException : Exception
    {
        public IllegalLokaleIdException(string message)
            : base(message)
        {
        }
    }
}
