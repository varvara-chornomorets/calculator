﻿using System.Runtime.InteropServices;
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

