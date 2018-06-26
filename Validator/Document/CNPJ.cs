using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Document
{
    public class CNPJ : IValidation
    {
        public bool IsValid(string value)
        {
            string CNPJ = value.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");
            int[] digits, _sum, result;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;
            ftmt = "6543298765432";
            digits = new int[14];
            _sum = new int[2];
            _sum[0] = 0;
            _sum[1] = 0;
            result = new int[2];
            result[0] = 0;
            result[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {

                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digits[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        _sum[0] += (digits[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    if (nrDig <= 12)
                        _sum[1] += (digits[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    result[nrDig] = (_sum[nrDig] % 11);
                    if ((result[nrDig] == 0) || (result[nrDig] == 1))
                        CNPJOk[nrDig] = (digits[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (digits[12 + nrDig] == (11 - result[nrDig]));
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }
    }
}
