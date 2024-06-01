using Avalonia.Platform.Storage;
using NextTranslator.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.IO;
using System.Reactive;
using System.Threading.Tasks;

namespace NextTranslator.ViewModels;

public class TranslationViewModel : ViewModelBase
{
    readonly private IFilesService? _filesService = null;

    [Reactive] public string Text { get; set; } = "";
    [Reactive] public ReactiveCommand<Unit, Unit> OpenFileCommand { get; private set; } = null!;

    public TranslationViewModel(IFilesService fileService)
    {
        _filesService = fileService;

        CreateCommands();
    }

    private void CreateCommands()
    {
        OpenFileCommand = ReactiveCommand.CreateFromTask(OnOpenFile);
    }

    private async Task OnOpenFile()
    {
        if (_filesService == null) return;

        Text = "";

        // Start async operation to open the dialog.
        var file = await _filesService.OpenFileAsync();

        if (file == null || file.TryGetLocalPath() is not String filePath || Path.GetExtension(filePath) != ".txt")
        {
            return;
        }

        await using var readStream = await file.OpenReadAsync();
        using var reader = new StreamReader(readStream);
        Text = await reader.ReadToEndAsync();
    }

}