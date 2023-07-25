using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilms.Models
{
    public class CVille
    {

        public int mId { get; set; }
        public string mLibelle { get; set; }


        public CVille()
        {
            mId = 0;
            mLibelle = string.Empty;

        }
    }
}