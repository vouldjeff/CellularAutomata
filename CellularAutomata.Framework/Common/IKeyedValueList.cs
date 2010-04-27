using System;
using System.Collections.Generic;

namespace CellularAutomata.Framework.Common
{
    public interface IKeyedValueList<TElement, TKey> : IList<TElement>
    {
        TElement this[TKey key] { get; set; }
        IEnumerable<TKey> Keys { get; }
        IEnumerable<TElement> Values { get; }
        IEnumerable<TElement> OrderedValues { get; }
        TElement Get(int index);
        TElement Get(TKey key);
        TElement Get(TKey key, bool ensureExists);
        void SwapPossitions(int index1, int index2);
        void SwapPossitions(TKey key1, TKey key2);
        void SwapPossitions(TElement item1, TElement item2);
        bool MoveAt(TKey key, int newIndex);
        bool MoveAt(TElement item, int newIndex);
        bool MoveDown(TKey key);
        bool MoveDown(TElement item);
        bool MoveUp(TKey key);
        bool MoveUp(TElement item);
        void Sort();
        void Sort(Comparison<TElement> compare);
        void Sort(IComparer<TElement> comparer);
        TElement[] ToArray();
        List<TElement> FindAll(Predicate<TElement> match);
        TElement Find(Predicate<TElement> match);
        int FindIndex(int startIndex, int count, Predicate<TElement> match);
        int FindIndex(int startIndex, Predicate<TElement> match);
        int FindIndex(Predicate<TElement> match);
        TElement FindLast(Predicate<TElement> match);
        int FindLastIndex(int startIndex, int count, Predicate<TElement> match);
        int FindLastIndex(int startIndex, Predicate<TElement> match);
        int FindLastIndex(Predicate<TElement> match);
        void ForEach(Action<TElement> action);
        bool Exists(Predicate<TElement> match);
        void CheckExist(TKey key);
    }

    public interface IKeyedValueListReadOnly<TElement, TKey>
    {
        int Count { get; }
        TElement this[TKey key] { get; }
        IEnumerable<TKey> Keys { get; }
        IEnumerable<TElement> Values { get; }
        IEnumerable<TElement> OrderedValues { get; }
        TElement Get(int index);
        TElement Get(TKey key);
        TElement Get(TKey key, bool ensureExists);
        void SwapPossitions(int index1, int index2);
        void SwapPossitions(TKey key1, TKey key2);
        void SwapPossitions(TElement item1, TElement item2);
        bool MoveAt(TKey key, int newIndex);
        bool MoveAt(TElement item, int newIndex);
        bool MoveDown(TKey key);
        bool MoveDown(TElement item);
        bool MoveUp(TKey key);
        bool MoveUp(TElement item);
        void Sort();
        void Sort(Comparison<TElement> compare);
        void Sort(IComparer<TElement> comparer);
        TElement[] ToArray();
        List<TElement> FindAll(Predicate<TElement> match);
        TElement Find(Predicate<TElement> match);
        int FindIndex(int startIndex, int count, Predicate<TElement> match);
        int FindIndex(int startIndex, Predicate<TElement> match);
        int FindIndex(Predicate<TElement> match);
        TElement FindLast(Predicate<TElement> match);
        int FindLastIndex(int startIndex, int count, Predicate<TElement> match);
        int FindLastIndex(int startIndex, Predicate<TElement> match);
        int FindLastIndex(Predicate<TElement> match);
        void ForEach(Action<TElement> action);
        bool Exists(Predicate<TElement> match);
        void CheckExist(TKey key);
    }
}