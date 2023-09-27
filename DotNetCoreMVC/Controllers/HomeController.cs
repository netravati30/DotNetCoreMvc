using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreMVC.Models;
using System.Data;

namespace DotNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        db dbop = new db();
        string msg;

        //private List<Item> Items;
        //public HomeController()
        //{
        //    Items = new List<Item>()
        //    {
        //        new Item()
        //        {
        //            ItemId =1,ItemName="Rice",Quantity="2kg", Date=Convert.ToDateTime("14-09-2023"), Status="Active"
        //        },
        //           new Item()
        //        {
        //            ItemId =2,ItemName="Onion",Quantity="5kg", Date=Convert.ToDateTime("14-09-2023"), Status="Active"
        //        },
        //            new Item()
        //        {
        //            ItemId =3,ItemName="Mirchi",Quantity="3kg", Date=Convert.ToDateTime("14-09-2023"), Status="Active"
        //        },
        //             new Item()
        //        {
        //            ItemId =4,ItemName="Oil",Quantity="5kg", Date=Convert.ToDateTime("14-09-2023"), Status="Active"
        //        }
        //    };
        //}
        public IActionResult Index()
        {
            Branch branch = new Branch();
            DataSet ds = dbop.GetBranchDetails(branch, out msg);
            List<Branch> list = new List<Branch>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Branch
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    BranchId = dr["BranchId"].ToString(),
                    BranchName=dr["BranchName"].ToString(),
                    Cluster = dr["Cluster"].ToString(),
                    State = dr["State"].ToString(),
                    Status = dr["Status"].ToString(),
                    CollectionBranch = dr["CollectionBranch"].ToString(),
                    Tier = Convert.ToInt32(dr["Tier"]),
                    Region = dr["Region"].ToString(),
                    Zone = dr["Zone"].ToString(),
                });
            }
            return View(list);
           // return View(Items);
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpPost]
        public IActionResult About([Bind] Branch branch)
        {
            try
            {
                dbop.BranchInsert(branch, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception ex)
            {
                throw (ex);
                //empData["msg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
       // [Route("HomeController/Contact/{BranchId}")]
        public IActionResult Contact(string Id)
        {
            Branch branch = new Branch();
            branch.BranchId = Id;
            DataSet ds = dbop.GetBranchDetails1(branch, out msg);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                branch.BranchId = dr["BranchId"].ToString();
                branch.BranchName = dr["BranchName"].ToString();
                branch.Cluster = dr["Cluster"].ToString();
                branch.State = dr["State"].ToString();
                branch.Status = dr["Status"].ToString();
                branch.CollectionBranch = dr["CollectionBranch"].ToString();
                branch.Tier = Convert.ToInt32(dr["Tier"]);
                branch.Region = dr["Region"].ToString();
                branch.Zone = dr["Zone"].ToString();

            }
                //ViewData["Message"] = "Your contact page.";

                return View(branch);
        }
        [HttpPost]
        public IActionResult Contact(string BranchId, [Bind] Branch branch)
        {
            try
            {
                branch.BranchId = BranchId;
               // emp.flag = "update";
                dbop.BranchUpdate(branch, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy(string Id)
        {
            try
            {
                Branch branch = new Branch();
                branch.BranchId = Id;
                dbop.DeleteBranchDetails(branch, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
