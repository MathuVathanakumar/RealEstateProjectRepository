using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateProject.Models;

namespace RealEstateProject.Controllers
{
    public class RentController : Controller
    {
        // GET: Rent
        private RealEstateContext realEstateContexts = new RealEstateContext();
        public ActionResult Index()
        {
            List<Rent> AllRents = realEstateContexts.rents.ToList();
            return View(AllRents);
        }

        public ActionResult Create()//Load
        { //Dropdown list 
            ViewBag.OwnerDetails = realEstateContexts.owners;
            ViewBag.StaffDetails = realEstateContexts.staffs;
            ViewBag.BranchDetails = realEstateContexts.branches;
            return View();

        }
        [HttpPost]
        public ActionResult Create(Rent rent)//Insert
        {
            ViewBag.OwnerDetails = realEstateContexts.owners;
            ViewBag.StaffDetails = realEstateContexts.staffs;
            ViewBag.BranchDetails = realEstateContexts.branches;
            realEstateContexts.rents.Add(rent);
            realEstateContexts.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Rent rent = realEstateContexts.rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        public ActionResult Edit(String id)
        {
            Rent rent = realEstateContexts.rents.SingleOrDefault(x => x.PropertyNo == id);
            ViewBag.OwnerDetails = new SelectList(realEstateContexts.owners, "OwnerNo", "OwnerNo");
            ViewBag.StaffDetails = new SelectList(realEstateContexts.staffs, "StaffNo", "StaffNo");
            ViewBag.BranchDetails = new SelectList(realEstateContexts.branches, "BranchNo", "BranchNo");
            return View(rent);
        }
        [HttpPost]
        public ActionResult Edit(String id, Rent updatedRent)
        {
            Rent rent = realEstateContexts.rents.SingleOrDefault(x => x.PropertyNo == id);
            rent.Street = updatedRent.Street;
            rent.City = updatedRent.City;
            rent.Ptype = updatedRent.Ptype;
            rent.Rooms = updatedRent.Rooms;
            rent.RefOwnerNo = updatedRent.RefOwnerNo;
            rent.RefStaffNo = updatedRent.RefStaffNo;
            rent.RefBranchNo = updatedRent.RefBranchNo;
            rent.Rent1 = updatedRent.Rent1;
            realEstateContexts.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Rent rent = realEstateContexts.rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteRent(String id)
        {
            Rent rent = realEstateContexts.rents.SingleOrDefault(x => x.PropertyNo == id);
            realEstateContexts.rents.Remove(rent);
            realEstateContexts.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult City()
        {
            List<Rent> CityName= realEstateContexts.rents.ToList();

            return View(CityName);
        }

        public ActionResult Property(String id)
        {
            List<Rent> PropertyNo = realEstateContexts.rents.Where(x => x.City == id).ToList();
            return View(PropertyNo);
        }
        public ActionResult PropertyDetails(String id)//action for get details of individual
        {
            Rent rent = realEstateContexts.rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        public ActionResult BuildingCount(String id)
        {
            List<Rent> building = realEstateContexts.rents.Where(x => x.RefBranchNo == id).ToList();
            return View(building);
        }
    }
}