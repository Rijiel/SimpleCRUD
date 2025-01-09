using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Core.Dto;
public class PersonUpdateRequest
{
	[Required]
	public int Id { get; set; }

	[Required]
	[StringLength(50)]
	public string FirstName { get; set; } = null!;

	[Required]
	[StringLength(50)]
	public string LastName { get; set; } = null!;

	[EmailAddress]
	[StringLength(50)]
	public string? Email { get; set; } = null!;

	[Required]
	[Range(1, 120)]
	public int Age { get; set; }
}
