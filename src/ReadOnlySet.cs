using System.Collections;

namespace Meep.Tech.Collections {

  /// <summary>
  /// A read-only wrapper for an existing ISet.
  /// </summary>
  public class ReadOnlySet<T>(ISet<T> source)
    : IReadOnlySet<T> {

    /// <inheritdoc />
    public int Count
      => source.Count;

    /// <inheritdoc />
    public bool Contains(T item)
      => source.Contains(item);

    /// <inheritdoc />
    public bool IsProperSubsetOf(IEnumerable<T> other)
      => source.IsProperSubsetOf(other);

    /// <inheritdoc />
    public bool IsProperSupersetOf(IEnumerable<T> other)
      => source.IsProperSupersetOf(other);

    /// <inheritdoc />
    public bool IsSubsetOf(IEnumerable<T> other)
      => source.IsSubsetOf(other);

    /// <inheritdoc />
    public bool IsSupersetOf(IEnumerable<T> other)
      => source.IsSupersetOf(other);

    /// <inheritdoc />
    public bool Overlaps(IEnumerable<T> other)
      => source.Overlaps(other);

    /// <inheritdoc />
    public bool SetEquals(IEnumerable<T> other)
      => source.SetEquals(other);

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
      => source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
      => GetEnumerator();
  }
}