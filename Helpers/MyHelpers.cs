namespace RingOfFire.Helpers;
static class MyHelpers
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
    }

    public static void Shuffle<T>(this Stack<T> stack)
    {
        List<T> list = [.. stack];
        list.Shuffle();
        
        stack = new Stack<T>(list);
    }
}

public static class ThreadSafeRandom
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [ThreadStatic] private static Random Local;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public static Random ThisThreadsRandom
    {
        get { return Local ??= new Random(unchecked(Environment.TickCount * 31 + Environment.CurrentManagedThreadId)); }
    }
}
