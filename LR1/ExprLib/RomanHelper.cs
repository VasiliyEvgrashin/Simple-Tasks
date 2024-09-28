using System.Data;

namespace ExprLib
{
    public class RomanHelper
    {
        ICoder _coder;

        public RomanHelper()
        {
            _coder = new Coder();
        }

        Stack<string> stack = new Stack<string>();
        int idx = 0;
        string value = "";
        string _input = "";
        
        public string Evaluate(string input)
        {
            _input = input.Trim().Replace(" ", "");
            char s = Get();
            while (s != '#')
            {
                CheckRule1();
                s = Get();
            }
            string result = _coder.Encode(int.Parse(stack.Peek())); ;
            Clear();
            return result;
        }

        void Clear()
        {
            stack.Clear();
            idx = 0;
            value = "";
            _input = "";
        }

        void CheckRule1()
        {
            char s = Get();
            if (s == '+')
            {
                pushStack();
                idx++;
                CheckRule3();
                int vb = _coder.Decode(stack.Pop());
                int va = _coder.Decode(stack.Pop());
                stack.Push((va + vb).ToString());
            } else if (s == '-')
            {
                pushStack();
                idx++;
                CheckRule3();
                int vb = _coder.Decode(stack.Pop());
                int va = _coder.Decode(stack.Pop());
                stack.Push((va - vb).ToString());
            } else
            {
                CheckRule2();
            }
        }

        void CheckRule2()
        {
            char s = Get();
            if (s == '*')
            {
                pushStack();
                idx++;
                CheckRule3();
                int vb = _coder.Decode(stack.Pop());
                int va = _coder.Decode(stack.Pop());
                stack.Push((va * vb).ToString());
            }
            else
            {
                CheckRule3();
            }
        }

        void CheckRule3()
        {
            char s = Get();
            if (s == '(')
            {
                idx++;
                while (s != ')')
                {
                    CheckRule1();
                    s = Get();
                }
                idx++;
                pushStack();
            }
            else
            {
                value += s;
                CheckNUM();
            }
        }

        void CheckNUM()
        {
            idx++;
            char s = Get();
            if (s == '#')
            {
                pushStack();
                return;
            }
            if (s != '+' && s != '-' && s != '*' && s != '(' && s != ')')
            {
                value += s;
                CheckNUM();
            }
            pushStack();
        }

        void pushStack()
        {
            if (value != "")
            {
                stack.Push(value);
                value = "";
            }
        }

        char Get()
        {
            if (idx >= _input.Length)
            {
                return '#';
            } else
            {
                return _input[idx];
            }
        }
    }
}
