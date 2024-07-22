using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItems();
        Item GetItemById(int id);
        Task<MapperEntities> AddItem(MapperEntities item);
        Task<MapperEntities> UpdateItem(int id, MapperEntities item);
        Task<bool> DeleteItem(int id);
    }
}
