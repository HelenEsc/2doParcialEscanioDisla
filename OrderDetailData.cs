using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcialEscanioDisla
{
    public class OrderDetailData : GenericRepository<Order_Details>
    {
        //Aquí se heredan los métodos del CRUD.
        public int TotalProductos { get; set; }
        public decimal TotalFactura { get; set; }
        public decimal Importe { get; set; }
    }
}
