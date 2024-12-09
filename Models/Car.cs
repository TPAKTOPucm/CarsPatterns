using CarsPatterns.Models.Equipment;

namespace CarsPatterns.Models;
public class Car
{
	public ExtraSystemWrapper? ExtraSystems { get; }
	public uint NumberOfSeats { get; }
	public uint NumberOfDoors { get; }
	public uint Power { get; }
	public string Make { get; }
	public string Model { get; }

	public Car(ExtraSystemWrapper? extraSystems, uint numberOfSeats, uint numberOfDoors, uint power, string make, string model)
	{
		ExtraSystems = extraSystems;
		NumberOfSeats = numberOfSeats;
		NumberOfDoors = numberOfDoors;
		Power = power;
		Make = make;
		Model = model;
	}

	public override string ToString() =>
		$"{Make} {Model} - сидений: {NumberOfSeats}, дверей: {NumberOfDoors}, {Power} л.с.";

	public string GetTechnicalInformation() =>
		ToString() + "\nДоп. системы:\n" + ExtraSystems?.GetTechnicalInformation();

	public string GetBaseInformation() =>
		ToString() + "\nДоп. системы:\n" + ExtraSystems?.GetBaseInformation();

	public CarBuilder GetEditableTemplate() => 
		new CarBuilder(this);
}
