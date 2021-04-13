using System.Collections.Generic;

namespace Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        // Se hace la relacion con la tabla OrderDetails de muchos a muchos

        public List<OrderDetail> Items { get; set; }
    }
}
