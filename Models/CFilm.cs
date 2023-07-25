using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilms.Models
{
    public class CFilm
    {
        public int mId {get; set; }
      //  public int mIdCategorie { get; set; }
        public string mNom {get; set; }
        public string mRealisateur {get; set; }
        public DateTime mDateCreation { get; set; }
      


        public CFilm()
        {
            mId = 0;
          //  mIdCategorie = 0;
            mNom = string.Empty;
            mRealisateur = string.Empty;
            mDateCreation = new DateTime();

        }

    }

    
}