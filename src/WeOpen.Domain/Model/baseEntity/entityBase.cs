namespace WeOpen.WebApi.Domain.Model.baseEntity
{
    public abstract class entityBase
    {
        public Guid Id { get; private set; }

        public entityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
