using System;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots
{
	public class Entity
	{
		private readonly List<IComponent> Components = new();

		private static bool IsInstance<T>(object component)
		{
			var r = typeof(T).IsInstanceOfType(component);
			return r;
		}

		public void Add<T>(IComponent component)
		{
			Components.Add(component);
		}

		public IEnumerable<T> GetAll<T>() where T : IComponent
		{
			return Components.Where(IsInstance<T>).Select(c => (T)c);
		}

        public T Get<T>() where T : IComponent
        {
			return (T)Components.First(IsInstance<T>);
		}

		public void Replace<T>(T component) where T : IComponent
		{
			var idx = Components.FindIndex(IsInstance<T>);
			if (idx >= 0)
			{
				Components[idx] = component;
			}
			else
			{
				Components.Add(component);
			}
		}

		public void Replace(IEnumerable<IComponent> components)
		{
			Components.Clear();
			Components.AddRange(components);
		}

		public void Replace<T>(IEnumerable<IComponent> components) where T : IComponent
		{
			Components.RemoveAll(IsInstance<T>);
			Components.AddRange(components);
		}
	}
}

