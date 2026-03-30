
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class ListVsDictionary
{
    public void AcceptandPrint()
    {
        Country country1 = new Country() { Code = "AUS", Name = "Australia", Capital = "Canberra" };
        Country country2 = new Country() { Code = "IND", Name = "India", Capital = "New Delhi" };
        Country country3 = new Country() { Code = "USA", Name = "United State", Capital = "Washington D.C." };
        Country country4 = new Country() { Code = "GBR", Name = "United Kingdom", Capital = "London" };
        Country country5 = new Country() { Code = "CAN", Name = "Canada", Capital = "Ottawa" };

        List<Country> ListCountry = new List<Country>() { country1, country2, country3, country4, country5 };

        Dictionary<string, Country> dictionaryCountries = new Dictionary<string, Country>();
        dictionaryCountries.Add(country1.Code, country1);
        dictionaryCountries.Add(country2.Code, country2);
        dictionaryCountries.Add(country3.Code, country3);
        dictionaryCountries.Add(country4.Code, country4);
        dictionaryCountries.Add(country5.Code, country5);

        string strUserChoice = string.Empty;
        do
        {
            Console.WriteLine("Enter country code ");
            string strCountryCode = Console.ReadLine().ToUpper();

            Country resultCountry = dictionaryCountries.ContainsKey(strCountryCode) ? dictionaryCountries[strCountryCode] : null;
            if (resultCountry != null)
            {
                Console.WriteLine("Name = " + resultCountry.Name + ", Capital = " + resultCountry.Capital);
            }
            else
            {
                Console.WriteLine("The Country Code you entered doesnot exist");
            }
            do
            {
                Console.WriteLine("Do you want toContinue: Y or N");
                strUserChoice = Console.ReadLine().ToUpper();
            } while (strUserChoice.ToUpper()!="N" && strUserChoice.ToUpper()!="Y");
        } while (strUserChoice.ToUpper()=="Y");
    }
}

    public class Country()
    {
        public string Name {  get; set; }
        public string Code { get; set; }
        public string Capital { get; set; }
    }

