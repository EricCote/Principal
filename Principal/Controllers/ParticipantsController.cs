using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Principal.Services;

namespace Principal.Controllers
{
    public class ParticipantsController : Controller
    {
        IParticipants _participants;

        public ParticipantsController(IParticipants participants) { 
            _participants = participants;
        }


        // GET: ParticipantsController
        public ActionResult Index()
        {
            return View(_participants.Liste);
        }

        // GET: ParticipantsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticipantsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParticipantsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParticipantsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
