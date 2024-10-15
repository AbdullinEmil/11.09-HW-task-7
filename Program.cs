using System;
using System.Linq;

public class Censor
{
    public static string CensorText(string text, string[] forbiddenWords)
    {
        string[] words = text.Split(' ');
        string[] censoredWords = words.Select(word =>
        {
            // Check if the word contains ANY of the forbidden words
            if (forbiddenWords.Any(forbiddenWord => word.ToLower().Contains(forbiddenWord)))
            {
                return new string('*', word.Length);
            }
            else
            {
                return word;
            }
        }).ToArray();
        return string.Join(" ", censoredWords);
    }

    public static void Main(string[] args)
    {
        string text = @"
        To be, or not to be, that is the question,
        Whether 'tis nobler in the mind to suffer
        The slings and arrows of outrageous fortune,
        Or to take arms against a sea of troubles,
        And by opposing end them? To die: to sleep;
        No more; and by a sleep to say we end
        The heart-ache and the thousand natural shocks
        That flesh is heir to, 'tis a consummation
        Devoutly to be wish'd. To die, to sleep
        ";

        string[] forbiddenWords = { "die" };

        string censoredText = CensorText(text, forbiddenWords);

        Console.WriteLine("текст:");
        Console.WriteLine(text);

        Console.WriteLine("\nтекст с цензурой:");
        Console.WriteLine(censoredText);

        Console.WriteLine("\nИтог:");
        Console.WriteLine($"Кол-во замененных слов: {forbiddenWords.Length}");
        Console.WriteLine($"Слова которые заменили на *: {string.Join(", ", forbiddenWords)}");
    }
}
