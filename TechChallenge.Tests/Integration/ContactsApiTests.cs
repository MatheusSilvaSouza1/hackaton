using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Npgsql;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Json;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.Hosting;

namespace TechChallenge.Tests.Integration
{
    public class MedicosApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly NpgsqlConnection _connection;


        public MedicosApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();

            _connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=tech-challenge;Password=tech-challenge;Database=tech-challenge");
            _connection.Open();
        }

        [Fact]
        public async Task GetMedicos_ShouldReturnListOfMedicos()
        {
            var response = await _client.GetAsync("http://localhost:7296/Medico");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal((int)response.StatusCode, 200);
        }

        [Fact]
        public async Task CreateMedico_ShouldCreateNewMedico()
        {
            var newMedico = new { Name = "John Doe", Email = "john.doe@example.com", Phone = "81999999999" };
            var response = await _client.PostAsJsonAsync("http://localhost:7296/Medico", newMedico);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var createdMedicoId = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseString);

            Assert.NotNull(createdMedicoId);
            var dbMedico = await _connection.QueryFirstOrDefaultAsync("SELECT * FROM public.\"Medico\" WHERE \"Id\" = @Id", new { Id = createdMedicoId });
            Assert.NotNull(dbMedico);
            Assert.Equal(newMedico.Name, dbMedico.Name);
        }
    }
}