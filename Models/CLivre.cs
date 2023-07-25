using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilms.Models
{
    public class CLivre
    {
        public int mId { get; set; }
        public int mIdAuteur { get; set; }
        public int mIdCategorie { get; set; }
        public string mTitre { get; set; }

        public DateTime mDateCreation { get; set; }
        public DateTime mDateModification { get; set; }

        public CLivre()
        {
            mId = 0;
            mIdAuteur = 0;
            mIdCategorie = 0;
            mTitre = string.Empty;

            mDateCreation = new DateTime();
            mDateModification = new DateTime();

        }
    }
}