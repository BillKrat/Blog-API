using Framework.Shared.Dto;
using Framework.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dal.Sql.Logic
{
    public class UserDalSql : IUserDal
    {
        public List<UserDto> GetUserList()
        {
            var returnList = new List<UserDto>();
            foreach (var item in Get())
            {
                returnList.Add(new UserDto
                {
                    Data = item
                });
            }
            return returnList;
        }

        public dynamic Get()
        {
            var summaries = new[]
            {
            "Here I is","Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();

            return forecast;
        }
        record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
        {
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
