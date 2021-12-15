using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using LMS.Models;

namespace LMS.Controllers
{
    public class LeaveTypesController : Controller
    {
        public static List<LeaveType> LeaveTypes = new List<LeaveType>();
        public IActionResult Index()
        {
            return View(LeaveTypes);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            LeaveType leaveType = LeaveTypes.Find(l => l.Id == id);
            return View(leaveType);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LeaveType leaveType)
        {
                leaveType.Id = LeaveTypes.Count()==0?1: LeaveTypes.Last<LeaveType>().Id + 1;
                leaveType.IsActive = true;
                LeaveTypes.Add(leaveType);
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            LeaveType leaveType = LeaveTypes.Find(l=>l.Id==id);
            return View(leaveType);
        }
        [HttpPost]
        public IActionResult Edit(LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                LeaveType leave_Type = LeaveTypes.Find(l => l.Id == leaveType.Id);
                if (leaveType != null)
                {
                    LeaveTypes.Remove(leave_Type);
                    LeaveTypes.Add(leaveType);
                    return RedirectToAction("Index");
                }
            }
            return View(leaveType);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            LeaveType leave_Type = LeaveTypes.Find(l => l.Id == id);
            return View(leave_Type);
        }
        [HttpPost]
        public IActionResult Delete(LeaveType leaveType)
        {
            LeaveType leave_Type = LeaveTypes.Find(l => l.Id == leaveType.Id);
            if (leave_Type != null) 
            {
                LeaveTypes.Remove(leave_Type);
                return RedirectToAction("Index");
            }
            return View(leaveType);
        }
    }
}
