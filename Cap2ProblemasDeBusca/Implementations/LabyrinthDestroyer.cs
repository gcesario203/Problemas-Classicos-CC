using Cap2ProblemasDeBusca.Models;

namespace Cap2ProblemasDeBusca.Implementations
{
    public static class LabyrinthDestroyer
    {
        public static void Init()
        {
            var _maze = new Maze(null, null);

            System.Console.WriteLine(_maze.ToString());     
        }
    }
}