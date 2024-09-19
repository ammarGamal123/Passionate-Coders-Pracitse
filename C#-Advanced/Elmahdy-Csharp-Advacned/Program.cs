

string dirPath = @"D:\Audio";
int level = 1;
PrintFileSystemEnteries(dirPath, level);

static void PrintFileSystemEnteries(string path , int level)
{
    foreach(var fileName in Directory.GetFiles(path))
        Console.WriteLine($"{new string('-' , level)}:" +
            $"{new FileInfo(fileName).Name}");

    foreach (var dirName in Directory.GetDirectories(path))
    {
        Console.WriteLine($"{new string('-', level)}:" +
            $"{new DirectoryInfo(dirName).Name}");

        PrintFileSystemEnteries(dirName, level + 1);
    }
}

Console.WriteLine($"\n\n\n\nTotal Size = {CalculateDirectoriesSize(dirPath)} bytes");

static long CalculateDirectoriesSize(string path)
{
    long totalSize = 0;
    foreach (var fileName in Directory.GetFiles(path))
    {
        totalSize += new FileInfo(fileName).Length;
    }

    foreach (var dirName in Directory.GetDirectories(path))
    {
        totalSize += CalculateDirectoriesSize(dirName);
    }

    return totalSize;
}





#region Factorial
int value = 5;
Console.WriteLine($"\n\n\nFactorial of {value} is {CalculateFactorial(value)}");


static int CalculateFactorial(int number)
{
    if (number <= 1)
        return number;

    return number * CalculateFactorial(number - 1);
}
#endregion

Console.ReadKey();


