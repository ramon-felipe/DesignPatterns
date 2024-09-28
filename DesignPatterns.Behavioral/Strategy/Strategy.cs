namespace DesignPatterns.Behavioral.Strategy;

public sealed class Orcamento
{
    public double Valor { get; private set; }
    public Orcamento(double valor)
    {
        this.Valor = valor;
    }
}

public sealed class CalculadorImpostos
{
    public double Calcula(Orcamento orcamento, IImposto imposto) => imposto.Calcula(orcamento);
}

public interface IImposto
{
    double Calcula(Orcamento orcamento);
}

public sealed class Icms : IImposto
{
    public double Calcula(Orcamento orcamento) => orcamento.Valor * 0.1;
}

public sealed class Iss : IImposto
{
    public double Calcula(Orcamento orcamento) => orcamento.Valor * 0.06;
}