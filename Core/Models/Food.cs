namespace Hall.Core.Models
{
     public class Food
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public int PreparationTime { get; set; }
          public int Complexity { get; set; }
          public CookingTool CookingTool { get; set; }
     }
}