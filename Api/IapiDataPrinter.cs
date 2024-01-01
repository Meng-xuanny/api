public interface IapiDataPrinter
{
    void Print(IEnumerable<Planet> planet);
    void TablePrint<T>(IEnumerable<T> items);
}