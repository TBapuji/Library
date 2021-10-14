using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }

        //TODO - change this totally
        public WordItem[] Words { get; set; }
    }
}