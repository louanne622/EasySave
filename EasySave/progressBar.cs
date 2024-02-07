using System;
using System.Threading;
class progressBar
{
    static void Main()
    {
        Console.WriteLine("Lancement de la barre de progression...");
        using (ProgressBar progressBar = new ProgressBar())
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Update(i);
                Thread.Sleep(70);
            }
        }
        Console.WriteLine("Appuyez sur n'importe quelle touche pour quitter");
        Console.ReadKey();
    }
}

class ProgressBar : IDisposable
{
    private const int ProgressBarLength = 70;
    private const char ProgressBarChar = '■';

    public ProgressBar()
    {
        Console.Write("[");
    }

    public void Update(int percent)
    {
        int progressLength = (int)Math.Ceiling((double)percent / 100 * ProgressBarLength);
        Console.CursorLeft = 1;
        Console.Write(new string(ProgressBarChar, progressLength).PadRight(ProgressBarLength));
        Console.Write($"]{percent}%", new string(' ', 5));
        Console.CursorLeft = 0;
    }

    public void Dispose()
    {
        Console.WriteLine();
    }
}
