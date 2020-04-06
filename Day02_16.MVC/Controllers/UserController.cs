using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace Day02_16.MVC.Controllers
{
    public class UserController : Controller
    {
        HttpClientHelper hc = new HttpClientHelper("http://localhost:59001/api/");
        public ActionResult Show()
        {
            BandSel();
            var list = JsonConvert.DeserializeObject<List<UserInfo>>(hc.Get("User"));
            return View(list);
        }
        [HttpPost]
        public ActionResult Show(string name, string did)
        {
            BandSel();
            var list = JsonConvert.DeserializeObject<List<UserInfo>>(hc.Get("User"));
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(s => s.Uname.Contains(name)).ToList();
            }
            if (!string.IsNullOrEmpty(did))
            {
                list = list.Where(s => s.DetpId == int.Parse(did)).ToList();
            }
            return View(list);
        }

        public void BandSel()
        {
            var list = JsonConvert.DeserializeObject<List<DetpInfo>>(hc.Get("Detp"));
            ViewBag.bandsel = new SelectList(list, "Did", "Dname");
        }

        public ActionResult Add()
        {
            BandSel();
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserInfo u)
        {
            if (hc.Post("User", JsonConvert.SerializeObject(u)) == "1")
            {
                return Content("<script>alert('添加成功');location.href='/User/Show';</script>");
            }
            else
            {
                return Content("<script>alert('添加失败')</script>");
            }
        }

        public ActionResult Del(string id)
        {
            if (hc.Delete("User/" + id) == "1")
            {
                return Content("<script>alert('删除成功');location.href='/User/Show';</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');location.href='/User/Show';</script>");

            }

        }

        public ActionResult Upt(int id)
        {
            BandSel();
            var list = JsonConvert.DeserializeObject<UserInfo>(hc.Get("User/" + id));
            return View(list);
        }
        [HttpPost]
        public ActionResult Upt(UserInfo u)
        {
            if (hc.Put("User", JsonConvert.SerializeObject(u)) == "1")
            {
                return Content("<script>alert('修改成功');location.href='/User/Show';</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
            return View(u);
        }
    }
}