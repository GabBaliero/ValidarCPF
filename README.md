# Validador de CPF em C#

Este projeto é um programa simples em C# para validar um número de CPF com base no cálculo dos dígitos verificadores (mod 11).

## Funcionalidade
O algoritmo:
1. Recebe um CPF informado no formato `123.456.789-09`.
2. Valida a entrada e trata exceções de erro (entradas inválidas, formatação incorreta, etc.).
3. Calcula os dígitos verificadores usando o algoritmo de módulo 11 e compara com os do CPF informado.
4. Retorna se o CPF é **válido** ou **inválido**.

## Como executar

1. **Clone este repositório**:
   ```bash
   git clone https://github.com/GabBaliero/validar-cpf.git
   ```
   
2. **Em seu editor ou IDE Compile e Execute**:
   ```bash
   dotnet run
   ```

## Requisitos
.NET SDK instalado.



   
