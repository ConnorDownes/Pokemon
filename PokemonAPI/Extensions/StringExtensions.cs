using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalise(this string str)
        {
            return str.First().ToString().ToUpper() + str.Substring(1);
        }
    }
}