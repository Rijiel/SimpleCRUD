using SimpleCrud.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Core.Domain.RepositoryContracts;
public interface IPersonRepository
{
	Task<IEnumerable<Person>> GetAllAsync(Expression<Func<Person, bool>>? expression = null);

	Task<Person?> GetAsync(Expression<Func<Person, bool>> expression, bool tracked = false);

	Task AddAsync(Person person);

	Task AddRangeAsync(IEnumerable<Person> persons);

	Task UpdateAsync(Person person);

	Task DeleteAsync(Person person);

	Task RemoveRangeAsync(IEnumerable<Person> persons);
}
