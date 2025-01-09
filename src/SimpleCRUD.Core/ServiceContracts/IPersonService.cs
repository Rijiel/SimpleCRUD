using SimpleCrud.Core.Domain.Models;
using SimpleCRUD.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Core.ServiceContracts;
public interface IPersonService
{
	Task<List<PersonResponse>> GetAllAsync(Expression<Func<Person, bool>>? expression = null);

	Task<List<PersonResponse>> GetFilteredAsync(string? category, string? search);

	Task<PersonResponse?> GetAsync(Expression<Func<Person, bool>> expression, bool tracked = false);

	Task<PersonResponse> AddAsync(PersonAddRequest? request);

	Task<List<PersonResponse>> AddRangeAsync(List<PersonAddRequest> request);

	Task<PersonResponse> UpdateAsync(PersonUpdateRequest? request);

	Task RemoveAsync(int? id);

	Task RemoveRangeAsync(IEnumerable<PersonResponse>? request);
}
