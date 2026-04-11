using Microsoft.AspNetCore.Mvc;
using SmartRetailMVC.Models;
using System.Text;
using System.Text.Json;

namespace SmartRetailMVC.Controllers;

public class ProductController : Controller
{
    private readonly HttpClient _http;
    private readonly string _api;

    public ProductController(IHttpClientFactory factory, IConfiguration config)
    {
        _http = factory.CreateClient();
        _api = config["ApiBaseUrl"]!;
    }

    public async Task<IActionResult> Index()
    {
        var res = await _http.GetStringAsync($"{_api}/products");
        var list = JsonSerializer.Deserialize<List<Product>>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return View(list);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Product p)
    {
        var json = new StringContent(JsonSerializer.Serialize(p), Encoding.UTF8, "application/json");
        await _http.PostAsync($"{_api}/products", json);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var res = await _http.GetStringAsync($"{_api}/products/{id}");
        var p = JsonSerializer.Deserialize<Product>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return View(p);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product p)
    {
        var json = new StringContent(JsonSerializer.Serialize(p), Encoding.UTF8, "application/json");
        await _http.PutAsync($"{_api}/products/{id}", json);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _http.DeleteAsync($"{_api}/products/{id}");
        return RedirectToAction("Index");
    }
}