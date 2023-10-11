namespace superhero.DTOs
{
  public record struct SuperHeroCreateDto(string name, BackpackCreateDto backpack, List<WeaponCreateDto> Weapons);
}