using linq;
public class LinqQueries
{
    List<Books> lstBooks = new List<Books>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.lstBooks = System.Text.Json.JsonSerializer
            .Deserialize<List<Books>>(json, new System.Text.Json.JsonSerializerOptions()
            { PropertyNameCaseInsensitive = true }) ?? new List<Books>();
        }
    }

    public IEnumerable<Books> Allcolection()
    {
        return lstBooks;
    }
    public IEnumerable<Books> LibrosDespuesDe2000()
    {
        return from book in lstBooks
               where book.PublishedDate.Year > 2000
               select book;
    }
    public IEnumerable<Books> OnlyAndroid()
    {
        return from book in lstBooks where book.Title.Contains("Android") select book;
    }

    public IEnumerable<Books> LibrosPage()
    {
        return from book in lstBooks
               where book.PageCount > 250
        && (book.Title ?? String.Empty).Contains("in Action")
               select book;
    }

    public bool ValidarStatus()
    {
        return lstBooks.All(book => book.Status != String.Empty);
    }
    public bool ValidarAño()
    {
        return lstBooks.Any(book => book.PublishedDate.Year == 2005);

    }
    public IEnumerable<Books> Libros2005()
    {
        return from book in lstBooks where book.PublishedDate.Year > 2005 select book;

    }
    public IEnumerable<Books> Python()
    {
        return from book in lstBooks where book.Categories.Contains("Python") select book;
    }
    public IEnumerable<Books> Java()
    {
        return from book in lstBooks where book.Categories.Contains("Java") orderby book.Title select book;
    }

    public IEnumerable<Books> OrdenDescendiente()
    {
        return from book in lstBooks where book.PageCount > 450 orderby book.PageCount descending select book;
    }

    public IEnumerable<Books> take()
    {
        return lstBooks
      .Where(book => book.Categories.Contains("Java"))
      .OrderByDescending(book => book.PublishedDate)
      .Take(3);
    }
    public IEnumerable<Books> skip()
    {
        return lstBooks
        .Where(book => book.PageCount > 400)
        .Take(4)
        .Skip(2);
    }
    public IEnumerable<Books> select()
    {
        return lstBooks.Take(3)
        .Select(book => new Books { Title = book.Title, PageCount = book.PageCount });
    }

    /* public int contador(){
      return lstBooks
      .Count(book=>book.PageCount>=200 && book.PageCount<=500);
    }
    public long longitud(){
      return lstBooks
      .LongCount(book=>book.PageCount>=200 && book.PageCount<=500);
    } */
    /*  public DateOnly  Minim(){
         return lstBooks.Min(book=>book.PublishedDate);
     } */
    public IEnumerable<Books> Minimo()
    {
        var Fecha = lstBooks.Min(libro => libro.PublishedDate);
        return lstBooks.Where(libro => libro.PublishedDate == Fecha);
    }
    public IEnumerable<Books> Maximo()
    {
        var Fecha = lstBooks.Max(libro => libro.PublishedDate);
        return lstBooks.Where(libro => libro.PublishedDate == Fecha);
    }
    public Books MayorCero()
    {
        IEnumerable<Books> enumerable = lstBooks.Where(book => book.PageCount > 0);
        return enumerable.MinBy(myBook => myBook.PageCount) ?? new Books();
    }
    public Books FechaReciente()
    {
        return lstBooks
        .MaxBy(myBook => myBook.PublishedDate) ?? new Books();
    }
    public int Sum()
    {
        return lstBooks.Where(book => book.PageCount > 0 && book.PageCount <= 500)
        .Sum(myBook => myBook.PageCount);
    }

    public string Titulo2015()
    {
        return lstBooks.Where(book => book.PublishedDate.Year > 2015)
        .Aggregate("", (titulos, next) =>
        {
            if (titulos != string.Empty)
            {
                titulos += "-" + next.Title;
            }
            else
            {
                titulos += next.Title;
            }
            return titulos;
        });
    }

    public double Average()
    {
        return lstBooks.Average(book => (book.Title ?? string.Empty).Length);

    }

    public IEnumerable<IGrouping<int, Books>> agrupacion()
    {
        return lstBooks.Where(book => book.PublishedDate.Year >= 2000)
        .GroupBy(mybook => mybook.PublishedDate.Year);
    }
    public ILookup<char,Books> Libros(){
        return lstBooks.ToLookup(book=>book.Title?[0]??default(char),book=>book);
    }
    public IEnumerable<Books> Join(){
        var Join1=lstBooks.Where(b=>b.PublishedDate.Year>2005);
        var Join2=lstBooks.Where(b=>b.PageCount>500);
        return Join1.Join(Join2,p=>p.Title,x=>x.Title,(p,x)=>p);
    }
}
