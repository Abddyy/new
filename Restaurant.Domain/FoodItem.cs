namespace Restaurant.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        public bool IsDeleted { get; private set; } = false;

        public DateTime? DeletedTime { get; private set; } = null;

        public DateTime CreationTime { get; set; } = DateTime.Now;

        public int? DeleteAt { get; set; } =null;

        public void MarkAsDeleted()
        {
            this.IsDeleted = true;
            this.DeletedTime = DateTime.Now;
            this.DeleteAt = null;
        }

    }

    public class FoodItem : BaseEntity
    {
        public int Id {  get;  set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        

        public FoodItem(int id,string name, decimal price) 
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
