using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AnimalController:ControllerBase
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
        while (reader.Read())
        {
            
        }
        
        return Ok();
    }
}