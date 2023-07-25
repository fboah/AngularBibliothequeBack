using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilms.Models
{
    public class CFournisseur
    {
        public int mId { get; set; }
        public string mCode { get; set; }
        public string mLibelle { get; set; }
        public string mAdresse { get; set; }
        public string mSiteWeb { get; set; }
        public string mTelephone { get; set; }

        public DateTime mDateCreation { get; set; }
        public DateTime mDateModification { get; set; }

        public CFournisseur()
        {
            mId = 0;
            mLibelle = string.Empty;
            mCode = string.Empty;
            mAdresse = string.Empty;
            mSiteWeb = string.Empty;
            mTelephone = string.Empty;
            mDateCreation = new DateTime();
            mDateModification = new DateTime();

        }
    }
}