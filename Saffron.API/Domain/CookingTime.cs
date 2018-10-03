namespace Saffron.API.Domain
{
  public class CookingTime
  {
    public string TimeTitle { get; set; } // ex: Prep, Cook, Total
    public int Minutes { get; set; }
    public int Hours { get; set; }
    public Recipe Recipe { get; set; }
  }
}
