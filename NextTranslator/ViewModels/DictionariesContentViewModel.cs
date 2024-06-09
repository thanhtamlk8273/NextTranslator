using Avalonia.Collections;
using NextTranslator.Services;
using System.Collections.ObjectModel;

namespace NextTranslator.ViewModels;

public record DictionarySelectionModel(bool IsSelected, string Name, AvaloniaDictionary<string, string> Dict);

public class DictionariesContentViewModel(IDictionariesProviderService dictionariesProvider) : ViewModelBase
{
    public ObservableCollection<DictionarySelectionModel> PageCollections { get; } = new() {
        new(true, "VietPhrase", dictionariesProvider.VietPhrase),
        new(false, "Names", dictionariesProvider.Names)
    };
}
