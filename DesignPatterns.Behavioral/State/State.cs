using DesignPatterns.Behavioral.Strategy;

namespace DesignPatterns.Behavioral.State;

public interface IBudgetState
{
    Budget ApplyExtraDiscount(Budget orcamento);

    Budget Approve(Budget budget);
    Budget Disapprove(Budget budget);
    Budget Cancel(Budget budget);

}

public sealed class InitState : IBudgetState
{
    public Budget ApplyExtraDiscount(Budget orcamento)
    {
        return orcamento.ChangeValue(orcamento.Value - (orcamento.Value * 0.05));
    }

    public Budget Approve(Budget budget)
    {
        budget.Status = new ApprovedState();
        return budget;
    }

    public Budget Cancel(Budget budget)
    {
        budget.Status = new CancelledState();
        return budget;
    }

    public Budget Disapprove(Budget budget)
    {
        budget.Status = new DisapprovedState();
        return budget;
    }
}

public sealed class ApprovedState : IBudgetState
{
    public Budget ApplyExtraDiscount(Budget orcamento)
    {
        return orcamento.ChangeValue(orcamento.Value - (orcamento.Value * 0.02));
    }

    public Budget Approve(Budget budget)
    {
        throw new InvalidOperationException("budget alredy approved");
    }

    public Budget Cancel(Budget budget)
    {
        throw new InvalidOperationException("budget alredy approved");
    }

    public Budget Disapprove(Budget budget)
    {
        budget.Status = new DisapprovedState();
        return budget;
    }
}

public sealed class DisapprovedState : IBudgetState
{
    public Budget ApplyExtraDiscount(Budget orcamento)
    {
        throw new InvalidOperationException("Can't apply extra discount to a disapproved budget.");
    }

    public Budget Approve(Budget budget)
    {
        throw new InvalidOperationException("can't approve a disapproved budget.");
    }

    public Budget Cancel(Budget budget)
    {
        budget.Status = new CancelledState();
        return budget;
    }

    public Budget Disapprove(Budget budget)
    {
        throw new InvalidOperationException("budget alredy disapproved");
    }
}

public sealed class CancelledState : IBudgetState
{
    public Budget ApplyExtraDiscount(Budget orcamento)
    {
        throw new InvalidOperationException("Can't apply extra discount to a cancelled budget.");
    }

    public Budget Approve(Budget budget)
    {
        throw new InvalidOperationException("can't approve a cancelled budget.");
    }

    public Budget Cancel(Budget budget)
    {
        throw new InvalidOperationException("budget alredy cancelled");
    }

    public Budget Disapprove(Budget budget)
    {
        throw new InvalidOperationException("cat't disapprove a cancelled budget");
    }
}