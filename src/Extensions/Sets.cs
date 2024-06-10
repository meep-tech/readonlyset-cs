namespace Meep.Tech.Collections {

  /// <summary>
  /// Read-only Extensions for ISet.
  /// </summary>
  public static class ReadOnlySetSetExtensions {

    /// <summary>
    /// Returns a read-only wrapper for the given set.
    /// </summary>
    public static ReadOnlySet<T> AsReadOnly<T>(this ISet<T> set)
      => new(set);
  }
}