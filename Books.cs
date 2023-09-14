using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linq
{
    public class Books
    {
        string  title;
        int pageCount;
        DateOnly publisheDate;
        string  status;
        string[] authors;
        string[] categories;

    public string Title { get => title; set => title = value; }
    public int PageCount { get => pageCount; set => pageCount = value; }
    public DateOnly PublishedDate { get => publisheDate; set => publisheDate = value; }
    public string Status { get => status; set => status = value; }
    public string[] Authors { get => authors; set => authors = value; }
    public string[] Categories { get => categories; set => categories = value; }
}
}