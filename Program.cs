using System;
using System.Collections.Generic;
public class Program
{
    private static string _cpf = "123.456.789-09";
    private static int _dv1;
    private static int _dv2;
    public static void Main()
    {
        (_dv1, _dv2) = Digitos(_cpf);
    }

    static int VerificarDigitos(string cpf, int VerificarDigito)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");
        int[] cpfArray = cpf.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
        var index = VerificarDigito == 1 ? 9 : 10;
        var multiplo = VerificarDigito == 1 ? 11 : 12;
        for (int i = 0; i < index; i++)
        {
            cpfArray[i] *= (multiplo - cpfArray[i]);
        }
        int sum = cpfArray.Take(9).Sum(c => int.Parse(c.ToString()));
        VerificarDigito = (sum % 11) < 2 ? 0 : (11 - sum % 11);
        return VerificarDigito;
    }
    static (int, int) Digitos(string cpf) => (VerificarDigitos(_cpf, 1), VerificarDigitos(_cpf, 2));

}