// See https://aka.ms/new-console-template for more information
using ExprLib;
RomanHelper helper = new RomanHelper();
Console.WriteLine(helper.Evaluate("(MMMDCCXXIV - MMCCXXIX) * II"));
Console.WriteLine(helper.Evaluate("(MMMDCCXXIV - MMCCXXIX) * II + IIIVIVIX"));
Console.WriteLine(helper.Evaluate("(MMMDCXXV - MMCCXIX) * IV + IIIVIVIX"));
Console.ReadLine();

