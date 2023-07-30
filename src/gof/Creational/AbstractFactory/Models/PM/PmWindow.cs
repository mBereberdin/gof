namespace gof.Creational.AbstractFactory.Models.PM;

using gof.Creational.AbstractFactory.Models.Base;

/// <summary>
/// Окно для стандарта PM.
/// </summary>
public sealed class PmWindow : Window
{
    /// <inheritdoc cref="PmWindow"/>
    /// <param name="colour">Цвет.</param>
    /// <param name="size">Размер.</param>
    /// <param name="isCloseButtonEnable">Включена ли кнопка закрытия окна.</param>
    public PmWindow(string colour, string size, bool isCloseButtonEnable) : base(colour, size)
    {
        IsCloseButtonEnable = isCloseButtonEnable;
    }

    /// <summary>
    /// Включена ли кнопка закрытия окна.
    /// </summary>
    public bool IsCloseButtonEnable { get; set; }
}