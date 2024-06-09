using Avalonia.Collections;
using NextTranslator.Configurations;
using System;
using System.IO;

namespace NextTranslator.Services;

public class DictionariesProviderService(AppConfigurations configurations) : IDictionariesProviderService
{
    public AvaloniaDictionary<string, string> VietPhrase { get; } = LoadDictionary(configurations.VietPhrasePath);

    public AvaloniaDictionary<string, string> Names { get; } = LoadDictionary(configurations.NamesPath);

    static private AvaloniaDictionary<string, string> LoadDictionary(string dictionaryPath)
    {
        AvaloniaDictionary<string, string> ret = new();

        try
        {
            using (var reader = new StreamReader(dictionaryPath))
            {
                while (reader.ReadLine() is string line)
                {
                    var parts = line.Split('=', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        ret[parts[0]] = parts[1];
                    }
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine(e.Message);
        }

        return ret;
    }
}
