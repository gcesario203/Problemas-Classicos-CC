namespace Cap2ProblemasDeBusca.Models
{
    public class Node<T> : IEquatable<Node<T>>
    {
        public Guid Id = Guid.NewGuid();
        public T State { get; set; }

        public Node<T> Parent {get;set;}

        public float Cost {get;set;}

        public float Heuristic {get;set;}

        public HashSet<T> Explored {get;set;} = new HashSet<T>();

        public Node(T state, Node<T> parent, float cost = 0.0f, float heuristic = 0.0f)
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

        public Node<T>? Dfs(T initState, Delegate goalCheck, Delegate getSuccessors)
        {
            var frontier = new Stack<Node<T>>();

            frontier.Push(new Node<T>(initState, null));

            while(frontier.Count != 0)
            {
                var currentNode = frontier.Pop();

                var currentState = currentNode.State;

                var isFinished = (bool)goalCheck.DynamicInvoke(currentState);

                if(isFinished)
                    return currentNode;

                var sucessors = (List<T>)getSuccessors.DynamicInvoke(currentState);

                foreach(var child in sucessors ?? new List<T>())
                {
                    if(Explored.Any(x => (bool)x.GetType().GetMethod("Compare").Invoke(x, new object[] { child })))
                        continue;

                    Explored.Add(child);

                    frontier.Push(new Node<T>(child, currentNode));
                }
            }

            return null;
        }

        public List<T> NodeToPath(Node<T> node)
        {
            var path = new List<T>{ node.State };

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