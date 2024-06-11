using Avalonia.Collections;
using NextTranslator.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;

namespace NextTranslator.ViewModels;

public class DictionarySelectionModel: ReactiveObject
{
    [Reactive] public bool IsSelected { get; set; } = false;
    [Reactive] public string Name { get; set; }
    public AvaloniaDictionary<string, string> Dict { get; set; }
};

public class DictionariesContentViewModel(IDictionariesProviderService dictionariesProvider) : ViewModelBase
{
    public ObservableCollection<DictionarySelectionModel> PageCollections { get; } = new() {
        new(){
            IsSelected = true,
            Name = "VietPhrase",
            Dict = dictionariesProvider.VietPhrase,
        },

        new(){
            IsSelected = false,
            Name = "Names",
            Dict = dictionariesProvider.Names,
        },
    };
}
