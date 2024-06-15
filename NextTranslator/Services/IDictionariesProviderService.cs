using Avalonia.Collections;

namespace NextTranslator.Services;

public interface IDictionariesProviderService
{
    public AvaloniaDictionary<string, string> VietPhrase { get; }
    public AvaloniaDictionary<string, string> Names { get; }
    public void WriteToDisk();
}
