using Newtonsoft.Json;
using Web2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web2.Models;

namespace Web2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            channelEntities ch = new channelEntities();
            classchannel cs = new classchannel();
            cs.users = (
                    from full in ch.users.AsEnumerable()
                    select new
                    {
                        id1 = full.id,
                        username1 = full.username,
                        password1 = full.password
                    }).ToList();

            return View(cs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult ActionCreate(string ffName)
        {
            try
            {

                dynamic item = JsonConvert.DeserializeObject(ffName);
                channelEntities tfn = new channelEntities();
                user p1 = new user();
                p1.username = item.user;
                p1.password = item.pass;
                p1.room = item.roo;
                tfn.users.Add(p1);
                tfn.SaveChanges();

                //pro1Entities1 tfn = new pro1Entities1();

                //fullname p1 = new fullname();
                //p1.firstName = item.fName;
                //p1.lastName = item.lName;
                //tfn.fullnames.Add(p1);
                //tfn.SaveChanges();

                return Json(new { status = "200", message = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "500", message = ex.Message });
            }
        }
        public JsonResult Check(string auser, string apass)
        {

            channelEntities ch = new channelEntities();
            classchannel cs = new classchannel();



            try
            {
                cs.users = (from iduse in ch.users.AsEnumerable()
                            where iduse.username == auser && iduse.password == apass
                            select new
                            {

                                auser1 = iduse.room.ToString()

                            }).First();
                if (cs.users != null)
                {
                    return Json(new { status = "200", message = "suc" });


                }
                else
                {
                    return Json(new { status = "500", message = "faill" });
                }

            }
            catch (Exception e)
            {
                return Json(new { status = "500", message = e.Message, data = "error" });
            }
        }
        public JsonResult Test(string roomat)
        {
            channelEntities ch = new channelEntities();
            classchannel cs = new classchannel();

            try
            {
                cs.users = (from iduse in ch.users.AsEnumerable()
                            where iduse.room == roomat
                            select new
                            {

                               rooma = iduse.username


                            }).First();
                if (cs.users != null)
                {
                    return Json(new { status = "200", message = "suc" ,data =cs.users });
                }
                else
                {
                    return Json(new { status = "500", message = "ไม่มีนะครับ" });
                }
               
            }
            catch (Exception e)
            {
                return Json(new { status = "500", message = e.Message, data = "ไม่มีนะจ้ะ" });
            }
         
        }
    }
}