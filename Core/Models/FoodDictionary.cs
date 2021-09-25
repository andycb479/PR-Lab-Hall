using System.Collections.Generic;

namespace Hall.Core.Models
{
     public class FoodDictionary
     {
          private readonly Dictionary<int, Food> _foods = new()
          {
               {
                    1, new Food
                    {
                         Id = 1,
                         Name = "Pizza",
                         PreparationTime = 20,
                         Complexity = 2,
                         CookingTool = CookingTool.Oven
                    }
               },
               {
                    2, new Food
                    {
                         Id = 2,
                         Name = "Salad",
                         PreparationTime = 10,
                         Complexity = 1,
                         CookingTool = CookingTool.None
                    }
               },
               {
                    3, new Food
                    {
                         Id = 3,
                         Name = "Zeama",
                         PreparationTime = 7,
                         Complexity = 1,
                         CookingTool = CookingTool.Stove
                    }
               },
               {
                    4, new Food
                    {
                         Id = 4,
                         Name = "Scallop Sashimi with Meyer Lemon Confit",
                         PreparationTime = 32,
                         Complexity = 3,
                         CookingTool = CookingTool.None
                    }
               },
               {
                    5, new Food
                    {
                         Id = 5,
                         Name = "Island Duck with Mulberry Mustard",
                         PreparationTime = 35,
                         Complexity = 3,
                         CookingTool = CookingTool.Oven
                    }
               },
               {
                    6, new Food
                    {
                         Id = 6,
                         Name = "Waffles",
                         PreparationTime = 10,
                         Complexity = 1,
                         CookingTool = CookingTool.Stove
                    }
               },
               {
                    7, new Food
                    {
                         Id = 7,
                         Name = "Aubergine",
                         PreparationTime = 20,
                         Complexity = 2,
                         CookingTool = CookingTool.None
                    }
               },
               {
                    8, new Food
                    {
                         Id = 8,
                         Name = "Lasagna",
                         PreparationTime = 30,
                         Complexity = 2,
                         CookingTool = CookingTool.Oven
                    }
               },
               {
                    9, new Food
                    {
                         Id = 9,
                         Name = "Burger",
                         PreparationTime = 15,
                         Complexity = 1,
                         CookingTool = CookingTool.Oven
                    }
               },
               {
                    10, new Food
                    {
                         Id = 10,
                         Name = "Gyros",
                         PreparationTime = 15,
                         Complexity = 1,
                         CookingTool = CookingTool.None
                    }
               }


          };

          public Food GetFoodById(int id)
          {
               return _foods[id];
          }
     }
}