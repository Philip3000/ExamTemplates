using ModelClassLib;
using RestService.Models;

namespace RestService.Repositories
{
    public class ItemRepository
    {
        private readonly List<Item> Data;
        private int _nextId = 1;
        public ItemRepository() 
        {
            Data = new List<Item>()
            {
                new Item{Id = _nextId++, Name = "Chocolate", Price = 28, Description = "Tasty Chocolate"},
                new Item{Id = _nextId++, Name = "Mirror", Price = 320, Description = "Cool Mirror"},
                new Item{Id = _nextId ++, Name = "Duvet", Price = 460, Description = "Soft Duvet"},
                new Item{Id = _nextId ++, Name = "Sofa", Price = 3100, Description = "Comfortable sofa"},
                new Item{Id = _nextId ++, Name = "Candlelight", Price = 5, Description = "Romantic candleligt"},
                new Item{Id = _nextId ++, Name = "SuperStar", Price = 33, Description = "Superstar maker"},  
            };
        }
        public List<Item> GetAll()
        {
            List<Item> items = Data;
            return items;
        }
        public Item? GetById(int id)
        {
            return Data.Find(item => item.Id == id);
        }
        public Item Add(Item item)
        {
            item.Validate();
            item.Id = _nextId++;
            Data.Add(item);
            return item;
        }
        public Item Update(Item update)
        {
            Item item = GetById(update.Id);
            if (item == null) return null;
            item.Id = update.Id;
            item.Name = update.Name;
            item.Price = update.Price;
            item.Description = update.Description;
            return item;
        }
        public Item Delete(int deleteId)
        {
            Item item = GetById(deleteId);
            if (item == null) return null;
            Data.Remove(item);
            return item;
        }
    }
}
