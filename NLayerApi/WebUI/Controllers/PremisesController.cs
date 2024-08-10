using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace WebUI.Controllers;

public class PremisesController : Controller
{
    private readonly RestClient _client;

    public PremisesController()
    {
        _client = new RestClient("http://localhost:5056/api");
    }

    public async Task<IActionResult> Index(bool includeInactive = false, string filter = "", int pageNumber = 1, int pageSize = 15)
    {
        var request = new RestRequest("premises", Method.Get);
        request.AddParameter("includeInactive", includeInactive);
        request.AddParameter("filter", filter);
        var response = await _client.ExecuteAsync<List<PremiseDto>>(request);

        if (response.Data == null)
        {
            return View(new List<PremiseDto>());
        }

        var pagedData = response.Data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        var totalRecords = response.Data.Count;
        var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

        ViewBag.CurrentPage = pageNumber;
        ViewBag.TotalPages = totalPages;
        ViewBag.ActionName = "Index";
        return View(pagedData);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var request = new RestRequest($"premises/{id}", Method.Get);
        var response = await _client.ExecuteAsync<PremiseDto>(request);

        if (response.Data == null)
        {
            return NotFound();
        }

        if (response.Data.IsActive.HasValue && !response.Data.IsActive.Value)
        {
            TempData["InactivePremiseId"] = id;
            return RedirectToAction("ConfirmActivation", new { id });
        }

        return View(response.Data);
    }

    [HttpGet]
    public async Task<IActionResult> IncludeInactive(int pageNumber = 1, int pageSize = 15)
    {
        var request = new RestRequest("premises/include-inactive", Method.Get);
        request.AddParameter("pageNumber", pageNumber);
        request.AddParameter("pageSize", pageSize);
        var response = await _client.ExecuteAsync<List<PremiseDto>>(request);

        if (response.Data == null)
        {
            return View("Index", new List<PremiseDto>());
        }

        // Phân trang
        var pagedData = response.Data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        var totalRecords = response.Data.Count;
        var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

        ViewBag.CurrentPage = pageNumber;
        ViewBag.TotalPages = totalPages;
        ViewBag.ActionName = "IncludeInactive";
        return View("Index", pagedData);
    }

    public async Task<IActionResult> ConfirmActivation(Guid id)
    {
        var request = new RestRequest($"premises/{id}", Method.Get);
        var response = await _client.ExecuteAsync<PremiseDto>(request);

        if (response.Data == null)
        {
            return NotFound();
        }

        return View(response.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Activate(Guid id)
    {
        var request = new RestRequest($"premises/{id}/activate", Method.Post);
        await _client.ExecuteAsync(request);
        return RedirectToAction("Details", new { id });
    }

    [HttpPost]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        var request = new RestRequest($"premises/{id}/deactivate", Method.Post);
        await _client.ExecuteAsync(request);
        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult CancelActivation()
    {
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> HandleInactive(Guid id, bool activate)
    {
        var request = new RestRequest($"premises/{id}/handle-inactive", Method.Post);
        request.AddJsonBody(new { activate });
        await _client.ExecuteAsync(request);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Filter(string filter)
    {
        var request = new RestRequest("premises/filter", Method.Get);
        request.AddParameter("filter", filter);
        var response = await _client.ExecuteAsync<List<PremiseDto>>(request);

        if (response.Data == null)
        {
            return View("Index", new List<PremiseDto>());
        }

        return View("Index", response.Data);
    }

    public async Task<IActionResult> Sort(string columnName, int pageNumber = 1, int pageSize = 15)
    {
        var request = new RestRequest("premises/sort", Method.Get);
        request.AddParameter("columnName", columnName);
        request.AddParameter("pageNumber", pageNumber);
        request.AddParameter("pageSize", pageSize);
        var response = await _client.ExecuteAsync<List<PremiseDto>>(request);

        if (response.Data == null)
        {
            return View("Index", new List<PremiseDto>());
        }

        var pagedData = response.Data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        var totalRecords = response.Data.Count;
        var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

        ViewBag.CurrentPage = pageNumber;
        ViewBag.TotalPages = totalPages;
        ViewBag.ActionName = "Sort";
        ViewBag.ColumnName = columnName;

        return View("Index", pagedData);
    }

    public async Task<IActionResult> NewPremises()
    {
        var request = new RestRequest("premises/new", Method.Get);
        var response = await _client.ExecuteAsync<List<PremiseDto>>(request);

        if (response.Data == null)
        {
            return View("Index", new List<PremiseDto>());
        }

        return View("Index", response.Data);
    }
}