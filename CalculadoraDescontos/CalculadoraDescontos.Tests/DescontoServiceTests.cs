using CalculadoraDescontos;
using EcommerceCheckout;
using Xunit;

namespace CalculadoraDescontos.Tests;

public class DescontoServiceTests
{
    [Theory]
    [InlineData(2, "BRONZE")]
    [InlineData(7, "PRATA")]
    [InlineData(15, "OURO")]
    public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(int totalCompras, string esperado)
    {
        var resultado = PedidoService.ObterCategoriaCliente(totalCompras);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(100, 10, 90)]
    [InlineData(200, 20, 160)]
    [InlineData(50, 0, 50)]
    public void CalcularDescontoPorPercentual_DeveRetornarValorFinal(int valorOriginal, int percentual, int esperado)
    {
        var resultado = PedidoService.CalcularDescontoPorPercentual(valorOriginal, percentual);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(20, false, true)]   // Maior de idade, não primeira compra -> true
    [InlineData(16, true, true)]    // Menor de idade, primeira compra -> true
    [InlineData(17, false, false)]  // Menor de idade, não primeira compra -> false
    public void EValidoParaCupom_DeveValidarElegibilidade(int idade, bool primeiraCompra, bool esperado)
    {
        var resultado = PedidoService.EValidoParaCupom(idade, primeiraCompra);

        Assert.Equal(esperado, resultado);
    }
}
