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

     public IEnumerable <Books> take(){
          return lstBooks
        .Where(book => book.Categories.Contains("Java"))
        .OrderByDescending(book => book.PublishedDate)
        .Take(3);
      } 
      public IEnumerable <Books> skip(){
        return lstBooks
        .Where(book => book.PageCount>400)
        .Take(4)
        .Skip(2);
      }
      public IEnumerable <Books> select(){
        return lstBooks.Take(3)
        .Select(book=> new Books{Title=book.Title,PageCount=book.PageCount});
      }

      /* public int contador(){
        return lstBooks
        .Count(book=>book.PageCount>=200 && book.PageCount<=500);
      }
      public long longitud(){
        return lstBooks
        .LongCount(book=>book.PageCount>=200 && book.PageCount<=500);
      } */

      
}
