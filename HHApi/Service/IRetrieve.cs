using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HHApi.Models;

namespace HHApi.Service
{
    interface IRetrieveProduct
    {
        IProduct Get();

        IEnumerable<IProduct> GetAll();

    }
}
