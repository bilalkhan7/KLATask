namespace KLATaskApp.Server
{
    public class CurrencyConverter
    {
        private static readonly string[] Ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static readonly string[] Teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] Tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private const string ZeroDollars = "zero dollars";
        private const string OneDollar = "one dollar";
        private const string OneCent = "one cent";

        public static string ConvertToWords(string amount)
        {
            // Removing any non-numeric characters from the input
            string cleanedAmount = amount.Replace(" ", "");

            // Checking if the cleaned amount is empty or too long
            if (string.IsNullOrEmpty(cleanedAmount) || cleanedAmount.Length > 13)
            {
                return "Invalid input format";
            }

            // Parsing the cleaned amount to a double
            if (!double.TryParse(cleanedAmount, out double amountValue))
            {
                return "Invalid input format";
            }

            if (amountValue == 0)
            {
                return ZeroDollars;
            }

            if (amountValue == 1)
            {
                if (cleanedAmount.Contains(","))
                {
                    return OneCent;
                }
            }

            // Splittíng the amount into dollars and cents
            string[] parts = cleanedAmount.Split(',');
            long dollars = long.Parse(parts[0]);
            long cents = parts.Length > 1 ? long.Parse(parts[1]) : 0;

            // Converting dollars to words
            string result = ConvertToWordsHelper(dollars / 1000000, "million") + " ";
            result += ConvertToWordsHelper((dollars % 1000000) / 1000, "thousand") + " ";
            result += ConvertToWordsHelper(dollars % 1000, "");

            // Adding the word "dollars" if the amount is greater than 1 dollar
            if (dollars != 1)
            {
                result += " dollars";
            }
            else
            {
                result += " dollar";
            }

            // Add cents if present
            if (cents != 0)
            {
                if (dollars != 0)
                {
                    result += " and ";
                }
                result += ConvertToWordsHelper(cents, "") + " ";
                result += cents == 1 ? "cent" : "cents";
            }

            return result.Trim();
        }

        private static string ConvertToWordsHelper(long number, string label)
        {
            if (number == 0)
                return "";

            string words = "";

            if (number >= 100)
            {
                words += $"{Ones[number / 100]} hundred ";
                number %= 100;
            }

            if (number >= 10 && number <= 19)
            {
                words += $"{Teens[number % 10]} ";
            }
            else
            {
                words += $"{Tens[number / 10]} ";
                number %= 10;
                words += $"{Ones[number]} ";
            }

            if (!string.IsNullOrEmpty(label))
            {
                words += $"{label} ";
            }

            return words.Trim();
        }
    }
}
