using System.Collections;
using System.Runtime.CompilerServices;

namespace Meep.Tech.Collections {

  /// <summary>
  /// A non-generic read-only wrapper for an existing ISet.
  /// </summary> 
  public class ReadOnlySet(IEnumerable source)
    : IReadOnlySet {
    private Lazy<ISet<object>> _source
      = new(() => source is ISet<object> set
        ? set
        : new HashSet<object>(source.Cast<object>()));

    /// <inheritdoc />
    public virtual int Count
      => _source.Value.Count;

    /// <inheritdoc />
    public bool IsSynchronized
      => true;

    /// <inheritdoc />
    object ICollection.SyncRoot
      => _syncRoot;

    /// <inheritdoc />
    internal virtual object _syncRoot
      => source;

    /// <summary>
    /// Create a new <see cref="ReadOnlySet{T}"/> from values instead of an existing <see cref="ISet{T}"/>.
    /// </summary>
    internal ReadOnlySet()
      : this(null!) { }

    /// <summary>
    /// Create a new <see cref="ReadOnlySet{T}"/> from values instead of an existing <see cref="ISet{T}"/>.
    /// </summary>
    public ReadOnlySet(params object[] values)
      : this(new HashSet<object>([.. values])) { }

    /// <inheritdoc />
    public virtual bool Contains(object item)
      => _source.Value.Contains(item);

    /// <inheritdoc />
    public virtual bool IsProperSubsetOf(IEnumerable other)
      => _source.Value.IsProperSubsetOf(other is IEnumerable<object> objs ? objs : other.Cast<object>());

    /// <inheritdoc />
    public virtual bool IsProperSupersetOf(IEnumerable other)
      => _source.Value.IsProperSupersetOf(other is IEnumerable<object> objs ? objs : other.Cast<object>());

    /// <inheritdoc />
    public virtual bool IsSubsetOf(IEnumerable other)
      => _source.Value.IsSubsetOf(other is IEnumerable<object> objs ? objs : other.Cast<object>());

    /// <inheritdoc />
    public virtual bool IsSupersetOf(IEnumerable other)
      => _source.Value.IsSupersetOf(other is IEnumerable<object> objs ? objs : other.Cast<object>());

    /// <inheritdoc />
    public virtual bool Overlaps(IEnumerable other)
      => _source.Value.Overlaps(other is IEnumerable<object> objs ? objs : other.Cast<object>());

    /// <inheritdoc />
    public virtual bool SetEquals(IEnumerable other)
      => _source.Value.SetEquals(other is IEnumerable<object> objs ? objs : other.Cast<object>());

    /// <inheritdoc />
    public virtual void CopyTo(Array array, int index)
      => _source.Value.CopyTo(array.Cast<object>().ToArray(), index);

    /// <inheritdoc />
    public virtual IEnumerator GetEnumerator()
      => _source.Value.GetEnumerator();

    #region Collection Builder

    internal static class _Builder {
      /// <summary>
      ///  Creates a new <see cref="ReadOnlySet{T}"/> from the provided <paramref name="source"/>.
      /// </summary>
      public static ReadOnlySet Build(ReadOnlySpan<object> source)
        => new(source.ToArray());

      /// <summary>
      ///  Creates a new <see cref="ReadOnlySet{T}"/> from the provided <paramref name="source"/>.
      /// </summary>
      public static ReadOnlySet<T> Build<T>(ReadOnlySpan<T> source)
        => new([.. source]);
    }

    #endregion
  }

  /// <summary>
  /// A read-only wrapper for an existing ISet.
  /// </summary>
  [CollectionBuilder(typeof(ReadOnlySet._Builder), nameof(ReadOnlySet._Builder.Build))]
  public class ReadOnlySet<T>(ISet<T> source)
    : IReadOnlySet<T> {

    /// <inheritdoc />
    public int Count
      => source.Count;

    /// <summary>
    /// Create a new <see cref="ReadOnlySet{T}"/> from values instead of an existing <see cref="ISet{T}"/>.
    /// </summary>
    public ReadOnlySet(params T[] values)
      : this(new HashSet<T>(values)) { }

    #region IReadOnlySet<T> Implementation

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

    #endregion

    #region IEnumerable<T> Implementation

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
      => source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
      => GetEnumerator();

    #endregion
  }
}