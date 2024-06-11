using System;

namespace NextTranslator.Configurations;

public class AppConfigurations
{
    public string VietPhrasePath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "/Assets/VietPhrase.txt";
    public string NamesPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "/Assets/Names.txt";
}
