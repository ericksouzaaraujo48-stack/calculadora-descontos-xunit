# CalculadoraDescontos

Biblioteca em C#/.NET com regras de **categoria de cliente**, **cálculo de desconto** e **elegibilidade para cupom**, coberta por testes parametrizados com xUnit (`[Theory]` + `[InlineData]`).

## Estrutura do projeto

```
CalculadoraDescontos/
├── CalculadoraDescontos/             # Projeto principal (regras de negócio)
│   └── DescontoService.cs
└── CalculadoraDescontos.Tests/       # Projeto de testes (xUnit)
    └── DescontoServiceTests.cs
```

## Regras de negócio

### 1. `string ObterCategoriaCliente(int totalCompras)`

Classifica o cliente de acordo com o total de compras.

| Total de compras      | Categoria  |
|-----------------------|------------|
| Menos de 5            | `"BRONZE"` |
| De 5 a 10 (inclusive) | `"PRATA"`  |
| Mais de 10            | `"OURO"`   |

### 2. `int CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)`

Retorna o valor final com o desconto aplicado.

| Valor original | Desconto | Valor final |
|----------------|----------|-------------|
| `100`          | `10%`    | `90`        |
| `200`          | `20%`    | `160`       |
| `50`           | `0%`     | `50`        |

> O cálculo usa inteiros (`valorOriginal * (100 - percentual) / 100`), portanto o resultado é truncado. Para trabalhar com centavos, utilize `decimal`.

### 3. `bool EValidoParaCupom(int idade, bool primeiraCompra)`

O cupom é válido se o cliente tiver **18 anos ou mais** **OU** se for a **primeira compra**.

| Idade | Primeira compra | Resultado |
|-------|-----------------|-----------|
| `20`  | `false`         | `true`    |
| `16`  | `true`          | `true`    |
| `17`  | `false`         | `false`   |

## Testes

Os testes ficam em `CalculadoraDescontos.Tests`, na classe `DescontoServiceTests`. Em vez de duplicar métodos para cada cenário, cada regra usa um único `[Theory]` com vários `[InlineData]`:

| Método testado                  | Casos de teste |
|---------------------------------|----------------|
| `ObterCategoriaCliente`         | `(2, "BRONZE")`, `(7, "PRATA")`, `(15, "OURO")` |
| `CalcularDescontoPorPercentual` | `(100, 10, 90)`, `(200, 20, 160)`, `(50, 0, 50)` |
| `EValidoParaCupom`              | `(20, false, true)`, `(16, true, true)`, `(17, false, false)` |

Total: **9 casos de teste** (3 por método).

## Como executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado (verifique com `dotnet --version`)

### Rodando a suíte de testes

Na raiz da solução:

```bash
dotnet test
```

Saída esperada: todos os testes aprovados (`Passed!`).

## Exemplo de uso

```csharp
using CalculadoraDescontos;

string categoria = DescontoService.ObterCategoriaCliente(7);              // "PRATA"
int valorFinal   = DescontoService.CalcularDescontoPorPercentual(100, 10); // 90
bool podeCupom   = DescontoService.EValidoParaCupom(17, false);            // false
```

## Tecnologias

- C# / .NET
- xUnit
