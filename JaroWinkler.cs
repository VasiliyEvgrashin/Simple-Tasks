namespace WebAPINET6.Controllers.UM
{
    public class JaroWinkler
    {
        void Init(ref string s1, ref string s2)
        {
            s1 = s1.ToLower().Trim();
            s2 = s2.ToLower().Trim();
            int a = s1.Length;
            int b = s2.Length;
            string ss1 = "" + s1[0];
            if (a > 1)
            {
                for (int i = 1; i < a; i++)
                {
                    if (s1[i - 1] != s1[i])
                    {
                        ss1 += s1[i];
                    }
                }
                s1 = ss1;
            }
            string ss2 = "" + s2[0];
            if (b > 1)
            {
                for (int i = 1; i < b; i++)
                {
                    if (s2[i - 1] != s2[i])
                    {
                        ss2 += s2[i];
                    }
                }
                s2 = ss2;
            }
        }
        int Get(string s1, string s2)
        {
            int a = s1.Length;
            int b = s2.Length;
            int l = 0;
            int m = 0;
            int tr = 0;
            if (a < b)
            {
                bool[] check = new bool[a];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        if (s1[i] == s2[j])
                        {
                            if (i == j)
                            {
                                if (l < 4)
                                {
                                    l++;
                                }
                                tr--;
                            }
                            check[i] = true;
                        }
                    }
                }
                m = check.Where(w => w).Count();
            }
            else
            {
                bool[] check = new bool[b];
                for (int i = 0; i < b; i++)
                {
                    for (int j = 0; j < a; j++)
                    {
                        if (s2[i] == s1[j])
                        {
                            if (i == j)
                            {
                                if (l < 4)
                                {
                                    l++;
                                }
                                tr--;
                            }
                            check[i] = true;
                        }
                    }
                }
                m = check.Where(w => w).Count();
            }
            tr = tr + m;
            int t = tr / 2;
            decimal dj = (((decimal)m / a) + ((decimal)m / b) + ((decimal)(m - t) / m)) / 3;
            decimal dw = dj + ((decimal)(l * 0.1) * ((decimal)(1 - dj)));
            return (int)(dw * 100);
        }

        public int GetDistance(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return 0;
            }
            int a = s1.Length;
            int b = s2.Length;
            if (a == 0 || b == 0)
            {
                return 0;
            }
            Init(ref s1, ref s2);
            int result = Get(s1, s2);
            for(int i = 1; i < 5; i++)
            {
                if (result < 90 && a != b && a > 4 && b > 4)
                {
                    if (a < b)
                    {
                        result = Get(s1.Insert(i, " "), s2);
                    }
                    else
                    {
                        result = Get(s1, s2.Insert(i, " "));
                    }
                } else
                {
                    break;
                }
            }
            return result;
        }
    }
}
