using System;

namespace CreditCardChecker
{
    public class CreditCardChecker
    {
        /// <summary>
        /// Diese Methode überprüft eine Kreditkartenummer, ob diese gültig ist.
        /// Regeln entsprechend der Angabe.
        /// </summary>
        public static bool IsCreditCardValid(string creditCardNumber)
        {
            bool result = true;
            for (int i = 0; i < creditCardNumber.Length; i++)
			   {
               result = char.IsDigit(creditCardNumber[i]);
               if(!result)
               {
                  Console.WriteLine($"Zeichen an die Stelle {i} ist keine Ziffer", i+1);
               }
			   } 
            int oddsum = 0, evensum = 0, checksum, counter = 0;
            if(result)
            {
               for (int i = 0; i < creditCardNumber.Length - 1; i++)
			      {
                  if(i % 2 == 0)
                  {
                     evensum += CalculateDigitSum(creditCardNumber[i] - '0' * 2);
                  }
                  else
                  {
                     oddsum += CalculateDigitSum(creditCardNumber[i] - '0');
                  }
			      }
               checksum = CalculateCheckDigit(oddsum, evensum);

               while(checksum  % 10 > 0)
               {
                  checksum++;
                  counter++;
               }
               result = counter == creditCardNumber[creditCardNumber.Length - 1] - '0';
            }
            else
            {
               Console.WriteLine("Falsche Eingabe");
            }
            return result;
        }

        /// <summary>
        /// Berechnet aus der Summe der geraden Stellen (bereits verdoppelt) und
        /// der Summe der ungeraden Stellen die Checkziffer.
        /// </summary>
        private static int CalculateCheckDigit(int oddSum, int evenSum)
        {
            return oddSum + evenSum;
        }

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl.
        /// </summary>
        private static int CalculateDigitSum(int number)
        {
            int resultat = 0;
            while(number > 0)
            {
               resultat += number %10;
               number /= 10;
            }
            return resultat;
        }

        private static int ConvertToInt(char ch)
        {
            throw new NotImplementedException();
        }
    }
}
