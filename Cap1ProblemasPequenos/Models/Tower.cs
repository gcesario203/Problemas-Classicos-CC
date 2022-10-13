namespace Cap1ProblemasPequenos.Models
{
    public class Tower
    {
        public string Name { get; set; }

        public Stack<int> Discs { get; set; } = new Stack<int>();

        public int TotalDiscs { get => Discs.Count; }


        public Tower(string name)
        {
            Name = name;
        }
    }
}