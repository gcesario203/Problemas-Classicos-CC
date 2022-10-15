using Lib.Utils;

namespace Lib.Models
{
    public class Node<T> : IEquatable<Node<T>>
    {
        public Guid Id = Guid.NewGuid();
        public T State { get; set; }

        public Node<T> Parent { get; set; }

        private double Cost { get; set; }

        private double Heuristic { get; set; }

        public double Priority { get => Cost + Heuristic; }

        public Node(T state, Node<T> parent, double cost = 0.0f, double heuristic = 0.0f)
        {
            State = state;
            Parent = parent;
            Cost = cost;
            Heuristic = heuristic;
        }

        public bool Lt(Node<T> otherNode)
        => (Cost + Heuristic) < (otherNode.Cost + otherNode.Heuristic);

        public bool Equals(Node<T>? other)
        => Id == other.Id;

        public Node<T>? DeepFirstSearch(T initState, Delegate goalCheck, Delegate getSuccessors)
        {
            var frontier = new Stack<Node<T>>();

            var explored = new HashSet<T>();

            frontier.Push(new Node<T>(initState, null));

            while (frontier.Count != 0)
            {
                var currentNode = frontier.Pop();

                var currentState = currentNode.State;

                var isFinished = (bool)goalCheck.DynamicInvoke(currentState);

                if (isFinished)
                    return currentNode;

                var sucessors = (List<T>)getSuccessors.DynamicInvoke(currentState);

                foreach (var child in sucessors ?? new List<T>())
                {
                    if (explored.Any(x => (bool)x.GetType().GetMethods().FirstOrDefault(x => x.Name == "Equals").Invoke(x, new object[] { child })))
                        continue;

                    explored.Add(child);

                    frontier.Push(new Node<T>(child, currentNode));
                }
            }

            return null;
        }

        public Node<T>? BreadthFirstSearch(T initState, Delegate goalCheck, Delegate getSuccessors)
        {
            var frontier = new Queue<Node<T>>();

            var explored = new HashSet<T>();

            frontier.Enqueue(new Node<T>(initState, null));

            while (frontier.Count != 0)
            {
                var currentNode = frontier.Dequeue();

                var currentState = currentNode.State;

                var isFinished = (bool)goalCheck.DynamicInvoke(currentState);

                if (isFinished)
                    return currentNode;

                var sucessors = (List<T>)getSuccessors.DynamicInvoke(currentState);

                foreach (var child in sucessors ?? new List<T>())
                {
                    if (explored.Any(x => (bool)x.GetType().GetMethods().FirstOrDefault(x => x.Name == "Equals").Invoke(x, new object[] { child })))
                        continue;

                    explored.Add(child);

                    frontier.Enqueue(new Node<T>(child, currentNode));
                }
            }

            return null;
        }

        public Node<T>? AStar(T initState, T finalState, Delegate goalCheck, Delegate getSuccessors, Delegate getHeuristic)
        {
            var frontier = new List<Node<T>>();

            frontier.Add(new Node<T>(initState, null, 0.0f, (double)getHeuristic.DynamicInvoke(initState, finalState)));

            var explored = new Dictionary<T, double>();

            explored.Add(initState, 0.0f);

            while (frontier.Count != 0)
            {
                var currentNode = frontier.PushItemByFunction(x => x.Priority == frontier.Max(w => w.Priority));

                if (currentNode == null)
                    continue;

                var currentState = currentNode.State;

                if ((bool)goalCheck.DynamicInvoke(currentState))
                    return currentNode;

                var sucessors = (List<T>)getSuccessors.DynamicInvoke(currentState);

                foreach (var child in sucessors ?? new List<T>())
                {
                    var newCost = currentNode.Cost + 1;
                    Func<KeyValuePair<T, double>, bool> predicate = x => (bool)x.Key.GetType().GetMethods().FirstOrDefault(x => x.Name == "Equals").Invoke(x.Key, new object[] { child });
                    
                    if (explored.Any(predicate) || explored.FirstOrDefault(predicate).Value > newCost)
                        continue;

                    explored.Add(child, newCost);

                    frontier.AddAndOrderByFunction(new Node<T>(child, currentNode, newCost, (double)getHeuristic.DynamicInvoke(child, finalState)), x=> x.Priority);
                }
            }

            return null;
        }

        public List<T> NodeToPath(Node<T> node)
        {
            var path = new List<T> { node.State };

            while (node.Parent != null)
            {
                node = node.Parent;
                path.Add(node.State);
            }

            path.Reverse();

            return path;
        }
    }
}