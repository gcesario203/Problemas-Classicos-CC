namespace Lib.Contracts
{
    public interface IConstraint<TVariable, TDomain>
    {
        public List<TVariable> Variables { get; set; }
        public bool Satisfied(Dictionary<TVariable, TDomain> assignment);
    }
}