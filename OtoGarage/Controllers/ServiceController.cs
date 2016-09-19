using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoGarage.Controllers
{

    public class PickupAddress
    {
        public string Place { get; set; }
        public int Id { get; set; }

    }
    public class ServiceController : Controller
    {
        ServiceRequest serviceRequest;
        public ServiceController()
        {
            serviceRequest = new ServiceRequest();
        }
        private IEnumerable<PickupAddress> GetPickupAddressList()
        {
            var pickupList = new List<PickupAddress>();
            var p = new PickupAddress() {
            Place="Satellite", Id=1};

            pickupList.Add(p);

            pickupList.Add(new PickupAddress() { Place = "Gota", Id =2 });
            pickupList.Add(new PickupAddress() { Place = "Gota", Id =3 });
            pickupList.Add(new PickupAddress() { Place = "Gota", Id = 4 });
            pickupList.Add(new PickupAddress() { Place = "Gota", Id =5 });
         
            return pickupList;
        }
        // GET: Service
        public ActionResult Request()
        {
            serviceRequest.PickupAddressList  = GetPickupAddressList();
            int selectedAddress = 1;
            IEnumerable<SelectListItem> selectList =
               from s in serviceRequest.PickupAddressList
               select new SelectListItem
               {
                   Selected = (s.Id == selectedAddress),
                   Text = s.Place,
                   Value = s.Id.ToString()
               };
            var model = new DashboardIndexModel { PickupAreas = selectList };
            return View(model);
            
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

    public class ServiceRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<PickupAddress> PickupAddressList { get; set; }

        public DateTime PickupDate { get; set; }
    }

    public class DashboardIndexModel
    {
        public string Name
        {
            get; set;
        }
        [DisplayName("Pickup Address")]
        public PickupAddress PickupAddress { get; set; }
        public IEnumerable<SelectListItem> PickupAreas { get; set; } // dropdown
        [DisplayName("Pickup Date")]
        public DateTime PickupDate { get; set; }
        [DisplayName("DropOff Date")]
        public DateTime DropupDate { get; set; }
    }
}
