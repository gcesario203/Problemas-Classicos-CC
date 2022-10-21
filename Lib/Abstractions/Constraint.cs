using Lib.Contracts;

namespace Lib.Abstractions
{
    public abstract class Constraint<TVariable, TDomain> : IConstraint<TVariable, TDomain>
    {
        public List<TVariable> Variables { get; set; }

        public Constraint(List<TVariable> variables)
        {
            Variables = variables;
        }

        public abstract bool Satisfied(Dictionary<TVariable, TDomain> assignment);
    }
}