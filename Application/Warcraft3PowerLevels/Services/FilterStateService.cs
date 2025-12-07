using Warcraft3PowerLevels.Entities.Enumerations;
using Warcraft3PowerLevels.Entities.General;
using System;

namespace Warcraft3PowerLevels.Services;

public class FilterStateService
{
    /* ---------------------------------------------------------
       HERO FILTERS
       --------------------------------------------------------- */

    // Heroes can legitimately select Neutral as race
    public RaceEnum? HeroRace { get; set; } = null;

    public int HeroLevel { get; set; } = 1;

    public SortState<IHero> HeroSortState { get; set; } = new();


    /* ---------------------------------------------------------
       UNIT FILTERS (Neutral is NOT a race — handled separately)
       --------------------------------------------------------- */

    // Unit main race = Human / Orc / Undead / NightElf / null (All)
    public RaceEnum? UnitRace { get; set; } = null;

    public bool UnitIncludeNeutral { get; set; } = false;
    public bool UnitIncludeSummons { get; set; } = false;

    // Shared or page-specific sorting
    public SortState<UnitPowerRow> UnitSortState_Power { get; set; } = new();
    public SortState<UnitPowerRow> UnitSortState_Power100g { get; set; } = new();
    public SortState<UnitPowerRow> UnitSortState_PowerPerSupply { get; set; } = new();


    /* ---------------------------------------------------------
       DAMAGE FILTER STATE FOR ALL UNIT PAGES
       --------------------------------------------------------- */

    public AttackTypeEnum SelectedAttack { get; set; } = AttackTypeEnum.None;
    public ArmorTypeEnum SelectedArmor { get; set; } = ArmorTypeEnum.None;
}
