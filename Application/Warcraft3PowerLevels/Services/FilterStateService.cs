using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;
using System;

namespace Warcraft3PowerLevels.Services;

/// <summary>
/// Service to hold the current filter state for heroes and units across different pages.
/// </summary>
public class FilterStateService
{
    public RaceEnum? HeroRace { get; set; } = null;
    public int HeroLevel { get; set; } = 1;
    public SortState<IHero> HeroSortState { get; set; } = new();

    // Unit main race = Human / Orc / Undead / NightElf / null (All)
    public RaceEnum? UnitRace { get; set; } = null;

    public ToggleStateEnum NeutralState { get; set; } = ToggleStateEnum.Off;
    public ToggleStateEnum SummonState { get; set; } = ToggleStateEnum.Off;

    // Shared or page-specific sorting
    public SortState<UnitPowerRow> UnitSortState_Power { get; set; } = new();
    public SortState<UnitPowerRow> UnitSortState_Power100g { get; set; } = new();
    public SortState<UnitPowerRow> UnitSortState_PowerPerSupply { get; set; } = new();

    public AttackTypeEnum SelectedAttack { get; set; } = AttackTypeEnum.None;
    public ArmorTypeEnum SelectedArmor { get; set; } = ArmorTypeEnum.None;
}
