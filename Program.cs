using linq;
internal class Program
{
    private static void Main(string[] args)
    {
        LinqQueries queries = new LinqQueries();
        //ImprimirValores(queries.Allcolection());
        /* bool rest = queries.ValidarAño();
        if (rest == true) 
        { ImprimirValores(queries.Libros2005());  }
        else
        {
            Console.WriteLine("No Hya ningun libro publicado en 2005");
        } */
        ImprimirValores(queries.Join());


    }


    private static void ImprimirValores(IEnumerable<Books> books)
    {
        int registros = 0;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0,-70}{1,7}{2,20}", "Titulo", "N.Pgainas", "Fecha publicacion");
        foreach (Books book in books)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            registros += 1;
            Console.WriteLine("{0,-70}{1,7}{2,20}", book.Title, book.PageCount, book.PublishedDate);

        }
    }
}