using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilms.Models
{
    public class CAuteur
    {

        public int mId { get; set; }
        public string mNom { get; set; }
        public string mPrenom { get; set; }
        public int mGenre { get; set; }
        public string mTelephone { get; set; }
        public string mEmail { get; set; }
        public string mImage { get; set; }
        public DateTime mDateNaissance { get; set; }
        public DateTime mDateCreation { get; set; }
        public DateTime mDateModification { get; set; }

        public CAuteur()
        {
            mId = 0;
            mNom = string.Empty;
            mPrenom = string.Empty;
            mTelephone = string.Empty;
            mEmail = string.Empty;
            mImage = string.Empty;
            mGenre = 0;
            mDateNaissance = new DateTime();
            mDateCreation = new DateTime();
            mDateModification = new DateTime();


        }
    }
}