using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebBanHang.Models;
using WebBanHang.Models.EF;

namespace WebBanHang.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index(string SearchText, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }

            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.Id);

            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.Alias.Contains(SearchText) || x.Title.Contains(SearchText));
            }

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);

            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return View(items);
        }


        public ActionResult ProductLike()
        {
            var items = db.Products.ToList();
            return View(items);
        }

        public ActionResult Detail(/*string alias,*/ int id)
        {
            var item = db.Products.Find(id);
            return View(item);
        }
        public ActionResult ProductCategory(string alias, int id, string SearchText, int? page)
        {
            var pageSize = 2;
            if (page == null)
            {
                page = 1;
            }

            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.Id);

            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.Alias.Contains(SearchText) || x.Title.Contains(SearchText));
            }

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var pagedItems = items.ToPagedList(pageIndex, pageSize);

            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            if (id > 0)
            {
                pagedItems = pagedItems.Where(x => x.ProductCategoryId == id).ToPagedList(pageIndex, pageSize);
            }

            var cate = db.ProductCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }

            ViewBag.CateId = id;
            return View(pagedItems);
        }


        public ActionResult Partial_ItemsByCateId()
        {
            var items = db.Products.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
    }
}