using Cap2ProblemasDeBusca.Models;

namespace Cap2ProblemasDeBusca.Implementations
{
    public static class LabyrinthDestroyer
    {
        public static void Init()
        {
            var _maze = new Maze(null, null);

            System.Console.WriteLine(_maze.ToString());

            var parentNode = new Node<LabyrinthLocation>(_maze.Start, null);

            var solutionOne = parentNode.Dfs(_maze.Start, _maze.GotToTheGoal,_maze.GetSuccessors);

            if(solutionOne == null)
                System.Console.WriteLine("Sem soluções");
            else
            {
                var pathOne = parentNode.NodeToPath(solutionOne);

                _maze.Mark(pathOne);

                System.Console.WriteLine(_maze.ToString());

                _maze.Clear(pathOne);
            }
        }
    }
}