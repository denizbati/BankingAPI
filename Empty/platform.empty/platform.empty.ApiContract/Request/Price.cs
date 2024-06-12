using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApiContract.Request
{

    public class Price
    {
        private readonly CultureInfo CultureInfo = CultureInfo.GetCultureInfo("tr-TR");

        public string Currency { get; protected set; } = "TL";


        public decimal Value { get; protected set; }

        public long ValueInt => ParseDecimalToLong(Value);

        private string ValueStringWithoutCurrency => string.Format(CultureInfo, "{0:N2}", Value);

        public string ValueString => ValueStringWithoutCurrency + " " + Currency;

        public string WholePartString => ValueStringWithoutCurrency.Split(DecimalSeparator)[0];

        public string FractionPartString => ValueStringWithoutCurrency.Split(DecimalSeparator)[1];

        public string DecimalSeparator => CultureInfo.NumberFormat.NumberDecimalSeparator;

        [System.Text.Json.Serialization.JsonConstructor]
        public Price(decimal value, string currency = "TL")
        {
          

            Value = RoundDecimalAmount(value);
            Currency = currency;
        }

        public Price(int value, string currency = "TL")
        {
           

            Value = RoundDecimalAmount(decimal.Divide(value, 100m));
            Currency = currency;
        }

        private decimal RoundDecimalAmount(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }

        private static int ParseDecimalToInt(decimal amount)
        {
            return Convert.ToInt32(amount * 100m);
        }

        private static long ParseDecimalToLong(decimal amount)
        {
            return Convert.ToInt64(amount * 100m);
        }

        public static Price operator +(Price p1, Price p2)
        {
           
            return new Price(p1.Value + p2.Value, p1.Currency);
        }

        public static Price operator *(Price p1, decimal d)
        {
            return new Price(p1.Value * d, p1.Currency);
        }

        public static Price operator *(Price p1, int i)
        {
            return new Price(p1.Value * (decimal)i, p1.Currency);
        }
    }
}
