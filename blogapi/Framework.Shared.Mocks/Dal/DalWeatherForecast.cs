using Framework.Shared.Dto;
using Framework.Shared.Interfaces;

namespace Framework.Shared.Mocks.Dal
{
    public class DalWeatherForecast : IDalFacade, IDefaultDataProvider
    {
        public List<DataDto> GetList(EventArgs e)
        {
            var returnList = new List<DataDto>();
            foreach (var item in Get())
            {
                returnList.Add(new DataDto
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
