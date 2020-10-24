using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateProject.Models;

namespace RealEstateProject.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        private RealEstateContext realEstateContexts = new RealEstateContext();
        public ActionResult Index()
        {
            List<Staff> AllStaffs = realEstateContexts.staffs.ToList();
            return View(AllStaffs);
        }

        public ActionResult Create()//Load
        { //Dropdown list 
            ViewBag.BranchDetails = realEstateContexts.branches;
            return View();

        }
        [HttpPost]
        public ActionResult Create(Staff staff)//Insert
        {
            ViewBag.BranchDetails = realEstateContexts.branches;
            realEstateContexts.staffs.Add(staff);
            realEstateContexts.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Staff staff = realEstateContexts.staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        public ActionResult Edit(String id)
        {
            Staff staff = realEstateContexts.staffs.SingleOrDefault(x => x.StaffNo == id);
            ViewBag.BranchDetails = new SelectList(realEstateContexts.branches, "BranchNo", "BranchNo");
            return View(staff);
        }
        [HttpPost]
        public ActionResult Edit(String id, Staff updatedStaff)
        {
            Staff staff = realEstateContexts.staffs.SingleOrDefault(x => x.StaffNo == id);
            staff.Fname = updatedStaff.Fname;
            staff.Lname = updatedStaff.Lname;
            staff.Position = updatedStaff.Position;
            staff.DOB = updatedStaff.DOB;
            staff.Salary = updatedStaff.Salary;
            staff.Branch_BranchNo = updatedStaff.Branch_BranchNo;
            realEstateContexts.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Staff staff = realEstateContexts.staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStaff(String id)
        {
            Staff staff = realEstateContexts.staffs.SingleOrDefault(x => x.StaffNo == id);
            realEstateContexts.staffs.Remove(staff);
            realEstateContexts.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StaffPosition()
        {
            List<Staff> StaffPosition = realEstateContexts.staffs.ToList();
                                                                           
            return View(StaffPosition);
        }

        public ActionResult StaffName(String  id)
        {
            List<Staff> staff = realEstateContexts.staffs.Where(x => x.Position == id).ToList();
            return View(staff);
        }
        public ActionResult StaffDetails(String id)//action for get details of individual
        {
            Staff staff = realEstateContexts.staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }
    }
}