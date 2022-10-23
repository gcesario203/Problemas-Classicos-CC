using Lib.Contracts;

namespace Lib.Implementations
{
    public class CSP<TVariable, TDomain>
    {
        public List<TVariable> Variables { get; set; }

        public Dictionary<TVariable, List<TDomain>> Domains { get; set; }

        public Dictionary<TVariable, List<IConstraint<TVariable, TDomain>>> Constraints { get; set; }

        public CSP(List<TVariable> variables, Dictionary<TVariable, List<TDomain>> domains)
        {
            Variables = variables;
            Domains = domains;
            Constraints = new Dictionary<TVariable, List<IConstraint<TVariable, TDomain>>>();

            foreach (var variable in Variables)
            {
                Constraints.Add(variable, new List<IConstraint<TVariable, TDomain>>());

                if (!Domains.Keys.Contains(variable))
                    throw new Exception("Toda variavel deve ter um domínio declarado!");
            }
        }

        public void AddConstraint(IConstraint<TVariable, TDomain> constraint)
        {
            foreach (var variable in constraint.Variables)
            {
                if (!Variables.Contains(variable))
                    throw new Exception("Variavel sem restrição cadastrada!");
                else
                {
                    if (Constraints.Keys.Contains(variable))
                        Constraints[variable].Add(constraint);
                    else
                        Constraints.Add(variable, new List<IConstraint<TVariable, TDomain>> { constraint });
                }
            }
        }

        public bool Consistent(TVariable variable, Dictionary<TVariable, TDomain> domain)
        {
            if (!Constraints.Keys.Contains(variable))
                return false;

            foreach (var constraint in Constraints[variable])
            {
                if (!constraint.Satisfied(domain))
                    return false;
            }

            return true;
        }

        public Dictionary<TVariable, TDomain>? BackTrackingSearch(Dictionary<TVariable, TDomain> assignment)
        {
            if (assignment == null)
                assignment = new Dictionary<TVariable, TDomain>();

            if (assignment.Count == Variables.Count)
                return assignment;

            var firstUnassigned = Variables.Where(x => !assignment.Keys.Contains(x)).FirstOrDefault();

            if (firstUnassigned == null)
                return null;

            foreach (var domain in Domains[firstUnassigned])
            {
                var localAssignment = new Dictionary<TVariable, TDomain>(assignment);

                localAssignment.Add(firstUnassigned, domain);

                if (!Consistent(firstUnassigned, localAssignment))
                    continue;

                var result = BackTrackingSearch(localAssignment);

                if (result == null)
                    continue;

                return result;
            }

            return null;
        }
    }
}