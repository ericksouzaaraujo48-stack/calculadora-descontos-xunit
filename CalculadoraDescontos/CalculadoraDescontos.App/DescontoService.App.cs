namespace EcommerceCheckout;

public static class PedidoService
{
    /// <summary>
    /// BRONZE: menos de 5 compras | PRATA: de 5 a 10 (inclusive) | OURO: mais de 10.
    /// </summary>
    public static string ObterCategoriaCliente(int totalCompras)
    {
        if (totalCompras < 5)
            return "BRONZE";

        if (totalCompras <= 10)
            return "PRATA";

        return "OURO";
    }

    /// <summary>
    /// Retorna o valor final com o desconto aplicado (ex.: 100 com 10% => 90).
    /// </summary>
    public static int CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)
    {
        return valorOriginal * (100 - percentualDesconto) / 100;
    }

    /// <summary>
    /// Válido se o cliente tem 18 anos ou mais OU se for a primeira compra.
    /// </summary>
    public static bool EValidoParaCupom(int idade, bool primeiraCompra)
    {
        return idade >= 18 || primeiraCompra;
    }
}