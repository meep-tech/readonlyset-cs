namespace Meep.Tech.Collections
{
  public static class SetExtensions
  {
    public static ReadOnlySet<T> AsReadOnly<T>(this ISet<T> set)
      => new(set);
  }
}