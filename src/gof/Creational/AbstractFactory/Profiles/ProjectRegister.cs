namespace gof.Creational.AbstractFactory.Profiles;

using gof.Creational.AbstractFactory.DTOs.Motif;
using gof.Creational.AbstractFactory.DTOs.PM;
using gof.Creational.AbstractFactory.Models.Base;

using Mapster;

/// <summary>
/// Реестр конфигураций адаптеров проекта.
/// </summary>
public class ProjectRegister : IRegister
{
    /// <summary>
    /// Реестр.
    /// </summary>
    /// <param name="config">Конфигурация адаптера.</param>
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Widget, PmWidgetDto>.NewConfig()
            .Map(destination => destination.WindowDto, source => source.Window.Adapt<PmWindowDto>())
            .Map(destination => destination.ScrollBarDto, source => source.ScrollBar.Adapt<PmScrollBarDto>());

        TypeAdapterConfig<Widget, MotifWidgetDto>.NewConfig()
            .Map(destination => destination.WindowDto, source => source.Window.Adapt<MotifWindowDto>())
            .Map(destination => destination.ScrollBarDto, source => source.ScrollBar.Adapt<MotifScrollBarDto>());
    }
}