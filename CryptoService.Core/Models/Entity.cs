namespace CryptoService.Core.Models
{
    public abstract class Entity
    {
        public Entity(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
