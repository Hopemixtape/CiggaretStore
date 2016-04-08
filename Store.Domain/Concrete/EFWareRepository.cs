using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Abstract;
using Store.Domain.Entities;

namespace Store.Domain.Concrete
{
    public class EFWareRepository : IWareRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Ware> Wares
        {
            get { return context.Wares; }
        }
        public void SaveWare(Ware ware)
        {
            if (ware.WareId == 0)
                context.Wares.Add(ware);
            else
            {
                Ware dbEntry = context.Wares.Find(ware.WareId);
                if (dbEntry != null)
                {
                    dbEntry.Name = ware.Name;
                    dbEntry.Description = ware.Description;
                    dbEntry.Price = ware.Price;
                    dbEntry.Category = ware.Category;
                    dbEntry.ImageData = ware.ImageData;
                    dbEntry.ImageMimeType = ware.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Ware DeleteWare(int wareId)
        {
            Ware dbEntry = context.Wares.Find(wareId);
            if (dbEntry != null)
            {
                context.Wares.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


    }

}
