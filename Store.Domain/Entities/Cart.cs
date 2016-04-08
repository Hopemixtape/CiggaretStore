using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Store.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Ware ware, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Ware.WareId == ware.WareId )
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Ware = ware,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Ware ware)
        {
            lineCollection.RemoveAll(l => l.Ware.WareId == ware.WareId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Ware.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Ware Ware { get; set; }
        public int Quantity { get; set; }
    }
}