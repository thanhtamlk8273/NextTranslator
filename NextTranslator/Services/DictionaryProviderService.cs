using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTranslator.Services;

public class DictionaryProviderService : IDictionaryProviderService
{
    public Dictionary<string, string> LoadDictionary(string dictionaryPath)
    {
        Dictionary<string, string> ret = new();
        
        try
        {
            using (var reader = new StreamReader(dictionaryPath))
            {
                while (reader.ReadLine() is string line)
                {
                    var parts = line.Split('=', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        ret.Add(parts[0], parts[1]); ;
                    }
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        return ret;
    }
}
