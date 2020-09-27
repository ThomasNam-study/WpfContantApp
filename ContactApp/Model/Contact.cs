﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ContactApp.Model
{
	public class Contact
	{
		[PrimaryKey, AutoIncrement]
		public int Id{ get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public override string ToString()
		{
			return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(Phone)}: {Phone}";
		}
	}
}
