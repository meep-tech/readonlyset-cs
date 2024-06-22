using System.Collections;

namespace Meep.Tech.Collections {

  /// <summary>
  /// A read-only wrapper for an existing ISet. 
  /// </summary>
  public interface IReadOnlySet
    : ICollection {

    /// <inheritdoc cref="ICollection{T}.Contains(T)" />
    bool Contains(object item);

    /// <inheritdoc cref="ISet{T}.IsProperSubsetOf(IEnumerable{T})" />
    bool IsProperSubsetOf(IEnumerable other);

    /// <inheritdoc cref="ISet{T}.IsProperSupersetOf(IEnumerable{T})" />
    bool IsProperSupersetOf(IEnumerable other);

    /// <inheritdoc cref="ISet{T}.IsSubsetOf(IEnumerable{T})" />
    bool IsSubsetOf(IEnumerable other);

    /// <inheritdoc cref="ISet{T}.IsSupersetOf(IEnumerable{T})" />
    bool IsSupersetOf(IEnumerable other);

    /// <inheritdoc cref="ISet{T}.Overlaps(IEnumerable{T})" />
    bool Overlaps(IEnumerable other);

    /// <inheritdoc cref="ISet{T}.SetEquals(IEnumerable{T})" />
    bool SetEquals(IEnumerable other);
  }
}