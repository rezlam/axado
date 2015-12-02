using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Axado.Data.Models;
using Axado.Persistence;
using System.Threading.Tasks;
using Axado.Models;

namespace Axado.Controllers
{
    public class HomeController : Controller
    {
        private AxadoContext _db = new AxadoContext();


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var carriers = from t in _db.Carriers.Include(p => p.Ratings)
                           where t.Active == true
                           select t;

            return View(await carriers.ToListAsync());
        }


        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            if (id == 0) {
                return RedirectToAction("Index");
            }

            var carrier = await (from t in _db.Carriers.Include(p => p.Ratings)
                                 where t.Active == true
                                 where t.Id == id
                                 select t).SingleOrDefaultAsync();

            if (carrier == null) {
                return RedirectToAction("Index");
            }

            return View(carrier);
        }


        [HttpGet]
        public async Task<ActionResult> AddRating(int id = 0)
        {
            if (id == 0) {
                return RedirectToAction("Index");
            }

            var carrier = await (from t in _db.Carriers
                                 where t.Active == true
                                 where t.Id == id
                                 select t).SingleOrDefaultAsync();

            if (carrier == null) {
                return RedirectToAction("Index");
            }

            var viewModel = new RatingViewModel {
                CarrierId = id
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<ActionResult> AddRating(RatingViewModel model)
        {
            if (ModelState.IsValid == false) {
                return View(model);
            }

            var carrier = await (from t in _db.Carriers
                                 where t.Active == true
                                 where t.Id == model.CarrierId
                                 select t).SingleOrDefaultAsync();

            if (carrier == null) {
                return RedirectToAction("Index");
            }

            var rating = new CarrierRating {
                CarrierId = model.CarrierId,
                UserId = 1,
                Rating = model.Rating
            };

            carrier.Ratings.Add(rating);

            _db.Entry(carrier).State = EntityState.Modified;

            int x = await _db.SaveChangesAsync();

            return RedirectToAction("Details", new { id = model.CarrierId });
        }
    }
}