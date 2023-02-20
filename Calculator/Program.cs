using Calculator;

bool IsOperator(char s)
{
    if (s is '+' or '-' or '*' or '/' or '^' or '(' or ')')
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


int OperatorConvert(char s)
{
    if (s is '+' or '-')
    {
        return 1;
    }
    else if (s is '*' or '/')
    {
        return 2;
    }
    else if (s is '^')
    {
        return 3;
    }

    return 0;
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
        else if (IsOperator(s))
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

ArrayList Postfix(ArrayList tokens)
{
    var operators = new Stack();
    var output = new ArrayList();
    for (int i = 0; i <= tokens.GetLenght(); i++)
    {
        if (int.TryParse(tokens.GetElement(i), out int n))
        {
            output.Add(tokens.GetElement(i));
        }
        else if (IsOperator(char.Parse(tokens.GetElement(i))))
        {
            if (char.Parse(operators.Pull()) is '(')
            {
                operators.Push(tokens.GetElement(i));
            }
            else if (char.Parse(operators.Pull()) is ')')
            {
                while (true)
                {
                    if (char.Parse(operators.Pull()) is '(')
                    {
                        break;
                    }

                    output.Add(operators.Pull());
                }
            }
            else if (OperatorConvert(char.Parse(operators.Pull())) >= OperatorConvert(char.Parse(tokens.GetElement(i))))
            {
                output.Add(operators.Pull());
                operators.Push(tokens.GetElement(i));
            }
            else if(true)
            {
                operators.Push(tokens.GetElement(i));
            }
        }
    }

    return output;
}

ArrayList myTokens = Tokenize();
ArrayList output = Postfix(myTokens);
output.Print();
