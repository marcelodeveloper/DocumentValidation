using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Document
{
    public class PIS : IValidation
    {
        public bool IsValid(string value)
        {
            int[] multiplicator = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int _sum;
            int leftOver;
            if (value.Trim().Length != 11)
                return false;
            value = value.Trim();
            value = value.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            _sum = 0;
            for (int i = 0; i < 10; i++)
                _sum += int.Parse(value[i].ToString()) * multiplicator[i];
            leftOver = _sum % 11;
            if (leftOver < 2)
                leftOver = 0;
            else
                leftOver = 11 - leftOver;
            return value.EndsWith(leftOver.ToString());
        }
    }
}
