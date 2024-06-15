using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using System;

namespace NextTranslator.Controls;

public partial class EditableTextBlock : UserControl
{
    public static readonly StyledProperty<string?> TextProperty = AvaloniaProperty.Register<EditableTextBlock, string?>
        (nameof(Text), default(string), false, BindingMode.TwoWay);

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly RoutedEvent<RoutedEventArgs> ValueChangedEvent =
        RoutedEvent.Register<EditableTextBlock, RoutedEventArgs>(nameof(ValueChanged), RoutingStrategies.Bubble);

    public event EventHandler<RoutedEventArgs> ValueChanged
    {
        add => AddHandler(ValueChangedEvent, value);
        remove => RemoveHandler(ValueChangedEvent, value);
    }

    protected virtual void OnValueChanged()
    {
        RoutedEventArgs args = new RoutedEventArgs(ValueChangedEvent);
        RaiseEvent(args);
    }

    public EditableTextBlock()
    {
        InitializeComponent();
    }

    private void OkButton_Click(object? sender, RoutedEventArgs e)
    {
        OnValueChanged();
    }
}