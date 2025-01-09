using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SimpleCrud.Core.Domain.Models.ViewModels;
using SimpleCRUD.Core.Dto;
using SimpleCRUD.Core.ServiceContracts;
using SimpleCRUD.UI.Filters;

namespace SimpleCRUD.UI.Controllers;

[Route("[controller]/[action]")]
[TypeFilter(typeof(LayoutDataFilter))]
public class HomeController : Controller
{
	private readonly IPersonService _service;
	private readonly IMapper _mapper;

	public HomeController(IPersonService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	[Route("/")]
	public async Task<IActionResult> Index(string? category, string? search)
	{
		ViewData["SelectedCategory"] = category;

		IEnumerable<PersonResponse> persons = await _service.GetFilteredAsync(category, search);

		return View(persons);
	}

	[HttpGet]
	public IActionResult Create() => View();

	[HttpPost]
	public async Task<IActionResult> Create(PersonAddRequest request)
	{
		await _service.AddAsync(request);

		return RedirectToAction(nameof(Index));
	}

	[HttpGet("{id?}")]
	public async Task<IActionResult> Edit(int? id)
	{
		PersonResponse? person = await _service.GetAsync(x => x.Id == id);
		if (person == null)
		{
			return NotFound();
		}

		return View(_mapper.Map<PersonUpdateRequest>(person));
	}

	[HttpPost("{id?}")]
	public async Task<IActionResult> Edit(PersonUpdateRequest request)
	{
		await _service.UpdateAsync(request);

		return RedirectToAction(nameof(Index));
	}

	[HttpGet("{id?}")]
	public async Task<IActionResult> Delete(int? id)
	{
		PersonResponse? person = await _service.GetAsync(x => x.Id == id);
		if (person == null)
		{
			return NotFound();
		}

		return View(person);
	}

	[HttpPost("{id?}")]
	public async Task<IActionResult> Delete(PersonResponse request)
	{
		await _service.RemoveAsync(request.Id);

		return RedirectToAction(nameof(Index));
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
