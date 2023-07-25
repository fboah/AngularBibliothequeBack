using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilms.Models
{
    public class CCategorie
    {
        public int mId { get; set; }
        public string mLibelle { get; set; }
        public string mDescription { get; set; }
        public DateTime mDateCreation { get; set; }
        public DateTime mDateModification { get; set; }

        public CCategorie()
        {
            mId = 0;
            mLibelle = string.Empty;
            mDescription = string.Empty;
            mDateCreation = new DateTime();
            mDateModification = new DateTime();


        }
    }
}