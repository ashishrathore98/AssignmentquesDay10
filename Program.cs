using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextProcessingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a piece of text:");
            string inputText = Console.ReadLine();

            // Word Count
            int wordCount = CountWords(inputText);
            Console.WriteLine($"Word Count: {wordCount}");

            // Email Validation
            List<string> emailAddresses = ExtractEmailAddresses(inputText);
            Console.WriteLine("Email Addresses Found:");
            foreach (var email in emailAddresses)
            {
                Console.WriteLine(email);
            }

            // Mobile Number Extraction
            List<string> mobileNumbers = ExtractMobileNumbers(inputText);
            Console.WriteLine("Mobile Numbers Found:");
            foreach (var number in mobileNumbers)
            {
                Console.WriteLine(number);
            }

            // Custom Regex Search
            Console.WriteLine("Enter a custom regular expression:");
            string customRegexPattern = Console.ReadLine();
            List<string> customRegexMatches = PerformCustomRegexSearch(inputText, customRegexPattern);
            Console.WriteLine("Custom Regex Matches Found:");
            foreach (var match in customRegexMatches)
            {
                Console.WriteLine(match);
            }
        }

        // Method to count the number of words in the input text
        static int CountWords(string input)
        {
            return input.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // Method to validate if the input text contains any email addresses
        static List<string> ExtractEmailAddresses(string input)
        {
            var emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            var matches = Regex.Matches(input, emailPattern);
            return matches.Cast<Match>().Select(match => match.Value).ToList();
        }

        // Method to extract all mobile numbers present in the input text
        static List<string> ExtractMobileNumbers(string input)
        {
            var mobilePattern = @"\b\d{10}\b";
            var matches = Regex.Matches(input, mobilePattern);
            return matches.Cast<Match>().Select(match => match.Value).ToList();
        }

        // Method to perform a custom regex search within the input text
        static List<string> PerformCustomRegexSearch(string input, string regexPattern)
        {
            var matches = Regex.Matches(input, regexPattern);
            return matches.Cast<Match>().Select(match => match.Value).ToList();
        }
    }
}