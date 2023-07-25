using AttributeRouting.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebFilms.DAO;
using WebFilms.Models;
using WebFilms.Services;

using System.Web.Http.Cors;


namespace WebFilms.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {
        [DisableCors]
        public string XMLData(string id)
        {
            return "Your requested product" + id;
        }
    }


    public class FilmController : ApiController
    {
        private readonly DAOFilm mDao;
        private readonly FilmService mFilmServ;

        public FilmController()
        {
            mFilmServ = new FilmService();
        }


        #region Film

        [HttpGet]
        [HttpRoute("/getFilms")]
        public List<CFilm> getAllFilm()
        {
            try
            {
                
                return mFilmServ.getFilm();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [HttpRoute("/getFilmById")]
        public CFilm getFilmById(int id)
        {
            try
            {
                return mFilmServ.getFilmById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [HttpRoute("/addFilm")]
        public bool addFilm(CFilm Fm)
        {
            try
            {
                return mFilmServ.addFilm(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/updateFilm")]
        public bool updateFilm(CFilm Fm)
        {
            try
            {
                return mFilmServ.updateFilm(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/deleteFilm")]
        public bool deleteFilm(int idFm)
        {
            try
            {
                return mFilmServ.deleteFilm(idFm);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion

        #region Achat

        [HttpGet]
        [HttpRoute("/getAchat")]
        public List<CAchat> getAllAchat()
        {
            try
            {

                return mFilmServ.getAchat();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [HttpRoute("/getAchatById")]
        public CAchat getAchatById(int id)
        {
            try
            {
                return mFilmServ.getAchatById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [HttpRoute("/addAchat")]
        public bool addAchat(CAchat Fm)
        {
            try
            {
                return mFilmServ.addAchat(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/updateAchat")]
        public bool updateAchat(CAchat Fm)
        {
            try
            {
                return mFilmServ.updateAchat(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/deleteAchat")]
        public bool deleteAchat(int idFm)
        {
            try
            {
                return mFilmServ.deleteAchat(idFm);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion
        
        #region Auteur

        [HttpGet]
        [HttpRoute("/getAuteur")]
        public List<CAuteur> getAllAuteur()
        {
            try
            {

                return mFilmServ.getAuteur();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [HttpRoute("/getAuteurById")]
        public CAuteur getAuteurById(int id)
        {
            try
            {
                return mFilmServ.getAuteurById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [HttpRoute("/addAuteur")]
        public bool addAuteur(CAuteur Fm)
        {
            try
            {
                return mFilmServ.addAuteur(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/updateAuteur")]
        public bool updateAuteur(CAuteur Fm)
        {
            try
            {
                return mFilmServ.updateAuteur(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/deleteAuteur")]
        public bool deleteAuteur(int idFm)
        {
            try
            {
                return mFilmServ.deleteAuteur(idFm);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion
        
        #region Categorie

        [HttpGet]
        [HttpRoute("/getCategorie")]
        public List<CCategorie> getAllCategorie()
        {
            try
            {

                return mFilmServ.getCategorie();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [HttpRoute("/getCategorieById")]
        public CCategorie getCategorieById(int id)
        {
            try
            {
                return mFilmServ.getCategorieById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [HttpRoute("/addCategorie")]
        public bool addCategorie(CCategorie Fm)
        {
            try
            {
                return mFilmServ.addCategorie(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/updateCategorie")]
        public bool updateCategorie(CCategorie Fm)
        {
            try
            {
                return mFilmServ.updateCategorie(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/deleteCategorie")]
        public bool deleteCategorie(int idFm)
        {
            try
            {
                return mFilmServ.deleteCategorie(idFm);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion
        
        #region Fournisseur

        [HttpGet]
        [HttpRoute("/getFournisseur")]
        public List<CFournisseur> getAllFournisseur()
        {
            try
            {

                return mFilmServ.getFournisseur();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [HttpRoute("/getFournisseurById")]
        public CFournisseur getFournisseurById(int id)
        {
            try
            {
                return mFilmServ.getFournisseurById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [HttpRoute("/addFournisseur")]
        public bool addCategorie(CFournisseur Fm)
        {
            try
            {
                return mFilmServ.addFournisseur(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/updateFournisseur")]
        public bool updateFournisseur(CFournisseur Fm)
        {
            try
            {
                return mFilmServ.updateFournisseur(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/deleteFournisseur")]
        public bool deleteFournisseur(int idFm)
        {
            try
            {
                return mFilmServ.deleteFournisseur(idFm);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion
        
        #region Livre

        [HttpGet]
        [HttpRoute("/getLivre")]
        public List<CLivre> getAllLivre()
        {
            try
            {

                return mFilmServ.getLivre();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [HttpRoute("/getLivreById")]
        public CLivre getLivreById(int id)
        {
            try
            {
                return mFilmServ.getLivreById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [HttpRoute("/addLivre")]
        public bool addLivre(CLivre Fm)
        {
            try
            {
                return mFilmServ.addLivre(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/updateLivre")]
        public bool updateLivre(CLivre Fm)
        {
            try
            {
                return mFilmServ.updateLivre(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/deleteLivre")]
        public bool deleteLivre(int idFm)
        {
            try
            {
                return mFilmServ.deleteLivre(idFm);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion
        
        #region Site

        [HttpGet]
        [HttpRoute("/getSite")]
        public List<CSite> getAllSite()
        {
            try
            {

                return mFilmServ.getSite();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [HttpRoute("/getSiteById")]
        public CSite getSiteById(int id)
        {
            try
            {
                return mFilmServ.getSiteById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [HttpRoute("/addSite")]
        public bool addSite(CSite Fm)
        {
            try
            {
                return mFilmServ.addSite(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/updateSite")]
        public bool updateSite(CSite Fm)
        {
            try
            {
                return mFilmServ.updateSite(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/deleteSite")]
        public bool deleteSite(int idFm)
        {
            try
            {
                return mFilmServ.deleteSite(idFm);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion


        #region Ville

        [HttpGet]
        [HttpRoute("/getVille")]
        public List<CVille> getAllVille()
        {
            try
            {

                return mFilmServ.getVille();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [HttpRoute("/getVilleById")]
        public CVille getVilleById(int id)
        {
            try
            {
                return mFilmServ.getVilleById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [HttpRoute("/addVille")]
        public bool addVille(CVille Fm)
        {
            try
            {
                return mFilmServ.addVille(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/updateVille")]
        public bool updateVille(CVille Fm)
        {
            try
            {
                return mFilmServ.updateVille(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/deleteVille")]
        public bool deleteVille(int idFm)
        {
            try
            {
                return mFilmServ.deleteVille(idFm);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion
        
        #region Vente

        [HttpGet]
        [HttpRoute("/getVente")]
        public List<CVente> getAllVente()
        {
            try
            {

                return mFilmServ.getVente();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [HttpRoute("/getVenteById")]
        public CVente getVenteById(int id)
        {
            try
            {
                return mFilmServ.getVenteById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [HttpRoute("/addVente")]
        public bool addVente(CVente Fm)
        {
            try
            {
                return mFilmServ.addVente(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/updateVente")]
        public bool updateVente(CVente Fm)
        {
            try
            {
                return mFilmServ.updateVente(Fm);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [HttpRoute("/deleteVente")]
        public bool deleteVente(int idFm)
        {
            try
            {
                return mFilmServ.deleteVente(idFm);
            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion
    }
}