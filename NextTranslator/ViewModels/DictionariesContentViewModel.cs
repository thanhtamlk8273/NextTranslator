using Avalonia.Collections;
using NextTranslator.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;

namespace NextTranslator.ViewModels;

public class DictionarySelectionModel: ReactiveObject
{
    [Reactive] public bool IsSelected { get; set; } = false;
    [Reactive] public string Name { get; set; }
    public AvaloniaDictionary<string, string> Dict { get; set; }
};

public class DictionariesContentViewModel : ViewModelBase
{
    private IDictionariesProviderService _dictionariesProvider { get; }

    public DictionariesContentViewModel(IDictionariesProviderService dictionariesProvider)
    {
        _dictionariesProvider = dictionariesProvider;
        CreateSelectionModels();
        CreateCommands();
    }


    public ObservableCollection<DictionarySelectionModel> PageCollections { get; } = new();

    public ReactiveCommand<KeyValuePair<string, string>, Unit> AddRecordCommand { get; private set; } = null!; 
    public ReactiveCommand<KeyValuePair<string, string>, Unit> DeleteRecordCommand { get; private set; } = null!;

    private void CreateSelectionModels()
    {
        PageCollections.Add(
            new()
            {
                IsSelected = true,
                Name = "VietPhrase",
                Dict = _dictionariesProvider.VietPhrase,
            }
        );

        PageCollections.Add(
            new()
            {
                IsSelected = true,
                Name = "Names",
                Dict = _dictionariesProvider.Names,
            }
        );
    }

    private void CreateCommands()
    {
        AddRecordCommand = ReactiveCommand.Create<KeyValuePair<string, string>>(r => OnAddRecord(r));
        DeleteRecordCommand = ReactiveCommand.Create<KeyValuePair<string, string>>(r => OnDeleteRecord(r));
    }

    private void OnAddRecord(KeyValuePair<string, string> record)
    {
        Console.WriteLine($"Add {record.Key} - {record.Value}");
    }

    private void OnDeleteRecord(KeyValuePair<string, string> record)
    {
        PageCollections.FirstOrDefault(x => x.IsSelected)?.Dict.Remove(record.Key);
    }
}
