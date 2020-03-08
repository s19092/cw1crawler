using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace krawler
{
    class Program


    {

        static async System.Threading.Tasks.Task Main(string[] args)
        {

            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(args[0]);
            var responseAsString = response.ToString();

            Console.WriteLine(responseAsString);
            Console.WriteLine("\n");

            Regex exp = new Regex("\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\\b", RegexOptions.IgnoreCase);
            MatchCollection emails = exp.Matches(response);
            HashSet<String> setMail = new HashSet<string>();

            foreach (Match email in emails) {
                setMail.Add(email.Value.ToUpper());
             
              
            }

            foreach (String mail in setMail)
                Console.WriteLine(mail);

        }

    }
}
