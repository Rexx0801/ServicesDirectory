using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestSharp;

namespace WebUI.Controllers
{
    public class VolunteeringOpportunityController : Controller
    {
        private readonly RestClient _client;

        public VolunteeringOpportunityController(RestClient @object)
        {
            _client = new RestClient("http://localhost:5056/");
        }

        public async Task<IActionResult> Index(string? sort)
        {
            var request = new RestRequest("api/volunteeringopportunity", Method.Get);
            var response = await _client.ExecuteAsync<List<VolunteeringDto>>(request);

            if (response.IsSuccessful)
            {
                var data = response.Data;
                if (sort == "asc")
                {
                    data = data.OrderBy(v => v.VolunteeringContact).ToList();
                    ViewData["SortOrder"] = "desc";
                }
                else if (sort == "desc")
                {
                    data = data.OrderByDescending(v => v.VolunteeringContact).ToList();
                    ViewData["SortOrder"] = "asc";
                }
                else
                {
                    ViewData["SortOrder"] = "asc";
                }

                return View(data);
            }
            return View(new List<VolunteeringDto>());
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var request = new RestRequest($"api/volunteeringopportunity/{id}", Method.Get);
            var response = await _client.ExecuteAsync<VolunteeringDto>(request);

            if (response.IsSuccessful)
            {
                return View(response.Data);
            }

            return NotFound();
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



        public async Task<IActionResult> Edit(Guid id)
        {
            var request = new RestRequest($"api/volunteeringopportunity/{id}", Method.Get);
            var response = await _client.ExecuteAsync<VolunteeringDto>(request);

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
        public async Task<IActionResult> Create(VolunteeringDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.VolunteeringId = Guid.NewGuid();
                    var request = new RestRequest("api/volunteeringopportunity", Method.Post);
                    request.AddJsonBody(model);
                    var response = await _client.ExecuteAsync<VolunteeringDto>(request);
                    if (response.IsSuccessful)
                    {
                        return RedirectToAction("Index");
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(VolunteeringDto model)
        {
            if (ModelState.IsValid)
            {
                var request = new RestRequest($"api/volunteeringopportunity/{model.VolunteeringId}", Method.Put);
                request.AddJsonBody(model);
                var response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new RestRequest($"api/volunteeringopportunity/{id}", Method.Get);
            var response = await _client.ExecuteAsync<VolunteeringDto>(request);
            if (response.IsSuccessful)
            {
                return View(response.Data);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var request = new RestRequest($"api/volunteeringopportunity/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
