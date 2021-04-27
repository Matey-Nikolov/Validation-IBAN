namespace IBAN
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            // BG80BNBG96611020345678

            string IBAN = Console.ReadLine();

            // string IBAN = "BG80BNBG96611020345678";

            if (ValidationIBAN(IBAN))
            {
                string newIBAN =  ReturnIBANNew(IBAN);
                string stringDigit = StrIntToString(newIBAN);

                if (mod(stringDigit, 97) == 1)
                    Console.WriteLine("Valid IBAN.");
                else
                    Console.WriteLine("Invalid IBAN.");
            }
            
        }

        public static bool ValidationIBAN(string IBAN)
        {
            /*
            if (IBAN.Length != 22)
            {
                return false;
            }
            else if (IBAN[0].ToString() != "B" && IBAN[1].ToString() != "G")
            {
                return false;
            }
            */

            Regex rg = new Regex(@"^BG[0-9A-Z]{20}$");
            bool a = rg.IsMatch(IBAN);

            return a;
        }

        public static string ReturnIBANNew(string oldIBAN)
        {
           // string substring = "";
            
            string newIBAN = "";
            /*
            substring = oldIBAN.Substring(0, 4);
            oldIBAN = oldIBAN.Remove(0, 4);
            newIBAN = oldIBAN.Insert(18, substring); // От 22 стават на 18 символа. След това пак стават на 22 символа.
            */

            newIBAN = oldIBAN.Substring(4) + oldIBAN.Substring(0, 4);
            
            return newIBAN;
        }

        public static string StrIntToString(string IBAN)
        {
            StringBuilder sbIBAN = new StringBuilder();

            foreach (char ch in IBAN)
            {
                if (char.IsDigit(ch))
                    sbIBAN.Append(ch);
                else
                    sbIBAN.Append(ch - 'A' + 10);
            }

            return sbIBAN.ToString();
        }

        public static int mod(String num, int a)
        {
            // Initialize result
            int res = 0;

            // One by one process all
            // digits of 'num'
            for (int i = 0; i < num.Length; i++)
                res = (res * 10 + (int)num[i] - '0') % a;

            return res;
        }
    }
}
