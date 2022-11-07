using System.Collections.Generic;
using WareHouseApplication.Model;

namespace WareHouseApplication.Service
{
    public interface IService
    {
        List<Product> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
    }
}
