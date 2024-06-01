using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTranslator.Services;

public interface IDictionaryProviderService
{
    Dictionary<string, string> LoadDictionary(string dictionaryPath);
}
