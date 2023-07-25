using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebFilms.Models;

namespace WebFilms.DAO
{
    public class DAOFilm
    {
        private readonly string CONSTRING;
        private readonly DbProviderFactory mProvider = DbProviderFactories.GetFactory("System.Data.SqlClient");
        private IDbConnection mConnection;

        public DAOFilm()
        {
            try
            {
                CONSTRING = ConfigurationManager.ConnectionStrings["FilmCS"].ConnectionString;
            }
            catch(Exception ex)
            {

            }

          
        }
        public DAOFilm(string con)
        {
            CONSTRING = con;
        }

        #region Film

        public List<CFilm> getFilm()
        {
            var listPays = new List<CFilm>();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Film";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pays = new CFilm
                                {
                                    mNom = reader["Nom"] as string,
                                    mId = (int)reader["Id"],
                                  //  mIdCategorie = (int)reader["IdCategorie"],
                                    mRealisateur = reader["Realisateur"] as string,
                                   mDateCreation= (DateTime)reader["DateCreation"]
                                };

                                listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public CFilm getFilmById(int Id)
        {
            var listPays = new CFilm();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Film where Id=@Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               
                                    listPays.mNom = reader["Nom"] as string;
                                listPays.mId = (int)reader["Id"];
                              //  listPays.mIdCategorie = (int)reader["IdCategorie"];
                                listPays.mRealisateur = reader["Realisateur"] as string;
                                listPays.mDateCreation = (DateTime)reader["DateCreation"];
                             

                               // listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool addFilm(CFilm client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO Film
                        (Nom, Realisateur,DateCreation)
                        VALUES (@Nom, @Realisateur,@DateCreation)";
                        
                        command.Parameters.Add(new SqlParameter("Nom", client.mNom ?? ""));
                        command.Parameters.Add(new SqlParameter("Realisateur", client.mRealisateur ?? ""));
                        command.Parameters.Add(new SqlParameter("DateCreation", client.mDateCreation ));
                    //    command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie ));
                       
                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch(Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool updateFilm(CFilm client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE Film SET 
                        Nom = @Nom,Realisateur=@Realisateur,DateCreation=@DateCreation Id = @Id WHERE Id = @Id";

                        command.Parameters.Add(new SqlParameter("Id", client.mId));
                     //   command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie));
                        command.Parameters.Add(new SqlParameter("Nom", client.mNom ?? ""));
                        command.Parameters.Add(new SqlParameter("Realisateur", client.mRealisateur ?? ""));
                        command.Parameters.Add(new SqlParameter("DateCreation", client.mDateCreation ));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool deleteFilm(int Id)
        {
            bool res = false;
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return res;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DELETE FROM Film WHERE Id = @Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch(Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        #endregion

        #region Achat

        public List<CAchat> getAchat()
        {
            var listPays = new List<CAchat>();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Achat";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pays = new CAchat
                                {
                                    mNumFacture = reader["NumFacture"] as string,
                                    mId = (int)reader["Id"],
                                    mIdFournisseur = (int)reader["IdFournisseur"],
                                    mIdLivre = (int)reader["IdLivre"],
                                    mIdSite = (int)reader["IdSite"],
                                    mQuantite = (int)reader["Quantite"],
                                    mDateAchat = (DateTime)reader["DateAchat"] ,
                                    mDateCreation = (DateTime)reader["DateCreation"] ,
                                    mDateModification = (DateTime)reader["DateModification"]
                                };

                                listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public CAchat getAchatById(int Id)
        {
            var listPays = new CAchat();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Achat where Id=@Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                listPays.mNumFacture = reader["NumFacture"] as string;
                                listPays.mId = (int)reader["Id"];
                                listPays.mIdFournisseur = (int)reader["IdFournisseur"];
                                listPays.mIdLivre = (int)reader["IdLivre"];
                                listPays.mIdSite = (int)reader["IdSite"];
                                listPays.mQuantite = (int)reader["Quantite"];
                                listPays.mDateAchat = (DateTime)reader["DateAchat"];
                                listPays.mDateCreation = (DateTime)reader["DateCreation"];
                                listPays.mDateModification = (DateTime)reader["DateModification"];


                                // listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool addAchat(CAchat client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO Achat
                        (IdFournisseur,IdLivre,IdSite,NumFacture,Quantite,DateAchat,DateCreation,DateModification)
                        VALUES (@IdFournisseur, @IdLivre,@IdSite,@NumFacture,@Quantite,@DateAchat,@DateCreation,@DateModification)";
                      
                        command.Parameters.Add(new SqlParameter("IdFournisseur", client.mIdFournisseur));
                        command.Parameters.Add(new SqlParameter("IdLivre", client.mIdLivre));
                        command.Parameters.Add(new SqlParameter("IdSite", client.mIdSite));
                        command.Parameters.Add(new SqlParameter("NumFacture", client.mNumFacture ?? ""));
                        command.Parameters.Add(new SqlParameter("Quantite", client.mQuantite));
                        command.Parameters.Add(new SqlParameter("DateAchat", client.mDateAchat));
                        command.Parameters.Add(new SqlParameter("DateCreation", client.mDateCreation));
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));
                    

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool updateAchat(CAchat client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE Achat SET 
                        IdFournisseur = @IdFournisseur,IdLivre=@IdLivre,IdSite=@IdSite, NumFacture = @NumFacture,Quantite=@Quantite,DateAchat=@DateAchat,DateCreation=@DateCreation,DateModification=@DateModification WHERE Id = @Id";

                        command.Parameters.Add(new SqlParameter("Id", client.mId));
                        command.Parameters.Add(new SqlParameter("IdFournisseur", client.mIdFournisseur));
                        command.Parameters.Add(new SqlParameter("IdLivre", client.mIdLivre));
                        command.Parameters.Add(new SqlParameter("IdSite", client.mIdSite));

                        command.Parameters.Add(new SqlParameter("NumFacture", client.mNumFacture ?? ""));
                        command.Parameters.Add(new SqlParameter("Quantite", client.mQuantite));
                        command.Parameters.Add(new SqlParameter("DateAchat", client.mDateAchat));
                        command.Parameters.Add(new SqlParameter("DateCreation", client.mDateCreation));
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));


                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool deleteAchat(int Id)
        {
            bool res = false;
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return res;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DELETE FROM Achat WHERE Id = @Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        #endregion
        
        #region Auteur

        public List<CAuteur> getAuteur()
        {
            var listPays = new List<CAuteur>();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Auteur";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pays = new CAuteur
                                {
                                    mId = (int)reader["Id"],
                                    mNom = reader["Nom"] as string,
                                    mPrenom = reader["Prenom"] as string,
                                    mEmail = reader["Email"] as string,
                                    mImage = reader["Image"] as string,
                                    mTelephone = reader["Telephone"] as string,
                                    mGenre = (int)reader["Genre"],
                                      mDateNaissance = (DateTime)reader["DateNaissance"] ,
                                    mDateCreation = (DateTime)reader["DateCreation"] ,
                                     mDateModification = (DateTime)reader["DateModification"]
                                };

                                listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public CAuteur getAuteurById(int Id)
        {
            var listPays = new CAuteur();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Auteur where Id=@Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                listPays.mNom = reader["Nom"] as string;
                                listPays.mPrenom = reader["Prenom"] as string;
                                listPays.mEmail = reader["Email"] as string;
                                listPays.mImage = reader["Image"] as string;
                                listPays.mTelephone = reader["Telephone"] as string;
                                listPays.mId = (int)reader["Id"];
                                listPays.mGenre = (int)reader["Genre"];

                                listPays.mDateNaissance = (DateTime)reader["DateNaissance"];
                                listPays.mDateCreation = (DateTime)reader["DateCreation"];
                                listPays.mDateModification = (DateTime)reader["DateModification"];

                              

                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool addAuteur(CAuteur client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO Auteur
                        (Nom,Prenom,Genre,DateNaissance,Email,Image,Telephone,DateCreation,DateModification)
                        VALUES (Nom,Prenom,Genre,DateNaissance,Email,Image,Telephone,DateCreation,DateModification)";
                        

                        command.Parameters.Add(new SqlParameter("Nom", client.mNom ?? ""));
                        command.Parameters.Add(new SqlParameter("Prenom", client.mPrenom ?? ""));
                        command.Parameters.Add(new SqlParameter("Genre", client.mGenre));
                        command.Parameters.Add(new SqlParameter("DateNaissance", client.mDateNaissance));
                        command.Parameters.Add(new SqlParameter("Email", client.mEmail ?? ""));
                        command.Parameters.Add(new SqlParameter("Image", client.mImage ?? ""));
                        command.Parameters.Add(new SqlParameter("Telephone", client.mTelephone ?? ""));
                        command.Parameters.Add(new SqlParameter("DateCreation", client.mDateCreation));
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));


                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool updateAuteur(CAuteur client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE Auteur SET 
                        Nom = @Nom,Prenom=@Prenom,Genre=@Genre, DateNaissance = @DateNaissance,Email = @Email,Image=@Image,Telephone=@Telephone, DateModification = @DateModification WHERE Id = @Id";
                        
                        command.Parameters.Add(new SqlParameter("Id", client.mId));
                 
                        command.Parameters.Add(new SqlParameter("Nom", client.mNom ?? ""));
                        command.Parameters.Add(new SqlParameter("Prenom", client.mPrenom ?? ""));
                        command.Parameters.Add(new SqlParameter("Genre", client.mGenre));
                        command.Parameters.Add(new SqlParameter("DateNaissance", client.mDateNaissance));
                        command.Parameters.Add(new SqlParameter("Email", client.mEmail ?? ""));
                        command.Parameters.Add(new SqlParameter("Image", client.mImage ?? ""));
                        command.Parameters.Add(new SqlParameter("Telephone", client.mTelephone ?? ""));
                        command.Parameters.Add(new SqlParameter("DateCreation", client.mDateCreation));
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));


                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool deleteAuteur(int Id)
        {
            bool res = false;
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return res;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DELETE FROM Auteur WHERE Id = @Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        #endregion
        
        #region Categorie

        public List<CCategorie> getCategorie()
        {
            var listPays = new List<CCategorie>();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Categorie";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pays = new CCategorie
                                {
                                    mLibelle = reader["Libelle"] as string,
                                    mId = (int)reader["Id"],
                                    mDateCreation = (DateTime)reader["DateCreation"],
                                    mDateModification = (DateTime)reader["DateModification"]
                                };

                                listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public CCategorie getCategorieById(int Id)
        {
            var listPays = new CCategorie();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Categorie where Id=@Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                listPays.mLibelle = reader["Nom"] as string;
                                listPays.mId = (int)reader["Id"];
                                //  listPays.mIdCategorie = (int)reader["IdCategorie"];
                             
                                listPays.mDateCreation = (DateTime)reader["DateCreation"];
                                listPays.mDateModification = (DateTime)reader["DateModification"];


                                // listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool addCategorie(CCategorie client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO Categorie
                        (Libelle,DateModification)
                        VALUES (@Libelle,@DateModification)";

                        command.Parameters.Add(new SqlParameter("Libelle", client.mLibelle ?? ""));
              
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));
                        //    command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie ));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool updateCategorie(CCategorie client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE Categorie SET 
                        Libelle = @Libelle,DateModification=@DateModification Id = @Id WHERE Id = @Id";

                        command.Parameters.Add(new SqlParameter("Id", client.mId));
                        //   command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie));
                        command.Parameters.Add(new SqlParameter("Libelle", client.mLibelle ?? ""));
                       
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool deleteCategorie(int Id)
        {
            bool res = false;
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return res;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DELETE FROM Categorie WHERE Id = @Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        #endregion
        
        #region Fournisseur

        public List<CFournisseur> getFournisseur()
        {
            var listPays = new List<CFournisseur>();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Fournisseur";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pays = new CFournisseur
                                {
                                    mId = (int)reader["Id"],
                                    mLibelle = reader["Libelle"] as string,
                                    mAdresse = reader["Adresse"] as string,
                                    mCode = reader["Code"] as string,
                                    mSiteWeb = reader["SiteWeb"] as string,
                                    mTelephone = reader["Telephone"] as string,
                          
                                    mDateCreation = (DateTime)reader["DateCreation"],
                                    mDateModification = (DateTime)reader["DateModification"]
                                };

                                listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public CFournisseur getFournisseurById(int Id)
        {
            var listPays = new CFournisseur();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Fournisseur where Id=@Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                listPays.mAdresse = reader["Adresse"] as string;
                                listPays.mCode = reader["Code"] as string;
                                listPays.mLibelle = reader["Libelle"] as string;
                                listPays.mSiteWeb = reader["SiteWeb"] as string;
                                listPays.mTelephone = reader["Telephone"] as string;
                                listPays.mId = (int)reader["Id"];
                           
                                listPays.mDateCreation = (DateTime)reader["DateCreation"];
                                listPays.mDateModification = (DateTime)reader["DateModification"];



                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool addFournisseur(CFournisseur client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO Fournisseur
                        (Code,Libelle,Telephone,Adresse,SiteWeb,DateCreation,DateModification)
                        VALUES (Code,Libelle,Telephone,Adresse,SiteWeb,DateCreation,DateModification)";


                        command.Parameters.Add(new SqlParameter("Nom", client.mCode ?? ""));
                        command.Parameters.Add(new SqlParameter("Prenom", client.mLibelle ?? ""));
                        command.Parameters.Add(new SqlParameter("Telephone", client.mTelephone ?? ""));
                        command.Parameters.Add(new SqlParameter("Adresse", client.mAdresse ?? ""));
                        command.Parameters.Add(new SqlParameter("SiteWeb", client.mSiteWeb ?? ""));
                        command.Parameters.Add(new SqlParameter("DateCreation", client.mDateCreation));
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));


                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool updateFournisseur(CFournisseur client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE Fournisseur SET 
                        Code = @Code,Libelle=@Libelle,Telephone=@Telephone, Adresse = @Adresse,SiteWeb = @SiteWeb, DateModification = @DateModification WHERE Id = @Id";

                        

                       command.Parameters.Add(new SqlParameter("Id", client.mId));

                        command.Parameters.Add(new SqlParameter("Code", client.mCode ?? ""));
                        command.Parameters.Add(new SqlParameter("Libelle", client.mLibelle ?? ""));
                        command.Parameters.Add(new SqlParameter("Telephone", client.mTelephone ?? ""));
                        command.Parameters.Add(new SqlParameter("Adresse", client.mAdresse ?? ""));
                        command.Parameters.Add(new SqlParameter("SiteWeb", client.mSiteWeb ?? ""));
               
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));


                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool deleteFournisseur(int Id)
        {
            bool res = false;
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return res;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DELETE FROM Fournisseur WHERE Id = @Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        #endregion
        
        #region Livre

        public List<CLivre> getLivre()
        {
            var listPays = new List<CLivre>();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Livre";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pays = new CLivre
                                {
                                    mTitre = reader["Titre"] as string,
                                    mId = (int)reader["Id"],
                                    mIdAuteur = (int)reader["IdAuteur"],
                                    mIdCategorie = (int)reader["IdCategorie"],
                                    mDateCreation = (DateTime)reader["DateCreation"],
                                    mDateModification = (DateTime)reader["DateModification"]
                                };

                                listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public CLivre getLivreById(int Id)
        {
            var listPays = new CLivre();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Livre where Id=@Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                listPays.mTitre = reader["Titre"] as string;
                                listPays.mId = (int)reader["Id"];
                                listPays.mIdAuteur = (int)reader["IdAuteur"];
                                listPays.mIdCategorie = (int)reader["IdCategorie"];
                                //  listPays.mIdCategorie = (int)reader["IdCategorie"];

                                listPays.mDateCreation = (DateTime)reader["DateCreation"];
                                listPays.mDateModification = (DateTime)reader["DateModification"];


                                // listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool addLivre(CLivre client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO Livre
                        (IdAuteur,IdCategorie,Titre,DateModification)
                        VALUES (@IdAuteur,@IdCategorie,@Titre,@DateModification)";

                        command.Parameters.Add(new SqlParameter("IdAuteur", client.mIdAuteur));
                        command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie));
                        command.Parameters.Add(new SqlParameter("Titre", client.mTitre ?? ""));

                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));
                        //    command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie ));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool updateLivre(CLivre client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE Livre SET 
                        IdAuteur = @IdAuteur,IdCategorie=@IdCategorie,Titre=@Titre,DateModification=@DateModification Id = @Id WHERE Id = @Id";

                        command.Parameters.Add(new SqlParameter("Id", client.mId));
                        //   command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie));
                        command.Parameters.Add(new SqlParameter("IdAuteur", client.mIdAuteur));
                        command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie));
                        command.Parameters.Add(new SqlParameter("Titre", client.mTitre ?? ""));

                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool deleteLivre(int Id)
        {
            bool res = false;
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return res;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DELETE FROM Livre WHERE Id = @Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        #endregion

        #region Site

        public List<CSite> getSite()
        {
            var listPays = new List<CSite>();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Site";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pays = new CSite
                                {
                                    mLibelle = reader["Libelle"] as string,
                                    mId = (int)reader["Id"],
                                    mIdVille = (int)reader["IdVille"],
                                    mDateCreation = (DateTime)reader["DateCreation"],
                                    mDateModification = (DateTime)reader["DateModification"]
                                };

                                listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public CSite getSiteById(int Id)
        {
            var listPays = new CSite();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Site where Id=@Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                listPays.mLibelle = reader["Libelle"] as string;
                                listPays.mId = (int)reader["Id"];
                                listPays.mIdVille = (int)reader["IdVille"];
                                //  listPays.mIdCategorie = (int)reader["IdCategorie"];

                                listPays.mDateCreation = (DateTime)reader["DateCreation"];
                                listPays.mDateModification = (DateTime)reader["DateModification"];


                                // listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool addSite(CSite client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO Site
                        (Libelle,IdVille,DateModification)
                        VALUES (@Libelle,@IdVille,@DateModification)";

                        command.Parameters.Add(new SqlParameter("Libelle", client.mLibelle ?? ""));
                        command.Parameters.Add(new SqlParameter("IdVille", client.mIdVille));

                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));
                        //    command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie ));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool updateSite(CSite client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE Site SET 
                        Libelle = @Libelle,IdVille=@IdVille,DateModification=@DateModification Id = @Id WHERE Id = @Id";

                        command.Parameters.Add(new SqlParameter("Id", client.mId));
                        command.Parameters.Add(new SqlParameter("IdVille", client.mIdVille));
                        //   command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie));
                        command.Parameters.Add(new SqlParameter("Libelle", client.mLibelle ?? ""));

                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool deleteSite(int Id)
        {
            bool res = false;
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return res;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DELETE FROM Site WHERE Id = @Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        #endregion


        #region Vente

        public List<CVente> getVente()
        {
            var listPays = new List<CVente>();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Vente";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pays = new CVente
                                {
                                    mNumFacture = reader["NumFacture"] as string,
                                    mId = (int)reader["Id"],
                                    mQuantite = (int)reader["Quantite"],
                                    mIdLivre = (int)reader["IdLivre"],
                                    mIdSite = (int)reader["IdSite"],
                                      mDateCreation = (DateTime)reader["DateCreation"] ,
                                    mDateVente = (DateTime)reader["DateVente"] ,
                                     mDateModification = (DateTime)reader["DateModification"]
                                };

                                listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public CVente getVenteById(int Id)
        {
            var listPays = new CVente();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Vente where Id=@Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                listPays.mNumFacture = reader["NumFacture"] as string;
                                listPays.mId = (int)reader["Id"];
                                listPays.mQuantite = (int)reader["Quantite"];
                                listPays.mIdLivre = (int)reader["IdLivre"];
                                listPays.mIdSite = (int)reader["IdSite"];
                                listPays.mDateCreation = (DateTime)reader["DateCreation"];
                                listPays.mDateModification = (DateTime)reader["DateModification"];
                                listPays.mDateVente = (DateTime)reader["DateVente"];


                                // listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool addVente(CVente client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO Vente
                        (IdLivre,IdSite,NumFacture,Quantite,DateVente,DateCreation,DateModification)
                        VALUES (@IdLivre,@IdSite,@NumFacture,@Quantite,@DateVente,@DateCreation,@DateModification)";

                        command.Parameters.Add(new SqlParameter("IdLivre", client.mIdLivre));
                        command.Parameters.Add(new SqlParameter("IdSite", client.mIdSite));
                        command.Parameters.Add(new SqlParameter("NumFacture", client.mNumFacture ?? ""));
                        command.Parameters.Add(new SqlParameter("Quantite", client.mQuantite));
                        command.Parameters.Add(new SqlParameter("DateVente", client.mDateVente));
                        command.Parameters.Add(new SqlParameter("DateCreation", client.mDateCreation));
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool updateVente(CVente client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE Vente SET 
                       IdLivre=@IdLivre,IdSite=@IdSite, NumFacture= @NumFacture,Quantite=@Quantite,DateVente=@DateVente,DateCreation=@DateCreation,DateModification=@DateModification  WHERE Id = @Id";

                        
                        command.Parameters.Add(new SqlParameter("Id", client.mId));
                        command.Parameters.Add(new SqlParameter("IdLivre", client.mIdLivre));
                        command.Parameters.Add(new SqlParameter("IdSite", client.mIdSite));

                        command.Parameters.Add(new SqlParameter("NumFacture", client.mNumFacture ?? ""));
                        command.Parameters.Add(new SqlParameter("Quantite", client.mQuantite));
                        command.Parameters.Add(new SqlParameter("DateVente", client.mDateVente));
                        command.Parameters.Add(new SqlParameter("DateCreation", client.mDateCreation));
                        command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));


                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool deleteVente(int Id)
        {
            bool res = false;
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return res;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DELETE FROM Vente WHERE Id = @Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        #endregion


        #region Ville

        public List<CVille> getVille()
        {
            var listPays = new List<CVille>();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Ville";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pays = new CVille
                                {
                                    mLibelle = reader["Libelle"] as string,
                                    mId = (int)reader["Id"]
                                  
                                };

                                listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public CVille getVilleById(int Id)
        {
            var listPays = new CVille();
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return listPays;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();

                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"SELECT * from Site where Id=@Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                listPays.mLibelle = reader["Libelle"] as string;
                                listPays.mId = (int)reader["Id"];
                                //listPays.mIdVille = (int)reader["IdVille"];
                                ////  listPays.mIdCategorie = (int)reader["IdCategorie"];

                                //listPays.mDateCreation = (DateTime)reader["DateCreation"];
                                //listPays.mDateModification = (DateTime)reader["DateModification"];


                                // listPays.Add(pays);
                            }
                            return listPays;
                        }
                    }
                    catch (Exception ex)
                    {
                        return listPays;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool addVille(CVille client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"INSERT INTO Ville
                        (Libelle)
                        VALUES (@Libelle)";

                        command.Parameters.Add(new SqlParameter("Libelle", client.mLibelle ?? ""));
                    
                        //    command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie ));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool updateVille(CVille client)
        {
            bool res = false;

            using (mConnection = mProvider.CreateConnection())
            {
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UPDATE Ville SET 
                        Libelle = @Libelle WHERE Id = @Id";

                        command.Parameters.Add(new SqlParameter("Id", client.mId));
                        command.Parameters.Add(new SqlParameter("Libelle", client.mLibelle));
                        //   command.Parameters.Add(new SqlParameter("IdCategorie", client.mIdCategorie));
                        //command.Parameters.Add(new SqlParameter("Libelle", client.mLibelle ?? ""));

                        //command.Parameters.Add(new SqlParameter("DateModification", client.mDateModification));

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        public bool deleteVille(int Id)
        {
            bool res = false;
            using (mConnection = mProvider.CreateConnection())
            {
                if (mConnection == null) return res;
                mConnection.ConnectionString = CONSTRING;
                mConnection.Open();
                using (var command = mConnection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DELETE FROM Ville WHERE Id = @Id";

                        var licenceId = command.CreateParameter();
                        licenceId.ParameterName = "@Id";
                        licenceId.Value = Id;
                        command.Parameters.Add(licenceId);

                        command.ExecuteNonQuery();
                        res = true;

                        return res;
                    }
                    catch (Exception ex)
                    {
                        return res;
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
        }

        #endregion


    }
}