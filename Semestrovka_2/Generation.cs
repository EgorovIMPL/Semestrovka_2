using System.Text;

namespace Semestrovka_2;

public class Generation
{
    public static void Start()
    {
        string[] Data = new string[new Random().Next(50, 100)];
        for (int i = 0; i < Data.Length; i++)
        {
            StringBuilder sb = new StringBuilder();
            for (int g = 0; g < new Random().Next(100, 10000); g++)
            {
                sb.Append(new Random().Next(1, 500) + " ");
            }
            Data[i] = sb.ToString();
        }
        File.WriteAllLines(@"C:\SomeDir2\array.txt", Data);
    }
}