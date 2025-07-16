using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();

        // Add multiple English-to-German word translations
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");
        englishToGerman.AddWord("Book", "Buch");
        englishToGerman.AddWord("Apple", "Apfel");

        // Test translations
        Console.WriteLine(englishToGerman.Translate("Car"));     // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));   // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Book"));    // Buch
        Console.WriteLine(englishToGerman.Translate("Train"));   // ???
        Console.WriteLine(englishToGerman.Translate("Apple"));   // Apfel
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Adds a translation from 'fromWord' to 'toWord'.
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord; // Updates or adds the word
    }

    /// <summary>
    /// Returns the translation of the given word, or "???" if not found.
    /// </summary>
    public string Translate(string fromWord)
    {
        return _words.TryGetValue(fromWord, out string translation) ? translation : "???";
    }
}
