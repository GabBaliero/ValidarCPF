using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
public class Program
{
    private static string _cpf = "123.456.789-09";
    private static int[] _cpfFormatado = { };
    public static void Main()
    {
        try
        {
            _cpf = VerificarCpf(_cpf);
            var (_dv1, _dv2) = Digitos(_cpf);
            Validar(_dv1, _dv2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static int VerificarDigitos(string cpf, int VerificarDigito)
    {
        int[] cpfArray = cpf.Select(x => (int)char.GetNumericValue(x)).ToArray(); _cpfFormatado = cpfArray.ToArray();
        var (index, peso, multiplo) = VerificarDigito == 1 ? (9, 10, 11) : (10, 11, 12);
        for (int i = 0; i < index; i++, --peso)
            cpfArray[i] *= peso;
        int sum = cpfArray.Take(index).Sum(c => int.Parse(c.ToString()));
        VerificarDigito = (sum % 11) < 2 ? 0 : (11 - sum % 11);
        return VerificarDigito;
    }
    static (int, int) Digitos(string cpf) => (VerificarDigitos(_cpf, 1), VerificarDigitos(_cpf, 2));
    static void Validar(int dv1, int dv2) => Console.WriteLine((dv1, dv2) == (_cpfFormatado[9], _cpfFormatado[10]) ? "CPF válido!" : "CPF inválido!");
    static string VerificarCpf(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "").Trim();
        if (cpf.All(c => c == cpf[0]) && cpf.Length != 11) return string.Empty;       
        if (Regex.IsMatch(cpf, @"0{5,}") && Regex.IsMatch(cpf, @"[a-zA-Z]")) return string.Empty;     
        return cpf;
    }
}