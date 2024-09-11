// See https://aka.ms/new-console-template for more information
var input = Console.ReadLine();
var rows = int.Parse(input);
int i = 0;
while (i < rows)
{
    int j = 0;
    while (j < rows - i)
    {
        Console.Write("*");
        j = j + 1;
    }
    Console.WriteLine();

    i = i + 1;
}
