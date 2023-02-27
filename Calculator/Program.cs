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


int OperatorConvert(string s)
{
    if (s is "+" or "-")
    {
        return 2;
    }
    else if (s is "*" or "/")
    {
        return 3;
    }
    else if (s is "^")
    {
        return 4;
    }

    return 0;
}

ArrayList Tokenize()
{
    string? newInput = Console.ReadLine();
    var b = new Queue();
    var tokens = new ArrayList();
    for (int i = 0; i < newInput!.Length; i++)
    {
        char s = newInput[i];
        if (Char.IsDigit(s))
        {
            b.Enque(Char.ToString(s));
        
        }
        else if (IsOperator(s) || (s is ')' or '('))
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
    for (int i = 0; i < tokens.GetLenght(); i++)
    {
        string currentElement = tokens.GetElement(i);
        // if number
        if (int.TryParse(currentElement, out int n))
        {
            output.Add(currentElement);
        }
        // if operator
        else if (IsOperator(char.Parse(currentElement)))
        {
            while (operators.GetLength() > 0 && operators.PullCopy() != "(" &&
                   OperatorConvert(currentElement) <= OperatorConvert(operators.PullCopy()) &&
                   currentElement != "^")
            {
                output.Add(operators.Pull());
            }

            operators.Push(currentElement);
        }

        else if (currentElement == "(")
        {
            operators.Push(currentElement);
        }
        else if (currentElement == ")")
        {
            while (operators.GetLength() > 0 && operators.PullCopy() != "(")
            {
                output.Add(operators.Pull());
            }

            if (operators.PullCopy() == "(")
            {
                operators.Pull();
            }
            else
            {
                throw new Exception("there are mismatched parenthesis");
            }
        }

    }
    


    while (operators.GetLength() > 0)
    {
        var operatorToAdd = operators.Pull();
        if (operatorToAdd != "(")
        {
            output.Add(operatorToAdd);
        }
        else
        {
            throw new Exception("mismatched parethesis");
        }
    }
    return output;
}

string MakeOperation(string firstNumber, string secondNumber, string currentOperator)
{
    double numberOne = double.Parse(firstNumber);
    double numberTwo = double.Parse(secondNumber);
    string result = "";
    double intResult = 0;
    switch (currentOperator)
    {
        case "+":
            intResult = numberOne + numberTwo;
            break;
        case "-":
            intResult = numberOne - numberTwo;
            break;
        case "*":
            intResult = numberOne * numberTwo;
            break;
        case "/":
            if (numberTwo == 0)
            {
                throw new Exception("you cannot divide by 0");
            }
            intResult = numberOne / numberTwo;
            break;
        case "^":
            intResult = Convert.ToDouble(Math.Pow(numberOne, numberTwo));
            break;
        default:
            throw new Exception("the operator is invalid");
    }

    result = intResult.ToString();
    return result;
}


string Count(ArrayList tokens)
{
    Stack s = new Stack();
    for (int i = 0; i < tokens.GetLenght(); i++)
    {
        string currentElement = tokens.GetElement(i);
        if (int.TryParse(currentElement, out _))
        {
            s.Push(currentElement);
        }
        else
        {
            string secondNumber = s.Pull();
            string firstNumber = s.Pull();
            string result = MakeOperation(firstNumber, secondNumber, currentElement);
            s.Push(result);
        }
    }

    return s.Pull();
}

ArrayList myTokens = Tokenize();
ArrayList postfix = Postfix(myTokens);
string result = Count(postfix);
Console.WriteLine(result);



          


