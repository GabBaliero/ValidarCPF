using System;
using System.Collections.Generic;
public class Program
{
    private static string _cpf = "123.456.789-09";
    private static int _dv1;
    private static int _dv2;
    public static void Main()
    {
        ConverterParaArray(_cpf);
    }

    static void ConverterParaArray(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");
        int[] cpfArray = cpf.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
        for (int i = 0; i < 9; i++)
        {
            cpfArray[i] *= (11 - cpfArray[i]);
        }
        int sum = cpfArray.Take(9).Sum(c => int.Parse(c.ToString()));
        _dv1 = (sum % 11) < 2 ? 0 : (11 - sum % 11);
    }
}