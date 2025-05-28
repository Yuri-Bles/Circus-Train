using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain3
{
	public class Animal
	{
		public int size { get; private set; }
		public bool isCarnivore { get; private set; }

		public Animal(int size, bool isCarnivore)
		{
			this.size = size;
			this.isCarnivore = isCarnivore;
		}

		public override string ToString()
		{
			if (isCarnivore)
			{
				return $"C{size}";
			}
			else
			{
				return $"H{size}";
			}
		}
	}
}
