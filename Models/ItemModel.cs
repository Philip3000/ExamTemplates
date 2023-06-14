namespace RestService.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int _max = 20;
        public int _min = 3;
        public int _minChar = 2;
        public void ValidateId () 
        {
            if (Id <= 0)
            {
                throw new ArgumentException("Id cannot be less than or equal to 0");
            }
            
        }
        public void ValidateName()
        {
            if (Name?.Length >= _max || Name?.Length <= _min) 
            {
                throw new ArgumentOutOfRangeException($"{Name} cannot be longer than {_max} or less than {_min}");
            }
            else if (Name == null)
            {
                throw new NullReferenceException("Name cannot be null");
            }
        }
        public void ValidatePrice()
        {
            if (Price <= 0)
            {
                throw new ArgumentException("Price can't be less than 0");
            }
        }
        public void ValidateDescription()
        {
            if (Description?.Length < _minChar)
            {
                throw new ArgumentOutOfRangeException($"{Description} must be longer than {_minChar} characters");
            }
            else if (Description == null)
            {
                throw new NullReferenceException($"{Description} cannot be null");
            }
        }
        public void Validate()
        {
            ValidateId();
            ValidateName();
            ValidatePrice();
            ValidateDescription();
        }
    }
}
