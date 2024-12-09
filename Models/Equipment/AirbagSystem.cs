namespace CarsPatterns.Models.Equipment;
public class AirbagSystem : ExtraSystem
{
    public AirbagSystem()
    {
        Kilometrage = 50_000;
    }
    public uint NumberOfAirbags { get; set; }
	public override string ToString() =>
		$"Система пассивной безопасности, состоящая из {NumberOfAirbags} подушек безопасности от производителя {Vendor}";
}
