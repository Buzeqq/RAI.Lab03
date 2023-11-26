using System.Globalization;

const string input = "1,2345E-02";
var result = decimal.Parse(input, NumberStyles.Float);
Console.WriteLine(result);