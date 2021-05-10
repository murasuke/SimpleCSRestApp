# Simple Rest API sample

参考
* https://www.ipentec.com/document/csharp-asp-net-web-api-2-create-simple-application

## 入出力サンプル

### 入力

* POST https://localhost:44331/api/Products

```json
{
    "Products": ["1","22","333"],
    "storageCd": "sto"
}
```

### 出力
```json
{
    "stocks": [
        {
            "productCd": "1",
            "stocks": 1
        },
        {
            "productCd": "22",
            "stocks": 2
        },
        {
            "productCd": "333",
            "stocks": 3
        }
    ],
    "errorCd": "00"
}
```


## ソース

* /Controller/ProductController.cs

```csharp
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
                // TODO: Retrieve from Database
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

```
