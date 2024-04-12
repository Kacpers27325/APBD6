using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AnimalsController:ControllerBase
{

    private readonly IConfiguration _configuration;

    public AnimalController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        //otwieramy połączenie
        using SqlConnection connection = new SqlConnection("");
        connection.Open();
        //Definiujemy query
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * from Animals";
        
        //uruchomienie commanda
        var reader = command.ExecuteReader();

        var animals = new List<Animals>();

        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");

        while (reader.Read())
        {
            animals.Add(new Animals()
            { 
                IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name = reader.GetString(nameOrdinal)
            });
        }
        
        return Ok();
    }
}