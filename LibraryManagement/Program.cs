
namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adesina");
            var dataSet = new DisconnectedArchiteture();
            dataSet.WriteToJson();
            Console.WriteLine("");
        }
    }
}
