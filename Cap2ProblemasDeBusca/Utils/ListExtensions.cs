namespace Cap2ProblemasDeBusca.Utils
{
    public static class ListExtensions
    {
        public static void AddAndOrderByFunction<T>(this List<T> value, T itemToAdd, Func<T, object> func)
        {
            value.Add(itemToAdd);

            value.OrderBy(func);
        }

        public static T? PushItemByFunction<T>(this List<T> value, Func<T, bool> func)
        {
            var itemToReturn = value.FirstOrDefault(func);

            if (itemToReturn != null)
                value.Remove(itemToReturn);

            return itemToReturn;
        }
    }
}