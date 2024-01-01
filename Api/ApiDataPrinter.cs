public class ApiDataPrinter : IapiDataPrinter
{
    public void Print(IEnumerable<Planet> planets)
    {
        foreach (var planetData in planets)
        {
            Console.WriteLine($"Name: {planetData.Name}, Diameter: {planetData.Diameter}, SurfaceWater: {planetData.SurfaceWater}, Population: {planetData.Population}.");
        }
    }

    public void TablePrint<T>(IEnumerable<T> items)
    {
        const int columnWidth = 15;
        var properties = typeof(T).GetProperties();

        foreach(var property in properties)
        {
            Console.Write($"{{0,-{columnWidth}}}|",property.Name);
        }
        Console.WriteLine();

        Console.WriteLine(new string('-', properties.Length * (columnWidth + 1)));
        Console.WriteLine();

        foreach(var item in items)
        {
            foreach(var property in properties)
            {
                Console.Write($"{{0,-{columnWidth}}}|", property.GetValue(item));

            }
            Console.WriteLine();
        }
        Console.WriteLine();

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

