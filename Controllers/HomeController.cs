using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reviews.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace reviews.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _context;
        public HomeController(ReviewContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
    
            
            return View();
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.thereviews.ToList();
            ViewBag.allreviews = AllReviews;

            return View();
        }
        [HttpPost]
        [Route("addreview")]
        public IActionResult AddReview(Review review)
        {
            if(ModelState.IsValid)
            {
                _context.thereviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Reviews");                
            }
            return View("Index");
        }
        [HttpGet]
        [Route("remove/{id}/")]
        public IActionResult Remove(int id)
        {
            Review rereview = _context.thereviews.SingleOrDefault(review => review.reviewid == id);
           _context.thereviews.Remove(rereview);
           _context.SaveChanges();
            return RedirectToAction("Reviews");
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
