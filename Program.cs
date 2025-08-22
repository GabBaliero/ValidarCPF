using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
public class Program
{
    private static string _cpf = "123.456.789-09";
    private static int[] _cpfFormatado;
    private static int _dv1;
    private static int _dv2;
    public static void Main()
    {
        (_dv1, _dv2) = Digitos(_cpf);
        Validar(_dv1, _dv2);
    }

    static int VerificarDigitos(string cpf, int VerificarDigito)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");
        int[] cpfArray = cpf.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray(); _cpfFormatado = cpfArray;
        var (index, peso, multiplo) = VerificarDigito == 1 ? (9, 10, 11) : (10, 11, 12);
        for (int i = 0; i < index; i++, --peso)
            cpfArray[i] *= peso;
        int sum = cpfArray.Take(index).Sum(c => int.Parse(c.ToString()));
        VerificarDigito = (sum % 11) < 2 ? 0 : (11 - sum % 11);
        bool areEqual = VerificarDigito.Equals(cpfArray[index]);
        return VerificarDigito;
    }
    static (int, int) Digitos(string cpf) => (VerificarDigitos(_cpf, 1), VerificarDigitos(_cpf, 2));

    static void Validar(int dv1, int dv2)
    {
        bool iguais = (dv1, dv2) == (_cpfFormatado[9], _cpfFormatado[10]);
        string output = iguais != false ? output = "CPF válido" : output = "CPF inválido";
        Console.WriteLine(output);
    }

}