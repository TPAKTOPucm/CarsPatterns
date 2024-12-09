namespace CarsPatterns.Models.Equipment;
public class ExtraSystemWrapper
{
	public ExtraSystem ExtraSystem { get; set; }
	public ExtraSystemWrapper? Next { get; private set; }
	public ExtraSystemWrapper(ExtraSystem extraSystem, ExtraSystemWrapper? next = null)
	{
		ExtraSystem = extraSystem;
		Next = next;
	}
	public string GetTechnicalInformation() =>
		" - " + ExtraSystem.GetTechnicalInformation() + "\n" + Next?.GetTechnicalInformation();
	public string GetBaseInformation() =>
		" - " + ExtraSystem.ToString() + "\n" + Next?.GetBaseInformation();
}
