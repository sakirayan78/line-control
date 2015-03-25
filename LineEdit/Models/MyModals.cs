using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LineEdit.Models
{ 
    [ValidateInput(false)] 
    public class MyModals
    {
        
        public string content { get; set; }
    }

    public class Post
    {
        public string Title { get; set; }
        // ...
    }
}