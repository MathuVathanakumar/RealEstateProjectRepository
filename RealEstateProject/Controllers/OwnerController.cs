using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateProject.Models;

namespace RealEstateProject.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        private RealEstateContext realEstateContext = new RealEstateContext();
        public ActionResult Index()
        {
            List<Owner> AllOwners = realEstateContext.owners.ToList();
            return View(AllOwners);
        }

        public ActionResult Create()//Load
        { //Dropdown list 
            ViewBag.OwnerDetails = realEstateContext.owners;
            return View();

        }
        [HttpPost]
        public ActionResult Create(Owner owner)//Insert
        {
            ViewBag.OwnerDetails = realEstateContext.owners;
            realEstateContext.owners.Add(owner);
            realEstateContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(String id)
        {
            Owner owner = realEstateContext.owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        public ActionResult Edit(String id)
        {
            Owner owner = realEstateContext.owners.SingleOrDefault(x => x.OwnerNo == id);
            ViewBag.OwnerDetails = new SelectList(realEstateContext.owners);
            return View(owner);
        }
        [HttpPost]
        public ActionResult Edit(String id, Owner updatedOwner)
        {
            Owner owner = realEstateContext.owners.SingleOrDefault(x => x.OwnerNo == id);
            owner.Fname = updatedOwner.Fname;
            owner.Lname = updatedOwner.Lname;
            owner.Address = updatedOwner.Address;
            owner.TelNo = owner.TelNo;
            realEstateContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Owner owner = realEstateContext.owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteBranch(String id)
        {
            Owner owner = realEstateContext.owners.SingleOrDefault(x => x.OwnerNo == id);
            realEstateContext.owners.Remove(owner);
            realEstateContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}