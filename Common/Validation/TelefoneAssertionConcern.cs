using Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Validation
{
    public class TelefoneAssertionConcern
    {
        public static void AssertIsValid(string telefone,string telefoneInvalido)
        {
            if (!Regex.IsMatch(telefone, @"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$", RegexOptions.IgnorePatternWhitespace))
                throw new Exception(Errors.TelefoneInvalido);
        }
    }
}
