using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Application.Common.Interfaces.Repositories;
using Application.Process.Weather;
using Domain.Entities;
using AutoMapper;
using Application.Process.Weather.Queries.GetWeatherForecasts.v1;
using Application.Common.Mappings;
using Application.Process.Weather.Queries.GetWeatherForecastById.v1;

namespace Application.UnitTests.Process.Weather.Queries.GetWeatherForecasts.v1
{
    public class GetWeatherForecasts
    {

        private readonly IMapper _mapper;
        public GetWeatherForecasts()
        {




            var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new WeatherForecastAutoMapper());
                });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        private static Task<IEnumerable<WeatherForecast>> WeatherForecastsFindAll()
        {
            var weatherForecasts = new List<WeatherForecast>
            {
                new() {Id = 1,Date = new DateTime(2023,9,1), TemperatureC = 10 ,Summaries="Cool"},
                new() {Id = 2,Date = new DateTime(2023,9,2), TemperatureC = 45 ,Summaries="Hot"},
                new() {Id = 3,Date = new DateTime(2023,9,3), TemperatureC = 20 ,Summaries="Sunny"},
            };
            return Task.FromResult(weatherForecasts.AsEnumerable());
        }

        private static Task<WeatherForecast?> WeatherForecastsFindById()
        {
            var weatherForecast = new WeatherForecast
            {
                Id = 1,
                Date = new DateTime(2023, 9, 1),
                TemperatureC = 10,
                Summaries = "Cool"
            };
            return Task.FromResult(weatherForecast);
        }


        [Fact]
        public async Task WeatherForecasts_FindAll_ReturnNotNull()
        {
            //Arrange            
            Mock<IWeatherForecastRepository> mockRepository = new();
            mockRepository
                .Setup(a => a.FindAllAsync())
                .Returns(WeatherForecastsFindAll());
            IWeatherForecastRepository repository = mockRepository.Object;

            var handler = new GetWeatherForecastHandler(repository, _mapper);
            var query = new GetWeatherForecastQuery();

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task WeatherForecasts_FindById_ReturnNotNull()
        {
            //Arrange            
            Mock<IWeatherForecastRepository> mockRepository = new();
            mockRepository
                .Setup(a => a.FindByIdAsync(1))
                .Returns(WeatherForecastsFindById());

            IWeatherForecastRepository repository = mockRepository.Object;
            var handler = new GetWeatherForecastByIdHandler(repository, _mapper);
            var query = new GetWeatherForecastByIdQuery() { Id = 1 };

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task WeatherForecasts_FindById_TestFahrenheit()
        {
            //Arrange       
            Mock<IWeatherForecastRepository> mockRepository = new();
            mockRepository
                .Setup(a => a.FindByIdAsync(1))
                .Returns(WeatherForecastsFindById());

            IWeatherForecastRepository repository = mockRepository.Object;
            var handler = new GetWeatherForecastByIdHandler(repository, _mapper);
            var query = new GetWeatherForecastByIdQuery() { Id = 1 };

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.Equal(49, result.TemperatureF);
        }
    }
}