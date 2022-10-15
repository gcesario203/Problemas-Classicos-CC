using Cap2ProblemasDeBusca.Models;
using Lib.Models;

namespace Cap2ProblemasDeBusca.Implementations
{
    public static class LabyrinthDestroyer
    {
        public static void Init()
        {
            var _maze = new Maze(null, null);

            System.Console.WriteLine(_maze.ToString());

            var parentNode = new Node<LabyrinthLocation>(_maze.Start, null);

            var solutionOne = parentNode.DeepFirstSearch(_maze.Start, _maze.GotToTheGoal,_maze.GetSuccessors);


            if(solutionOne == null)
                System.Console.WriteLine("Sem soluções");
            else
            {
                var pathOne = parentNode.NodeToPath(solutionOne);

                _maze.Mark(pathOne);

                System.Console.WriteLine(_maze.ToString());

                System.Console.WriteLine($"DFS levou {pathOne.Count} passos para ser concluido");

                _maze.Clear(pathOne);
            }

            var solutionTwo = parentNode.BreadthFirstSearch(_maze.Start, _maze.GotToTheGoal,_maze.GetSuccessors);
            if(solutionTwo == null)
                System.Console.WriteLine("Sem soluções");
            else
            {
                var pathOne = parentNode.NodeToPath(solutionTwo);

                _maze.Mark(pathOne);

                System.Console.WriteLine(_maze.ToString());

                System.Console.WriteLine($"BFS levou {pathOne.Count} passos para ser concluido");

                _maze.Clear(pathOne);
            }

            var solutionThree = parentNode.AStar(_maze.Start, _maze.Goal, _maze.GotToTheGoal,_maze.GetSuccessors, _maze.ManhattanDistance);
            if(solutionThree == null)
                System.Console.WriteLine("Sem soluções");
            else
            {
                var pathOne = parentNode.NodeToPath(solutionThree);

                _maze.Mark(pathOne);

                System.Console.WriteLine(_maze.ToString());

                System.Console.WriteLine($"A* levou {pathOne.Count} passos para ser concluido");

                _maze.Clear(pathOne);
            }
        }

        public static void InitBfs()
        {
            var _maze = new Maze(null, null);

            System.Console.WriteLine(_maze.ToString());

            var parentNode = new Node<LabyrinthLocation>(_maze.Start, null);

            var solutionOne = parentNode.BreadthFirstSearch(_maze.Start, _maze.GotToTheGoal,_maze.GetSuccessors);

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