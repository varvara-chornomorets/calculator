using System.Runtime.InteropServices;
using Calculator;

var tokens = new string[100];
string line = Console.ReadLine();
int k = 0;
for(int i = 0; i < line.Length; i++)
{
    char s = line[i];
    if (s == ' ')
    {
                    
        k++;
    }
    else
    {
        tokens[k] += s;
    }
}

foreach (string token in tokens)
{
    Console.WriteLine(token);
}



var newList = new ArrayList();
newList.Add(5);
Console.WriteLine(newList.GetLenght());
newList.Add(7);
Console.WriteLine(newList.GetLenght());
newList.Remove(7);
Console.WriteLine(newList.GetLenght());
newList.Add(689);
Console.WriteLine(newList.GetElement(1));