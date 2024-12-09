namespace CarsPatterns.Models.Equipment;
public class CoolingSystem : ExtraSystem
{
    public CoolingSystem()
    {
        Kilometrage = 30_000;
    }
    public uint Power { get; set; }
	public override string ToString() =>
		$"Кондиционер мощностью {Power} Вт, от производителя {Vendor}";
}
