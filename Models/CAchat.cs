using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilms.Models
{
    public class CAchat
    {

        public int mId { get; set; }
        public int mIdLivre { get; set; }
        public int mIdFournisseur { get; set; }
        public int mIdSite { get; set; }
        public string mNumFacture { get; set; }
        public int mQuantite { get; set; }
        public DateTime mDateAchat { get; set; }
        public DateTime mDateCreation { get; set; }
        public DateTime mDateModification { get; set; }

        public CAchat()
        {
            mId = 0;
            mIdLivre = 0;
            mIdFournisseur = 0;
            mIdSite = 0;
            mNumFacture = string.Empty;
            mQuantite = 0;
            mDateAchat = new DateTime();
            mDateCreation = new DateTime();
            mDateModification = new DateTime();


        }
    }
}