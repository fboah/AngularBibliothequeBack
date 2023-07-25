using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilms.Models
{
    public class CSite
    {
        public int mId { get; set; }
        public int mIdVille { get; set; }
        public string mLibelle { get; set; }
        public DateTime mDateCreation { get; set; }
        public DateTime mDateModification { get; set; }

        public CSite()
        {
            mId = 0;
            mIdVille = 0;
            mLibelle = string.Empty;

            mDateCreation = new DateTime();
            mDateModification = new DateTime();

        }

    }
}