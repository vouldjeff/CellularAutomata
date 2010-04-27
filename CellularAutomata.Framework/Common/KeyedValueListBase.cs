using System;
using System.Collections;
using System.Collections.Generic;

namespace CellularAutomata.Framework.Common
{
    public abstract class KeyedValueListBase<TKey, TElement> : IKeyedValueList<TElement, TKey>,
                                                               IKeyedValueListReadOnly<TElement, TKey>
    {
        private List<TElement> _list;
        private Dictionary<TKey, TElement> _dict;
        private bool _isReadOnly;

        protected KeyedValueListBase()
        {
            _list = new List<TElement>();
            _dict = new Dictionary<TKey, TElement>();
        }

        protected KeyedValueListBase(IEqualityComparer<TKey> comparer)
        {
            _list = new List<TElement>();
            _dict = new Dictionary<TKey, TElement>(comparer);
        }

        protected KeyedValueListBase(KeyedValueListBase<TKey, TElement> exising, bool isReadOnly)
        {
            _list = exising._list;
            _dict = exising._dict;
            _isReadOnly = isReadOnly;
        }

        public virtual TElement this[int index]
        {
            get { return Get(index); }
            set { Set(index, value); }
        }

        public virtual TElement this[TKey key]
        {
            get { return Get(key); }
            set { Set(key, value); }
        }

        public virtual int Count
        {
            get { return _list.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return _isReadOnly; }
        }

        public virtual IEnumerable<TKey> Keys
        {
            get { return _dict.Keys; }
        }

        public virtual IEnumerable<TElement> Values
        {
            get { return _dict.Values; }
        }

        public virtual IEnumerable<TElement> OrderedValues
        {
            get { return _list; }
        }

        public virtual TElement Get(int index)
        {
            return _list[index];
        }

        public virtual TElement Get(TKey key)
        {
            return Get(key, false);
        }

        public virtual TElement Get(TKey key, bool ensureExists)
        {
            Guard.CheckForNullReference(key, "key");

            TElement element = default(TElement);
            if (!_dict.TryGetValue(key, out element))
            {
                if (ensureExists)
                {
                    throw new Exception(string.Format("Item with key '{0}' does not exists", key));
                }
            }

            return element;
        }

        protected virtual void Set(int index, TElement element)
        {
            Guard.CheckForNullReference(element, "element");
            CheckReadonly();

            TElement oldValue = _list[index];
            TKey oldKey = GetKey(oldValue);

            _dict.Remove(oldKey);

            TKey key = GetKey(element);

            OnAdd(element);

            _list[index] = element;
            _dict.Add(key, element);
        }

        protected virtual void Set(TKey key, TElement element)
        {
            Guard.CheckForNullReference(element, "element");
            CheckReadonly();

            Remove(key);

            OnAdd(element);

            _list.Add(element);
            _dict[key] = element;
        }

        public virtual void Add(TElement element)
        {
            Guard.CheckForNullReference(element, "element");
            CheckReadonly();

            TKey key = GetKey(element);
            CheckNotExist(key);

            OnAdd(element);

            _list.Add(element);
            _dict.Add(key, element);
        }

        public virtual void Insert(int index, TElement element)
        {
            Guard.CheckForNullReference(element, "element");
            CheckReadonly();

            TKey key = GetKey(element);
            CheckNotExist(key);

            OnAdd(element);

            _list.Insert(index, element);
            _dict.Add(key, element);
        }

        public virtual int IndexOf(TElement element)
        {
            Guard.CheckForNullReference(element, "element");

            return _list.IndexOf(element);
        }

        public virtual void Clear()
        {
            CheckReadonly();

            for (int i = _list.Count - 1; i >= 0; i--)
            {
                TElement element = _list[i];
                OnRemove(element);

                TKey key = GetKey(element);
                _list.RemoveAt(i);
                _dict.Remove(key);
            }
        }

        public virtual bool Contains(TElement element)
        {
            return _list.Contains(element);
        }

        public virtual bool ContainsKey(TKey key)
        {
            return _dict.ContainsKey(key);
        }

        public virtual void CopyTo(TElement[] array, int arrayIndex)
        {
            Guard.CheckForNullReference(array, "array");
            if (array.Length < arrayIndex)
            {
                throw new Exception("Array index must be less then array length");
            }

            for (int i = arrayIndex; i < array.Length; i++)
            {
                array[i] = _list[i];
            }
        }

        public virtual bool Remove(TKey key)
        {
            CheckReadonly();

            if (!_dict.ContainsKey(key))
            {
                return false;
            }

            TElement element = _dict[key];
            OnRemove(element);

            _list.Remove(element);
            _dict.Remove(key);

            return true;
        }

        public virtual bool Remove(TElement element)
        {
            Guard.CheckForNullReference(element, "element");
            CheckReadonly();

            TKey key = GetKey(element);
            if (!_dict.ContainsKey(key))
            {
                return false;
            }

            OnRemove(element);

            _list.Remove(element);
            _dict.Remove(key);

            return true;
        }

        public virtual void RemoveAt(int index)
        {
            CheckReadonly();

            TElement element = _list[index];
            TKey key = GetKey(element);

            OnRemove(element);

            _list.RemoveAt(index);
            _dict.Remove(key);
        }

        public virtual void SwapPossitions(int index1, int index2)
        {
            lock (this)
            {
                TElement e1 = _list[index1];
                TElement e2 = _list[index2];

                _list[index1] = e2;
                _list[index2] = e1;
            }
        }

        public virtual void SwapPossitions(TKey key1, TKey key2)
        {
            TElement item1 = _dict[key1];
            TElement item2 = _dict[key2];

            SwapPossitions(item1, item2);
        }

        public virtual void SwapPossitions(TElement item1, TElement item2)
        {
            lock (this)
            {
                int index1 = _list.IndexOf(item1);
                int index2 = _list.IndexOf(item2);

                _list[index1] = item2;
                _list[index2] = item1;
            }
        }

        public virtual bool MoveAt(TKey key, int newIndex)
        {
            TElement item = _dict[key];
            return MoveAt(item, newIndex);
        }

        public virtual bool MoveAt(TElement item, int newIndex)
        {
            if (newIndex < 0 || newIndex >= _list.Count)
            {
                return false;
            }

            _list.Remove(item);
            _list.Insert(newIndex, item);

            return true;
        }

        public virtual bool MoveDown(TKey key)
        {
            TElement item = _dict[key];
            return MoveDown(item);
        }

        public virtual bool MoveDown(TElement item)
        {
            lock (this)
            {
                int pos = _list.IndexOf(item);

                if (pos + 1 >= _list.Count)
                {
                    return false;
                }

                SwapPossitions(pos, pos + 1);

                return true;
            }
        }

        public virtual bool MoveUp(TKey key)
        {
            TElement item = _dict[key];
            return MoveUp(item);
        }

        public virtual bool MoveUp(TElement item)
        {
            lock (this)
            {
                int pos = _list.IndexOf(item);

                if (pos - 1 < 0)
                {
                    return false;
                }

                SwapPossitions(pos, pos - 1);

                return true;
            }
        }

        public virtual void Sort()
        {
            _list.Sort();
        }

        public virtual void Sort(Comparison<TElement> compare)
        {
            _list.Sort(compare);
        }

        public virtual void Sort(IComparer<TElement> comparer)
        {
            _list.Sort(comparer);
        }

        public virtual TElement[] ToArray()
        {
            return _list.ToArray();
        }

        public virtual List<TElement> FindAll(Predicate<TElement> match)
        {
            return _list.FindAll(match);
        }

        public virtual TElement Find(Predicate<TElement> match)
        {
            return _list.Find(match);
        }

        public virtual int FindIndex(int startIndex, int count, Predicate<TElement> match)
        {
            return _list.FindIndex(startIndex, count, match);
        }

        public virtual int FindIndex(int startIndex, Predicate<TElement> match)
        {
            return _list.FindIndex(startIndex, match);
        }

        public virtual int FindIndex(Predicate<TElement> match)
        {
            return _list.FindIndex(match);
        }

        public virtual TElement FindLast(Predicate<TElement> match)
        {
            return _list.FindLast(match);
        }

        public virtual int FindLastIndex(int startIndex, int count, Predicate<TElement> match)
        {
            return _list.FindLastIndex(startIndex, count, match);
        }

        public virtual int FindLastIndex(int startIndex, Predicate<TElement> match)
        {
            return _list.FindLastIndex(startIndex, match);
        }

        public virtual int FindLastIndex(Predicate<TElement> match)
        {
            return _list.FindLastIndex(match);
        }

        public void ForEach(Action<TElement> action)
        {
            _list.ForEach(action);
        }

        public virtual bool Exists(Predicate<TElement> match)
        {
            return _list.Exists(match);
        }

        public virtual IEnumerator<TElement> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected abstract TKey GetKey(TElement element);

        protected virtual void OnAdd(TElement element)
        {
        }

        protected virtual void OnRemove(TElement element)
        {
        }

        protected virtual void BaseAdd(TKey key, TElement element)
        {
            _list.Add(element);
            _dict.Add(key, element);
        }

        public void CheckExist(TKey key)
        {
            if (!_dict.ContainsKey(key))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CollItemNotExist, key));
            }
        }

        private void CheckNotExist(TKey key)
        {
            if (_dict.ContainsKey(key))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CollItemExist, key));
            }
        }

        private void CheckReadonly()
        {
            if (IsReadOnly)
            {
                throw new Exception("Collection is read only");
            }
        }
    }
}