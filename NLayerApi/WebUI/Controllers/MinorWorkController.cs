using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestSharp;

namespace WebUI.Controllers
{
    public class MinorWorkController : Controller
    {
        private readonly RestClient _client;

        public MinorWorkController()
        {
            _client = new RestClient("http://localhost:5056/");
        }
        public async Task<IActionResult> Index(string? sortOrder)
        {
            var request = new RestRequest($"api/minorwork?sortOrder={sortOrder}", Method.Get);
            var response = await _client.ExecuteAsync<List<MinorWorkDto>>(request);
            if (response.IsSuccessful)
            {
                ViewData["CurrentSortOrder"] = sortOrder;
                return View(response.Data);
            }
            return View(new List<MinorWorkDto>());
        }

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

        [HttpPost]
        public async Task<IActionResult> Create(MinorWorkDto model)
        {
            if (ModelState.IsValid)
            {
                model.MinorWorkId = Guid.NewGuid();
                var request = new RestRequest("api/minorwork", Method.Post);
                request.AddJsonBody(model);
                var response = await _client.ExecuteAsync<MinorWorkDto>(request);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var request = new RestRequest($"api/minorwork/{id}", Method.Get);
            var response = await _client.ExecuteAsync<MinorWorkDto>(request);
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

        [HttpPost]
        public async Task<IActionResult> Edit(MinorWorkDto model)
        {
            if (ModelState.IsValid)
            {
                var request = new RestRequest($"api/minorwork/{model.MinorWorkId}", Method.Put);
                request.AddJsonBody(model);
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("Index");
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
            return View(model);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new RestRequest($"api/minorwork/{id}", Method.Get);
            var response = await _client.ExecuteAsync<MinorWorkDto>(request);
            if (response.IsSuccessful)
            {
                return View(response.Data);
            }
            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var request = new RestRequest($"api/minorwork/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}