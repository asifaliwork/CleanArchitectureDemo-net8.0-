using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;
        public ItemRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await dbContext.items.ToListAsync(); 
        }
        public  Item GetItemById(int id)
        {
            return  this.dbContext.items.FirstOrDefault(x => x.Id == id);

        }
        public async Task<MapperEntities> AddItem(MapperEntities item )
        {
            
            var hee = this.mapper.Map<Item>(item);
            
            dbContext.items.Add(hee);
             dbContext.SaveChanges();

            return item;
        }
        public async Task<MapperEntities> UpdateItem( int id, MapperEntities item)
        {
           // var New =  dbContext.items.FirstOrDefault( x=> x.Id == id );
            Item ite = dbContext.items.FirstOrDefault( x => x.Id == id);
            if (ite is not null)
            {
               mapper.Map(item , ite);
                //New.Id = item.Id;
                //New.Name = item.Name;
                //New.Description = item.Description;
                //New.Type = item.Type;
               // dbContext.items.Update(updatedata);
                dbContext.SaveChanges();

            }

            return item;
        }
        public async Task<bool> DeleteItem(int id)
        {
            var Id = dbContext.items.Where( x => x.Id == id ).FirstOrDefault();
            if(Id != null)
            {
                dbContext.items.Remove(Id);
                return  dbContext.SaveChanges()>0;
            }
            return false;
        }
    }
}
