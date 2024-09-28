using DesignPatterns.Behavioral.State;

namespace DesignPatterns.Behavioral.Strategy;

public sealed class Budget
{
    public double Value { get; private set; }
    public IBudgetState Status { get; set; } = new InitState();

    public Budget(double valor)
    {
        this.Value = valor;
    }

    public Budget ChangeValue(double valor)
    {
        this.Value = valor;

        return this;
    }

    public Budget ApplyExtraDiscount()
    {
        return this.Status.ApplyExtraDiscount(this);
    }

    public Budget Approve()
    {
        return this.Status.Approve(this);
    }

    public Budget Disapprove()
    {
        return this.Status.Disapprove(this);
    }

    public Budget Cancel()
    {
        return this.Status.Cancel(this);
    }
}

public sealed class TaxCalculator
{
    public double Calculate(Budget orcamento, ITax imposto) => imposto.Calculate(orcamento);
}

public interface ITax
{
    double Calculate(Budget orcamento);
}

public sealed class Icms : ITax
{
    public double Calculate(Budget orcamento) => orcamento.Value * 0.1;
}

public sealed class Iss : ITax
{
    public double Calculate(Budget orcamento) => orcamento.Value * 0.06;
}