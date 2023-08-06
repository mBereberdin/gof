namespace gof.Creational.AbstractFactory.Models.PM;

using gof.Creational.AbstractFactory.Models.Base;

/// <summary>
/// Полоса прокрутки для стандарта PM.
/// </summary>
public sealed class PmScrollBar : ScrollBar
{
    /// <inheritdoc cref="PmScrollBar"/>
    /// <param name="colour">Цвет.</param>
    /// <param name="size">Размер.</param>
    /// <param name="isHide">Скрыта ли полоса прокрутки.</param>
    public PmScrollBar(string colour, string size, bool isHide) : base(colour, size)
    {
        IsHide = isHide;
    }

    /// <summary>
    /// Скрыта ли полоса прокрутки.
    /// </summary>
    public bool IsHide { get; set; }
}