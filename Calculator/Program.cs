using Calculator;

bool IsOperator(char s)
{
    if (s is '+' or '-' or '*' or '/' or '^')
    {
        return true;
    }

    return false;
}

string MakeNumber(Queue b)
{
    string result = "";
    for (int i = 0; i < b.GetLength(); i++)
    {
        result += b.GetValue(i);
    }

    return result;
}


string? newInput = Console.ReadLine();

ArrayList Tokenize()
{
    var b = new Queue();
    var tokens = new ArrayList();
    for (int i = 0; i < newInput!.Length; i++)
    {
        char s = newInput[i];
        if (Char.IsDigit(s))
        {
            b.Enque(Char.ToString(s));
        
        }
        else if (IsOperator(s) || s is '(' or ')')
        {
            if (b.GetLength() > 0)
            {
                string number = MakeNumber(b);
                tokens.Add(number);
                b = new Queue();
            }
            tokens.Add(Char.ToString(s));
        
        }
    }

    if (b.GetLength() > 0)
    {
        string number = MakeNumber(b);
        tokens.Add(number);
    }

    return tokens;
}

ArrayList myTokens = Tokenize();
myTokens.Print();
