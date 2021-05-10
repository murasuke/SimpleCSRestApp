using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleRestApp.Controllers
{
    public class InputValue
    {
        public string[] Products;
        public string storageCd;
    }

    public class OutputValue
    {
        public productStocks[] stocks;
        public string errorCd;
    }

    public class productStocks
    {
        public string productCd;
        public int stocks;
    }


    public class ProductsController : ApiController
    {
        public OutputValue Post(InputValue input)
        {
            var output = new OutputValue();
            var stocks = new List<productStocks>();
            int stockQuantity = 1;
            foreach( var product in input.Products)
            {
                var stock1 = new productStocks();
                stock1.productCd = product;
                stock1.stocks = stockQuantity;
                stocks.Add(stock1);
                stockQuantity++;
            }
            
            output.stocks = stocks.ToArray();
            output.errorCd = "00";
            return output;
        }
    }
}
