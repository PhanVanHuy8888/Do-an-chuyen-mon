using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.EF;

namespace WebBanHang.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
            var pageSize = 4;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Posts> items = db.Posts.OrderByDescending(x => x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Detail(int id)
        {
            var item = db.Posts.Find(id);
            return View(item);
        }
        public ActionResult Partial_Post()
        {
            var items = db.Posts.Take(3).ToList();
            return PartialView(items);
        }
    }
}