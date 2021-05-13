namespace MyAwardProgram.Shared.Entities
{
    public abstract class Entity<T> where T : Entity<T>
    {
        public int Id { get; set; }
    }
}
