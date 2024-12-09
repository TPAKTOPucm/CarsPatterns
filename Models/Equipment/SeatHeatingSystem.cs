namespace CarsPatterns.Models.Equipment;
public class SeatHeatingSystem : ExtraSystem
{
    public SeatHeatingSystem()
    {
        Kilometrage = 100_000;
    }
    public uint NumberOfSeats { get; set; }
	public uint Power { get; set; }
	public override string ToString() =>
		$"Система подогрева сидений мощностью {Power} Вт, от производителя {Vendor}. Количество сидений: {NumberOfSeats}";
}
