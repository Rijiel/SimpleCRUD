using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCRUD.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Infrastructure;

internal class PersonsSeedConfiguration : IEntityTypeConfiguration<Person>
{
	public void Configure(EntityTypeBuilder<Person> builder)
	{
		builder.HasData(
			new Person
			{
				Id = 1,
				FirstName = "John",
				LastName = "Doe",
				Email = "johndoe@example.com",
				Age = 30
			},
			new Person
			{
				Id = 2,
				FirstName = "Jane",
				LastName = "Doe",
				Email = "janeDoe@example.com",
				Age = 25
			},
			new Person
			{
				Id = 3,
				FirstName = "Bob",
				LastName = "Smith",
				Email = "bobsmith@example.com",
				Age = 35
			}
		);
	}
}
