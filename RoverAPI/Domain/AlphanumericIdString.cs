using Microsoft.AspNetCore.Routing;
using System;
using System.Text.RegularExpressions;

namespace RoverAPI.Persistence
{
    public class AlphaNumericIdString : IParameterPolicy
    {
        private const int minLength = 1;
        private const int maxLength = 10;

        private static readonly string alphanumericIdRegEx = $"^[a-zA-Z0-9]{{{minLength},{maxLength}}}$";
        private static readonly Regex regex;
        private readonly string alphanumericIdString;

        static AlphaNumericIdString()
        {
            regex = new Regex(alphanumericIdRegEx);
        }

        public AlphaNumericIdString(string s)
        {
            if (!regex.IsMatch(s))
            {
                throw new ArgumentException("String must have length from 1-10 and contain only alphanumeric characters.");
            }

            alphanumericIdString = s;
        }

        static public implicit operator string(AlphaNumericIdString s)
        {
            return s.alphanumericIdString;
        }
    }
}
