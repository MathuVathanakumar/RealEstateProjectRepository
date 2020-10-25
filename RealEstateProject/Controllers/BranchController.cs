using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateProject.Models;

namespace RealEstateProject.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        private RealEstateContext realEstateContext = new RealEstateContext();
        public ActionResult Index()
        {
            List<Branch> AllBranches = realEstateContext.branches.ToList();
            return View(AllBranches);
        }

        public ActionResult Create()//Load
        { //Dropdown list 
            ViewBag.BranchDetails = realEstateContext.branches;
            return View();

        }
        [HttpPost]
        public ActionResult Create(Branch branch)//Insert
        {
            ViewBag.BranchDetails = realEstateContext.branches;
            realEstateContext.branches.Add(branch);
            realEstateContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(String id)
        {
            Branch branch = realEstateContext.branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        public ActionResult Edit(String id)
        {
            Branch branch = realEstateContext.branches.SingleOrDefault(x => x.BranchNo == id);
            ViewBag.BranchDetails = new SelectList(realEstateContext.branches);
            return View(branch);
        }
        [HttpPost]
        public ActionResult Edit(String id, Branch updatedBranch)
        {
            Branch branch = realEstateContext.branches.SingleOrDefault(x => x.BranchNo == id);
            branch.Street = updatedBranch.Street;
            branch.City = updatedBranch.City;
            branch.Postcode = updatedBranch.Postcode;
            realEstateContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Branch branch = realEstateContext.branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteBranch(String id)
        {
            Branch branch = realEstateContext.branches.SingleOrDefault(x => x.BranchNo == id);
            realEstateContext.branches.Remove(branch);
            realEstateContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BranchCount()
        {
            List<Branch> branch = realEstateContext.branches.ToList();
            return View(branch);
        }
    }
}