namespace CarsPatterns.Models.Equipment;
public abstract class ExtraSystem
{
	public string Vendor { get; set; }
	public uint Kilometrage { get; set; }
	public string GetTechnicalInformation() =>
		$"{ToString()}\nНеобходимо проверять техническое состояние данной системы каждые {Kilometrage} км";
}
