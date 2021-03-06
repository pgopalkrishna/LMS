using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models;
using LMS.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS.ViewModels;
namespace LMS.Controllers
{
    public class LeaveRulesController : Controller
    {
        public static List<LeaveRule> leaveRules = new List<LeaveRule>();
        public static List<LeaveType> leaveTypes = new List<LeaveType>()
        {
            new LeaveType { Id = 1, Name = "Casual", IsActive = true },
            new LeaveType { Id = 2, Name = "Paid", IsActive = true },
            new LeaveType { Id = 3, Name = "Seek", IsActive = true },
            new LeaveType { Id = 4, Name = "Maternity", IsActive = true }
        };
        [HttpGet]
        public IActionResult Index()
        {
            var rules = (from r in leaveRules
                        join  lt in leaveTypes on r.LeaveId equals lt.Id
                        select new LeaveRuleVM {
                           Id=r.Id,
                           LeaveType=lt.Name,
                           NoOfLeaves=r.NoOfLeaves,
                           ForPeriod=r.LeaveValidity.ToString(),
                           IsCarryForward=r.IsCarryForward,
                           CarryforwardCap=r.CarryforwardCap,
                           CreatedDate=r.CreatedDate,
                           UpdatedDate=r.UpdatedDate,
                           CreatedBy=r.CreatedBy,
                           UpdatedBy=r.UpdatedBy
                        }).ToList();
            return View(rules);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            LeaveRule Rule = leaveRules.Find(l => l.Id == id);
            return View(Rule);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.RuleId = leaveRules.Count() == 0 ? 1 : leaveRules.Last<LeaveRule>().Id + 1;
            ViewBag.leaves = leaveTypes.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
            ViewBag.leaveValidity = new SelectList((from LeaveValidityEnum v in Enum.GetValues(typeof(LeaveValidityEnum)) select new { LeaveValidity = (int)v, Name = v.ToString() }), "LeaveValidity", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(LeaveRule leaveRule)
        {
            if (ModelState.IsValid)
            {
                leaveRule.CreatedDate = DateTime.Now;
                leaveRules.Add(leaveRule);
                return RedirectToAction("Index");
            }
            ViewBag.leaves = leaveTypes.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
            ViewBag.leaveValidity = new SelectList((from LeaveValidityEnum v in Enum.GetValues(typeof(LeaveValidityEnum)) select new { LeaveValidity = (int)v, Name = v.ToString() }), "LeaveValidity", "Name");
            return View(leaveRule);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            LeaveRule Rule = leaveRules.Find(l => l.Id == id);
            ViewBag.leaves = leaveTypes.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
            ViewBag.leaveValidity = (from LeaveValidityEnum v in Enum.GetValues(typeof(LeaveValidityEnum)) select new { LeaveValidity = (int)v, Name = v.ToString() }).ToList();
            return View(Rule);
        }
        [HttpPost]
        public IActionResult Edit(LeaveRule leaveRule)
        {
            if (ModelState.IsValid)
            {
                LeaveRule Rule = leaveRules.Find(l => l.Id == leaveRule.Id);
                if (Rule != null)
                {
                    leaveRules.Remove(Rule);
                    leaveRules.Add(leaveRule);
                    return RedirectToAction("Index");
                }
            }
            ViewBag.leaves = leaveTypes.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
            //ViewBag.leaveValidity = new SelectList((from LeaveValidityEnum v in Enum.GetValues(typeof(LeaveValidityEnum)) select new { LeaveValidity = (int)v, Name = v.ToString() }), "LeaveValidity", "Name");
            ViewBag.leaveValidity = (from LeaveValidityEnum v in Enum.GetValues(typeof(LeaveValidityEnum)) select new { LeaveValidity = (int)v, Name = v.ToString() }).ToList();
            return View(leaveRule);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            LeaveRule Rule = leaveRules.Find(l => l.Id == id);
            ViewBag.leaves = leaveTypes.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
            ViewBag.leaveValidity = new SelectList((from LeaveValidityEnum v in Enum.GetValues(typeof(LeaveValidityEnum)) select new { LeaveValidity = (int)v, Name = v.ToString() }), "LeaveValidity", "Name");
            return View(Rule);
        }
        [HttpPost]
        public IActionResult Delete(LeaveRule leaveRule)
        {
            LeaveRule Rule = leaveRules.Find(l => l.Id == leaveRule.Id);
            if (Rule != null)
            {
                leaveRules.Remove(Rule);
                return RedirectToAction("Index");
            }
            ViewBag.leaves = leaveTypes.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
            ViewBag.leaveValidity = new SelectList((from LeaveValidityEnum v in Enum.GetValues(typeof(LeaveValidityEnum)) select new { LeaveValidity = (int)v, Name = v.ToString() }), "LeaveValidity", "Name");
            return View(leaveRule);
        }
        
    }
}
