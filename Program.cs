using CarsPatterns.Models.Equipment;
using CarsPatterns.Models;

namespace CarsPatterns;

internal class Program
{
	public static void Main(string[] args)
	{
		var builder = new CarBuilder();
		Console.WriteLine("Хотите сами ввести данные? (да/нет)");

		if (Console.ReadLine()?.ToLower() == "да")
		{
			Console.WriteLine("Введите марку автомобиля:");
			var make = Console.ReadLine();
			Console.WriteLine("Введите модель автомобиля:");
			var model = Console.ReadLine();
			builder.SetName(make, model);
			Console.WriteLine("Введите количество мест:");
			builder.SetNumberOfSeats(uint.Parse(Console.ReadLine()));
			Console.WriteLine("Введите количество дверей:");
			builder.SetNumberOfDoors(uint.Parse(Console.ReadLine()));
			Console.WriteLine("Введите мощность (л.с.):");
			builder.SetPower(uint.Parse(Console.ReadLine()));

			Console.WriteLine("Хотите добавить систему подушек безопасности? (да/нет)");
			if (Console.ReadLine()?.ToLower() == "да")
			{
				var system = new AirbagSystem();
				Console.WriteLine("Введите количество подушек безопасности:");
				system.NumberOfAirbags = uint.Parse(Console.ReadLine());
				Console.WriteLine("Введите производителя системы безопасности:");
				system.Vendor = Console.ReadLine();
				builder.AddExtraSystem(system);
			}
			Console.WriteLine("Хотите добавить кондиционер? (да/нет)");
			if (Console.ReadLine()?.ToLower() == "да")
			{
				var system = new CoolingSystem();
				Console.WriteLine("Введите мощность кондиционера:");
				system.Power = uint.Parse(Console.ReadLine());
				Console.WriteLine("Введите производителя кондиционера:");
				system.Vendor = Console.ReadLine();
				builder.AddExtraSystem(system);
			}
			Console.WriteLine("Хотите добавить систему подогрева сидений? (да/нет)");
			if (Console.ReadLine()?.ToLower() == "да")
			{
				var system = new SeatHeatingSystem();
				Console.WriteLine("Введите мощность системы подогрева сидений:");
				system.Power = uint.Parse(Console.ReadLine());
				Console.WriteLine("Введите количество сидений с подогревом:");
				system.NumberOfSeats = uint.Parse(Console.ReadLine());
				Console.WriteLine("Введите производителя системы подогрева сидений:");
				system.Vendor = Console.ReadLine();
			}
			Car car = builder.Build();

			Console.WriteLine("\nБазовая информация об автомобиле:");
			Console.WriteLine(car.GetBaseInformation());
			Console.WriteLine("\nТехническая информация об автомобиле:");
			Console.WriteLine(car.GetTechnicalInformation());
		} else
		{
			var car = builder
				.SetName("Toyota", "Camry")
				.SetNumberOfSeats(5)
				.SetNumberOfDoors(4)
				.SetPower(200)
				.AddExtraSystem(new AirbagSystem
				{
					NumberOfAirbags = 2,
					Vendor = "Toyota"
				})
				.AddExtraSystem(new CoolingSystem
				{
					Power = 140,
					Vendor = "AutoCool"
				}).Build();

			var car2 = car.GetEditableTemplate()
				.SetName("Toyota", "Rav4")
				.SetNumberOfDoors(5).Build();

			Console.WriteLine(car.GetBaseInformation());
			Console.WriteLine(car.GetTechnicalInformation());
			Console.WriteLine(car2.GetBaseInformation());
			Console.WriteLine(car2.GetTechnicalInformation());
		}
	}
}
