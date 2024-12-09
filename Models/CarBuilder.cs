using CarsPatterns.Models.Equipment;

namespace CarsPatterns.Models;
public class CarBuilder
{
	private bool airbagSystem;
	private bool coolingSystem;
	private bool seatHeatingSystem;
	private ExtraSystemWrapper? extraSystems;
	private uint numberOfSeats;
	private uint numberOfDoors;
	private uint power;
	private string make;
	private string model;

	public CarBuilder()	{}

	public CarBuilder(Car car)
	{
		extraSystems = car.ExtraSystems;
		numberOfSeats = car.NumberOfSeats;
		numberOfDoors = car.NumberOfDoors;
		power = car.Power;
		make = car.Make;
		model = car.Model;
		var currentSystem = extraSystems;
		while(currentSystem is not null)
		{
			if(currentSystem.ExtraSystem is AirbagSystem)
				airbagSystem = true;
			else if (currentSystem.ExtraSystem is CoolingSystem)
				coolingSystem = true;
			else if (currentSystem.ExtraSystem is SeatHeatingSystem)
				seatHeatingSystem = true;
			currentSystem = currentSystem.Next;
		}
	}

	public CarBuilder AddExtraSystem(ExtraSystem extraSystem)
	{
		if (extraSystem is AirbagSystem && !airbagSystem)
		{
			airbagSystem = true;
			extraSystems = new ExtraSystemWrapper(extraSystem, extraSystems);
		}
		else if (extraSystem is CoolingSystem && !coolingSystem)
		{
			coolingSystem = true;
			extraSystems = new ExtraSystemWrapper(extraSystem, extraSystems);
		}
		else if (extraSystem is SeatHeatingSystem && !seatHeatingSystem)
		{
			seatHeatingSystem = true;
			extraSystems = new ExtraSystemWrapper(extraSystem, extraSystems);
		}
		return this;
	}
	public CarBuilder SetNumberOfSeats(uint numberOfSeats)
	{
		this.numberOfSeats = numberOfSeats;
		return this;
	}

	public CarBuilder SetNumberOfDoors(uint numberOfDoors)
	{
		this.numberOfDoors = numberOfDoors;
		return this;
	}

	public CarBuilder SetPower(uint power)
	{
		this.power = power;
		return this;
	}

	public CarBuilder SetName(string make, string model)
	{
		this.make = make;
		this.model = model;
		return this;
	}

	public Car Build()
	{
		if (power == 0 || numberOfSeats == 0 || numberOfDoors == 0 || make == null || model == null)
			throw new ArgumentException("Необходимо заполнить все обязательные поля.");
		return new Car(extraSystems, numberOfSeats, numberOfDoors, power, make, model);
	}
}
