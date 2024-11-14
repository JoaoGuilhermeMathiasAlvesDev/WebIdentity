namespace WebIdentity.Entities.EntityBase
{
    public  class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }
    }
}
