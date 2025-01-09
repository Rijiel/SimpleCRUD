using AutoMapper;
using SimpleCrud.Core.Domain.Models;
using SimpleCRUD.Core.Domain.RepositoryContracts;
using SimpleCRUD.Core.Dto;
using SimpleCRUD.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Core.Services;
public class PersonService : IPersonService
{
	private readonly IPersonRepository _repository;
	private readonly IMapper _mapper;

	public PersonService(IPersonRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<List<PersonResponse>> GetAllAsync(Expression<Func<Person, bool>>? expression = null)
	{
		IEnumerable<Person> persons = await _repository.GetAllAsync(expression);

		return _mapper.Map<List<PersonResponse>>(persons);
	}

	public async Task<List<PersonResponse>> GetFilteredAsync(string? category, string? search)
	{
		if (string.IsNullOrEmpty(search)) return await GetAllAsync();

		IEnumerable<Person> persons = (category) switch
		{
			nameof(Person.FirstName)
				=> await _repository.GetAllAsync(x => x.FirstName.Contains(search!)),

			nameof(Person.LastName)
				=> await _repository.GetAllAsync(x => x.LastName.Contains(search!)),

			nameof(Person.Email)
				=> await _repository.GetAllAsync(x => x.Email!.Contains(search!)),

			nameof(Person.Age)
			=> await _repository.GetAllAsync(x => x.Age.ToString().Contains(search!)),

			_ => await _repository.GetAllAsync()
		};

		return _mapper.Map<List<PersonResponse>>(persons);
	}

	public async Task<PersonResponse?> GetAsync(Expression<Func<Person, bool>> expression, bool tracked = false)
	{
		Person? person = await _repository.GetAsync(expression, tracked);

		return _mapper.Map<PersonResponse>(person);
	}

	public async Task<PersonResponse> AddAsync(PersonAddRequest? request)
	{
		ArgumentNullException.ThrowIfNull(request);

		Person person = _mapper.Map<Person>(request);
		await _repository.AddAsync(person);

		return _mapper.Map<PersonResponse>(person);
	}

	public async Task<List<PersonResponse>> AddRangeAsync(List<PersonAddRequest> request)
	{
		List<Person> persons = _mapper.Map<List<Person>>(request);
		await _repository.AddRangeAsync(persons);

		return _mapper.Map<List<PersonResponse>>(persons);
	}

	public async Task<PersonResponse> UpdateAsync(PersonUpdateRequest? request)
	{
		ArgumentNullException.ThrowIfNull(request);

		Person person = _mapper.Map<Person>(request);
		await _repository.UpdateAsync(person);

		return _mapper.Map<PersonResponse>(person);
	}

	public async Task RemoveAsync(int? id)
	{
		ArgumentNullException.ThrowIfNull(id);

		Person? person = await _repository.GetAsync(x => x.Id == id)
			?? throw new KeyNotFoundException("Person not found");

		await _repository.RemoveAsync(person);
	}

	public Task RemoveRangeAsync(IEnumerable<PersonResponse>? request)
	{
		ArgumentNullException.ThrowIfNull(request);

		List<Person> persons = _mapper.Map<List<Person>>(request);
		return _repository.RemoveRangeAsync(persons);
	}
}
