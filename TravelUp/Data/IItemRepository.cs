using TravelUp.Models;

namespace TravelUp.Data
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(int id);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }

    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> _items = new List<Item>();

        public IEnumerable<Item> GetAllItems()
        {
            return _items;
        }

        public Item GetItemById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public void AddItem(Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
            }
        }

        public void DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
    }
}