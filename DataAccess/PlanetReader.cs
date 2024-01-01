using System.Text.Json;

public class PlanetReader : IPlanetReader
{
    private IApiDataReader _apiDataReader;
    private readonly IApiDataReader _mockDataReader;

    public PlanetReader(IApiDataReader mockDataReader,IApiDataReader apiDataReader)
    {
        _mockDataReader = mockDataReader;
        _apiDataReader = apiDataReader;
    }

    public async Task<IEnumerable<Planet>> Read(string add, string uri)
    {
             string? json = null;
           
             json = await _apiDataReader.Read(add, uri);

             json ??= await _mockDataReader.Read(add, uri);//if json is null switch to mock data

             Root? root = JsonSerializer.Deserialize<Root>(json);
             var planets = ToPlanet(root);
             return planets;
    }


    private static IEnumerable<Planet> ToPlanet(Root? root)
    {
        if(root is null)
        {
            throw new ArgumentNullException(nameof(root));

        }
      //converting each planet data to Planet
        return root.results.Select(planetData => (Planet)planetData);
        
    }

}








//public record Annotations(
//    [property: JsonPropertyName("source_name")] string source_name,
//    [property: JsonPropertyName("source_description")] string source_description,
//    [property: JsonPropertyName("dataset_name")] string dataset_name,
//    [property: JsonPropertyName("dataset_link")] string dataset_link,
//    [property: JsonPropertyName("table_id")] string table_id,
//    [property: JsonPropertyName("topic")] string topic,
//    [property: JsonPropertyName("subtopic")] string subtopic
//);

//public record Datum(
//    [property: JsonPropertyName("ID Nation")] string IDNation,
//    [property: JsonPropertyName("Nation")] string Nation,
//    [property: JsonPropertyName("ID Year")] int IDYear,
//    [property: JsonPropertyName("Year")] string Year,
//    [property: JsonPropertyName("Population")] int Population,
//    [property: JsonPropertyName("Slug Nation")] string SlugNation
//    //[property: JsonPropertyName("IDNation")] string IDNation
//);

//public record Root(
//    [property: JsonPropertyName("data")] IReadOnlyList<Datum> data,
//    [property: JsonPropertyName("source")] IReadOnlyList<Source> source
//);

//public record Source(
//    [property: JsonPropertyName("measures")] IReadOnlyList<string> measures,
//    [property: JsonPropertyName("annotations")] Annotations annotations,
//    [property: JsonPropertyName("name")] string name,
//    [property: JsonPropertyName("substitutions")] IReadOnlyList<object> substitutions
//);

