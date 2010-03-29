using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Wotan.Engine
{
	abstract class SynchronizedList<T> : IList<T> //, IList, ICollection, IEnumerable
	{
		List<T> innerList = new List<T>();
		object root = new object();

		protected SynchronizedList() : base() { }

		#region IList<T> Members

		public int IndexOf(T item)
		{
			lock (root)
			{
				return innerList.IndexOf(item);
			}
		}

		public void Insert(int index, T item)
		{
			lock (root)
			{
				innerList.Insert(index, item);
			}
		}

		public void RemoveAt(int index)
		{
			lock (root)
			{
				innerList.RemoveAt(index);
			}
		}

		public T this[int index]
		{
			get
			{
				lock (root)
				{
					return innerList[index];
				}
			}
			set
			{
				lock (root)
				{
					innerList[index] = value;
				}
			}
		}

		#endregion

		#region ICollection<T> Members

		public void Add(T item)
		{
			lock (root)
			{
				innerList.Add(item);
			}
		}

		public void Clear()
		{
			lock (root)
			{
				innerList.Clear();
			}
		}

		public bool Contains(T item)
		{
			lock (root)
			{
				return innerList.Contains(item);
			}
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			lock (root)
			{
				innerList.CopyTo(array, arrayIndex);
			}
		}

		public int Count
		{
			get {
				lock (root)
				{
					return innerList.Count;
				}
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public bool Remove(T item)
		{
			lock (root)
			{
				return innerList.Remove(item);
			}
		}

		#endregion

		#region IEnumerable<T> Members

		public IEnumerator<T> GetEnumerator()
		{
			lock (root)
			{
				return innerList.GetEnumerator();
			}
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			lock (root)
			{
				return ((IEnumerable)innerList).GetEnumerator();
			}
		}

		#endregion
	}
}
