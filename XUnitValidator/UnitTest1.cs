using System;
using Xunit;

namespace XUnitValidator
{
    public class UnitTest1
    {
        string cpf = "01226299652";

        [Fact]
        public void IsCPFHas11Digits()
        {
            Assert.Equal(11, cpf.Length);
        }

        [Fact]
        public void IsCPFValid()
        {
            Assert.True(IsValid(cpf),"O CPF informado � inv�lido.");
        }

        [Fact]
        public void IsAlphanumericCPFValid()
        {
            string cpf;
            cpf = "012.262.996-52";

            // Caso coloque todos os numeros iguais
            int[] multiplicator1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicator2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int addedValue;
            int leftOver;
            //string cpf = value;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                Assert.True(false);

            tempCpf = cpf.Substring(0, 9);
            addedValue = 0;

            for (int i = 0; i < 9; i++)
                addedValue += int.Parse(tempCpf[i].ToString()) * multiplicator1[i];

            leftOver = addedValue % 11;

            if (leftOver < 2)
                leftOver = 0;
            else
                leftOver = 11 - leftOver;

            digit = leftOver.ToString();
            tempCpf = tempCpf + digit;
            addedValue = 0;

            for (int i = 0; i < 10; i++)
                addedValue += int.Parse(tempCpf[i].ToString()) * multiplicator2[i];

            leftOver = addedValue % 11;

            if (leftOver < 2)
                leftOver = 0;
            else
                leftOver = 11 - leftOver;

            digit = digit + leftOver.ToString();

            Assert.True(cpf.EndsWith(digit), "O CPF informado � inv�lido.");
        }

        public bool IsValid(string value)
        {
            // Caso coloque todos os numeros iguais
            int[] multiplicator1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicator2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int addedValue;
            int leftOver;
            string cpf = value;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            addedValue = 0;

            for (int i = 0; i < 9; i++)
                addedValue += int.Parse(tempCpf[i].ToString()) * multiplicator1[i];

            leftOver = addedValue % 11;

            if (leftOver < 2)
                leftOver = 0;
            else
                leftOver = 11 - leftOver;

            digit = leftOver.ToString();
            tempCpf = tempCpf + digit;
            addedValue = 0;

            for (int i = 0; i < 10; i++)
                addedValue += int.Parse(tempCpf[i].ToString()) * multiplicator2[i];

            leftOver = addedValue % 11;

            if (leftOver < 2)
                leftOver = 0;
            else
                leftOver = 11 - leftOver;

            digit = digit + leftOver.ToString();
            return cpf.EndsWith(digit);



        }

    }

}
