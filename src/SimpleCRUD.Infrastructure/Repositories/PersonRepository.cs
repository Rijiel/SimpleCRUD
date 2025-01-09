using Microsoft.EntityFrameworkCore;
using SimpleCrud.Core.Domain.Models;
using SimpleCRUD.Core.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Infrastructure.Repositories;
public class PersonRepository : IPersonRepository
{
	private readonly ApplicationDbContext _context;

	public PersonRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Person>> GetAllAsync(Expression<Func<Person, bool>>? expression = null)
	{
		return await _context.Persons.Where(expression?? (x => true)).ToListAsync();
	}

	public async Task<Person?> GetAsync(Expression<Func<Person, bool>> expression, bool tracked = false)
	{
		return await (
			tracked ? _context.Persons 
			: _context.Persons.AsNoTracking())
			.FirstOrDefaultAsync(expression);
	}

	public async Task AddAsync(Person person)
	{
		_context.Persons.Add(person);
		await _context.SaveChangesAsync();
	}

	public async Task AddRangeAsync(IEnumerable<Person> persons)
	{
		_context.Persons.AddRange(persons);
		await _context.SaveChangesAsync();
	}

	public async Task RemoveAsync(Person person)
	{
		_context.Persons.Remove(person);
		await _context.SaveChangesAsync();
	}

	public async Task RemoveRangeAsync(IEnumerable<Person> persons)
	{
		_context.Persons.RemoveRange(persons);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Person person)
	{
		_context.Persons.Update(person);
		await _context.SaveChangesAsync();
	}
}
