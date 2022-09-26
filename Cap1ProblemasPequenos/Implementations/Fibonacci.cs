namespace Cap1ProblemasPequenos.Implementations
{
    public class Fibonacci
    {
        public Dictionary<int, int> CachedSequentialItens { get; private set; }
        public Fibonacci()
        {
            CachedSequentialItens = new Dictionary<int, int>();

            CachedSequentialItens.Add(0, 0);
            CachedSequentialItens.Add(1, 1);
        }
        public int HandleFibonacciSequenceRecursive(int position)
        {
            if (!CachedSequentialItens.Keys.Contains(position))
                CachedSequentialItens[position] = HandleFibonacciSequenceRecursive(position - 1) + HandleFibonacciSequenceRecursive(position - 2);

            return CachedSequentialItens[position];
        }

        public IEnumerable<int> HandleFibonacciSequenceIterative(int position)
        {
            yield return 0;

            if (position >  0)
                yield return 1;

            int last = 0, next = 1, aux;

            for (var i = 1; i < position; i++)
            {
                aux = last;
                last = next;
                next = last + aux;

                yield return next;
            }
        }
    }
}