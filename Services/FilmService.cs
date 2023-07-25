using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFilms.DAO;
using WebFilms.Models;

namespace WebFilms.Services
{
    public class FilmService
    {
        private readonly DAOFilm mDao = new DAOFilm();

        #region Film

        public List<CFilm> getFilm()
        {
            return mDao.getFilm();
        }

        public CFilm getFilmById(int id)
        {
            return mDao.getFilmById(id);
        }


        public bool addFilm(CFilm client)
        {
            return mDao.addFilm(client);
        }

        public bool updateFilm(CFilm client)
        {
            return mDao.updateFilm(client);
        }

        public bool deleteFilm(int Id)
        {
            return mDao.deleteFilm(Id);
        }

        #endregion

        #region Achat

        public List<CAchat> getAchat()
        {
            return mDao.getAchat();
        }

        public CAchat getAchatById(int id)
        {
            return mDao.getAchatById(id);
        }


        public bool addAchat(CAchat client)
        {
            return mDao.addAchat(client);
        }

        public bool updateAchat(CAchat client)
        {
            return mDao.updateAchat(client);
        }

        public bool deleteAchat(int Id)
        {
            return mDao.deleteAchat(Id);
        }

        #endregion
        
        #region Auteur

        public List<CAuteur> getAuteur()
        {
            return mDao.getAuteur();
        }

        public CAuteur getAuteurById(int id)
        {
            return mDao.getAuteurById(id);
        }


        public bool addAuteur(CAuteur client)
        {
            return mDao.addAuteur(client);
        }

        public bool updateAuteur(CAuteur client)
        {
            return mDao.updateAuteur(client);
        }

        public bool deleteAuteur(int Id)
        {
            return mDao.deleteAuteur(Id);
        }

        #endregion
        
        #region Categorie

        public List<CCategorie> getCategorie()
        {
            return mDao.getCategorie();
        }

        public CCategorie getCategorieById(int id)
        {
            return mDao.getCategorieById(id);
        }


        public bool addCategorie(CCategorie client)
        {
            return mDao.addCategorie(client);
        }

        public bool updateCategorie(CCategorie client)
        {
            return mDao.updateCategorie(client);
        }

        public bool deleteCategorie(int Id)
        {
            return mDao.deleteCategorie(Id);
        }

        #endregion

        #region Fournisseur

        public List<CFournisseur> getFournisseur()
        {
            return mDao.getFournisseur();
        }

        public CFournisseur getFournisseurById(int id)
        {
            return mDao.getFournisseurById(id);
        }


        public bool addFournisseur(CFournisseur client)
        {
            return mDao.addFournisseur(client);
        }

        public bool updateFournisseur(CFournisseur client)
        {
            return mDao.updateFournisseur(client);
        }

        public bool deleteFournisseur(int Id)
        {
            return mDao.deleteFournisseur(Id);
        }

        #endregion
        
        #region Livre

        public List<CLivre> getLivre()
        {
            return mDao.getLivre();
        }

        public CLivre getLivreById(int id)
        {
            return mDao.getLivreById(id);
        }


        public bool addLivre(CLivre client)
        {
            return mDao.addLivre(client);
        }

        public bool updateLivre(CLivre client)
        {
            return mDao.updateLivre(client);
        }

        public bool deleteLivre(int Id)
        {
            return mDao.deleteLivre(Id);
        }

        #endregion
        
        #region Site

        public List<CSite> getSite()
        {
            return mDao.getSite();
        }

        public CSite getSiteById(int id)
        {
            return mDao.getSiteById(id);
        }


        public bool addSite(CSite client)
        {
            return mDao.addSite(client);
        }

        public bool updateSite(CSite client)
        {
            return mDao.updateSite(client);
        }

        public bool deleteSite(int Id)
        {
            return mDao.deleteSite(Id);
        }

        #endregion

        #region Vente

        public List<CVente> getVente()
        {
            return mDao.getVente();
        }

        public CVente getVenteById(int id)
        {
            return mDao.getVenteById(id);
        }


        public bool addVente(CVente client)
        {
            return mDao.addVente(client);
        }

        public bool updateVente(CVente client)
        {
            return mDao.updateVente(client);
        }

        public bool deleteVente(int Id)
        {
            return mDao.deleteVente(Id);
        }

        #endregion

        #region Ville

        public List<CVille> getVille()
        {
            return mDao.getVille();
        }

        public CVille getVilleById(int id)
        {
            return mDao.getVilleById(id);
        }


        public bool addVille(CVille client)
        {
            return mDao.addVille(client);
        }

        public bool updateVille(CVille client)
        {
            return mDao.updateVille(client);
        }

        public bool deleteVille(int Id)
        {
            return mDao.deleteVille(Id);
        }

        #endregion
    }
}