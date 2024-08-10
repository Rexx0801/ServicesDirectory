using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestSharp;

namespace WebUI.Controllers
{
    public class FacilityController : Controller
    {
        private readonly RestClient _client;

        public FacilityController()
        {
            _client = new RestClient("http://localhost:5056/");
        }

        // GET: Facility
        public async Task<IActionResult> Index(string? filter, string? sort)
        {
            var request = new RestRequest($"api/facility?filter={filter}&sort={sort}", Method.Get);
            var response = await _client.ExecuteAsync<List<FacilityDto>>(request);
            if (response.IsSuccessful)
            {
                ViewData["CurrentFilter"] = filter;
                ViewData["CurrentSort"] = sort;
                return View(response.Data);
            }
            return View(new List<FacilityDto>());
        }

        // GET: Facility/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var request = new RestRequest($"api/facility/{id}", Method.Get);
            var response = await _client.ExecuteAsync<FacilityDto>(request);
            if (response.IsSuccessful)
            {
                return View(response.Data);
            }
            return NotFound();
        }

        // GET: Facility/Create
        public async Task<IActionResult> Create()
        {
            var requestPre = new RestRequest("api/premises", Method.Get);
            var responsePre = await _client.ExecuteAsync<List<PremiseDto>>(requestPre);

            if (responsePre.IsSuccessful && responsePre.Data != null)
            {
                ViewBag.Premises = new SelectList(responsePre.Data, "PremiseId", "PremiseName");
            }
            else
            {
                ViewBag.Premises = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            }
            return View();
        }

        // POST: Facility/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FacilityDto facility)
        {
            if (ModelState.IsValid)
            {
                facility.FacilityId = Guid.NewGuid();
                var request = new RestRequest("api/facility", Method.Post);
                request.AddJsonBody(facility);
                var response = await _client.ExecuteAsync<FacilityDto>(request);
                if (response.IsSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var requestPre = new RestRequest("api/premises", Method.Get);
            var responsePre = await _client.ExecuteAsync<List<PremiseDto>>(requestPre);

            if (responsePre.IsSuccessful && responsePre.Data != null)
            {
                ViewBag.Premises = new SelectList(responsePre.Data, "PremiseId", "PremiseName");
            }
            else
            {
                ViewBag.Premises = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            }
            return View(facility);
        }

        // GET: Facility/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var request = new RestRequest($"api/facility/{id}", Method.Get);
            var response = await _client.ExecuteAsync<FacilityDto>(request);
            if (response.IsSuccessful)
            {
                var requestPre = new RestRequest("api/premises", Method.Get);
                var responsePre = await _client.ExecuteAsync<List<PremiseDto>>(requestPre);

                if (responsePre.IsSuccessful && responsePre.Data != null)
                {
                    ViewBag.Premises = new SelectList(responsePre.Data, "PremiseId", "PremiseName");
                }
                else
                {
                    ViewBag.Premises = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
                }

                return View(response.Data);
            }
            return NotFound();
        }

        // POST: Facility/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FacilityDto facility)
        {
            if (ModelState.IsValid)
            {
                var request = new RestRequest($"api/facility/{facility.FacilityId}", Method.Put);
                request.AddJsonBody(facility);
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var requestPre = new RestRequest("api/premises", Method.Get);
            var responsePre = await _client.ExecuteAsync<List<PremiseDto>>(requestPre);

            if (responsePre.IsSuccessful && responsePre.Data != null)
            {
                ViewBag.Premises = new SelectList(responsePre.Data, "PremiseId", "PremiseName");
            }
            else
            {
                ViewBag.Premises = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            }
            return View(facility);
        }



        // POST: Facility/MarkAsInactive/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsInactive(Guid id)
        {
            var request = new RestRequest($"api/facility/{id}/mark-inactive", Method.Patch);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
