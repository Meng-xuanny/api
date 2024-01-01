public class StarWarsApp
{
    private readonly IPlanetReader _planetReader;
    private readonly IConsoleInteractor _consoleInteractor;
    private readonly IPlanetSelector _selector;
    private readonly IapiDataPrinter _apiDataPrinter;


    public StarWarsApp(IPlanetReader planetReader, 
        IapiDataPrinter apiDataPrinter, IConsoleInteractor consoleInteractor, IPlanetSelector selector)
    {
        _planetReader = planetReader;
        _apiDataPrinter = apiDataPrinter;
        _consoleInteractor = consoleInteractor;
        _selector = selector;
    }

    public async Task Run(string add, string uri)
    {
       var planets=await _planetReader.Read(add, uri);

        _apiDataPrinter.TablePrint(planets);

        _consoleInteractor.Prompt("The statistics of which property would you like to see?\npopulation\ndiameter\nsurface water\n");

        string userSelection=_consoleInteractor.ReadFromUser();
        if(userSelection is not null)
        {
            _selector.Select(userSelection,planets);

        }


        Console.WriteLine("press any key to exit.");
        Console.ReadKey();

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

