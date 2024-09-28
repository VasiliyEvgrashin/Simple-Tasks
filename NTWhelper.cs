namespace WebAPINET6.Controllers.MOJ
{
    public class NTWhelper : INTWhelper
    {
        String[] to_19 = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        String[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        String[] denom = { "hundred",
        "thousand",     "million",         "billion",       "trillion",       "quadrillion",
        "quintillion",  "sextillion",      "septillion",    "octillion",      "nonillion",
        "decillion",    "undecillion",     "duodecillion",  "tredecillion",   "quattuordecillion",
        "sexdecillion", "septendecillion", "octodecillion", "novemdecillion", "vigintillion" };

        public async Task<string> Convert(decimal num)
        {
            return await Task.Factory.StartNew(() =>
            {
                int cents = (int)((num - ((int)num)) * 100);
                string c = "";
                if (cents == 0) {
                    c = "and no cents";
                } else if (cents == 1)
                {
                    c = "and one cent";
                } else if (cents > 1 && cents < 20)
                {
                    c = "and " + to_19[cents] + " cents";
                } else if (cents >= 20 && cents < 100)
                {
                    IList<string> parts = new List<string>();
                    int ct = cents % 10;
                    int ctt = cents / 10;
                    if (ctt > 0)
                    {
                        parts.Add(tens[ctt]);
                    }
                    if (ct > 0)
                    {
                        parts.Add(to_19[ct]);
                    }
                    c = "and " + String.Join(' ', parts) + " cents";
                }
                int dollars = (int)num;
                if (dollars == 0 && cents == 0)
                {
                    return "";
                }
                string d = "";
                int pidx = 0;
                if (dollars == 0 && cents > 0)
                {
                    d = "zero dollars";
                } 
                else if (dollars == 1)
                {
                    d = "one dollar";
                }
                else if (dollars > 1 && dollars < 20)
                {
                    d = to_19[dollars] + " dollars";
                }
                else if (dollars >= 20 && dollars < int.MaxValue)
                {
                    IList<string> parts = new List<string>();
                    while (dollars > 0)
                    {
                        int ct = dollars % 1000;
                        dollars = dollars / 1000;
                        if (pidx > 0 && ct > 0)
                        {
                            parts.Add(denom[pidx]);
                        }
                        if (ct > 0 && ct < 100)
                        {
                            ForHundred(parts, ct);
                        }
                        else if (ct >= 100 && ct < 1000)
                        {
                            int dd = ct / 100;
                            ct = ct % 100;
                            ForHundred(parts, ct);
                            if (dd > 0) { parts.Add(to_19[dd] + " hundred"); }
                        }
                        if (dollars > 0)
                        {
                            pidx++;
                        }
                    }
                    d = String.Join(' ', parts.Reverse()) + " dollars";
                }
                string result = d;
                if (c != "")
                {
                    result += " " + c;
                }
                return result;
            });
        }

        void ForHundred(IList<string> parts, int ct)
        {
            if (ct > 0 && ct < 20)
            {
                parts.Add(to_19[ct]);
            }
            else if (ct >= 20 && ct < 100)
            {
                int dd4 = ct % 10;
                int ddd4 = ct / 10;
                if (dd4 != 0) {
                    parts.Add(to_19[dd4]);
                }
                parts.Add(tens[ddd4]);
            }
        }
    }
}
