using Microsoft.EntityFrameworkCore;
using WareHouseApplication.Model;
using System.Collections.Generic;
using System.Linq;
using WareHouseApplication.Model.EF;

namespace WareHouseApplication.Service
{
    public class Services : IServices
    {
        private readonly WareHouseDbContext _dbcontext;
        //public static int PAGE_SIZE { get; set; } = 5;
        public Services(WareHouseDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Product> GetAll(string search, double? from, double? to, string sortBy, int page = 1, int PAGE_SIZE = 5)
        {
            var allProducts = _dbcontext.Products.AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.Name.Contains(search));
            }
            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.Cost >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.Cost <= to);
            }
            #endregion


            #region Sorting
            //Default sort by Name (TenHh)
            allProducts = allProducts.OrderBy(hh => hh.ID);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc": allProducts = allProducts.OrderByDescending(hh => hh.Name); break;
                    case "gia_asc": allProducts = allProducts.OrderBy(hh => hh.Cost); break;
                    case "gia_desc": allProducts = allProducts.OrderByDescending(hh => hh.Cost); break;
                }
            }
            #endregion

            //#region Paging
            //allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var result = allProducts.Select(hh => new HangHoaModel
            //{
            //    MaHangHoa = hh.MaHh,
            //    TenHangHoa = hh.TenHh,
            //    DonGia = hh.DonGia,
            //    TenLoai = hh.Loai.TenLoai
            //});

            //return result.ToList();

            var result = PaginatedList<Product>.Create(allProducts, page, PAGE_SIZE);

            return result.ToList();
        }
    }
}
