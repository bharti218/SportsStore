using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        // this interface uses IEnumerable<T> to allow a caller to obtain a sequence of product objects without saying how 
        // or where the data is stored or retrieved.
        IEnumerable<Product> Products { get;}
    }
}
