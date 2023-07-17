using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignMVC.ViewModel
{
    public class PagerViewModel
    {
        public PagerViewModel()
        {
            Numeric = true;
            Info = true;
            PreviousNext = true;
        }
        public bool Input { get; set; }

        public bool Numeric { get; set; }

        public bool Info { get; set; }

        public bool PreviousNext { get; set; }

        public bool Refresh { get; set; }

        public bool PageSizes { get; set; }
    }
}