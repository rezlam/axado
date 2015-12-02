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
using Axado.Areas.Admin.Models;

namespace Axado.Areas.Admin.Controllers
{
    public class CarriersController : Controller
    {
        private AxadoContext _db = new AxadoContext();


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var carriers = from t in _db.Carriers
                           where t.Active == true
                           select t;

            return View(await carriers.ToListAsync());
        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
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

            return View(carrier);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(CarrierViewModel model)
        {
            if (ModelState.IsValid == false) {
                return View(model);
            }

            var carrier = new Carrier {
                Name = model.Name,
                Code = model.Code,
                Identification = model.Identification,
                Address = new Address {
                    StreetAddress = model.StreetAddress,
                    District = model.District,
                    Locality = model.Locality,
                    Region = model.Region
                },
                PhoneNumber = model.PhoneNumber,
                Url = model.Url,
                PricePerKm = model.PricePerKm,
                PickUpTime = model.PickUpTime
            };

            _db.Carriers.Add(carrier);

            int x = await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
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

            var viewModel = new CarrierViewModel {
                Id = carrier.Id,
                Name = carrier.Name,
                Code = carrier.Code,
                Identification = carrier.Identification,
                StreetAddress = carrier.Address.StreetAddress,
                District = carrier.Address.District,
                Locality = carrier.Address.Locality,
                Region = carrier.Address.Region,
                PhoneNumber = carrier.PhoneNumber,
                Url = carrier.Url,
                PricePerKm = carrier.PricePerKm,
                PickUpTime = carrier.PickUpTime
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Edit(CarrierViewModel model)
        {
            if (ModelState.IsValid == false) {
                return View(model);
            }

            var carrier = await (from t in _db.Carriers
                                 where t.Active == true
                                 where t.Id == model.Id
                                 select t).SingleOrDefaultAsync();

            if (carrier == null) {
                return RedirectToAction("Index");
            }

            carrier.Name = model.Name;
            carrier.Code = model.Code;
            carrier.Identification = model.Identification;
            carrier.Address = new Address {
                StreetAddress = model.StreetAddress,
                District = model.District,
                Locality = model.Locality,
                Region = model.Region
            };
            carrier.PhoneNumber = model.PhoneNumber;
            carrier.Url = model.Url;
            carrier.PricePerKm = model.PricePerKm;
            carrier.PickUpTime = model.PickUpTime;

            carrier.Update();

            _db.Entry(carrier).State = EntityState.Modified;

            int x = await _db.SaveChangesAsync();

            return RedirectToAction("Details", new { id = carrier.Id });
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
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

            carrier.Delete();

            _db.Entry(carrier).State = EntityState.Modified;
            int x = await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
