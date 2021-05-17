using System;

namespace MyAwardProgram.Shared.Types
{
    public class CPF
    {
        //private readonly string _value;
        public string Value { get; private set; }

        private CPF(string value)
        {
            Value = value;
        }

        public static CPF Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }
            throw new ArgumentException($"String '{value}' was not recognized as a valid CPF.");
        }

        public static bool TryParse(string value, out CPF cpf)
        {
            if (string.IsNullOrEmpty(value) || Maoli.Cpf.Validate(value))
            {
                cpf = new CPF(value);
                return true;
            }

            cpf = new CPF(string.Empty);
            return false;
        }

        public override string ToString()
            => Value;

        public string ToFormattedString()
        {
            var aux = Value.ToString().Replace(".", string.Empty).Replace("-", string.Empty);
            return $"{aux.Substring(0, 3)}.{aux.Substring(3, 3)}.{aux.Substring(6, 3)}-{aux.Substring(9, 2)}"; 
        }

        public static implicit operator CPF(string input)
            => Parse(input);
    }
}
