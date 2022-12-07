namespace RestOgTests.Models
{
    public class Lokale
    {
        public string LokaleId { get; set; }

        public bool Occupied { get; set; }

        public Lokale(string lokaleId, bool occupied)
        {
            LokaleId = lokaleId;
            Occupied = occupied;
        }

        public Lokale()
        {

        }

        public void ValidateLokaleId()
        {
            if(LokaleId == null)
            {
                throw new IllegalLokaleIdException("Lokale Id can't be null!");
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
            return $"{{{nameof(LokaleId)}={LokaleId}, {nameof(Occupied)}={Occupied.ToString()}}}";
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
