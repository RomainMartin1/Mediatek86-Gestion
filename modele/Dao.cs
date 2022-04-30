﻿using Mediatek86.metier;
using System.Collections.Generic;
using Mediatek86.bdd;
using System;
using System.Windows.Forms;

namespace Mediatek86.modele
{
    public static class Dao
    {

        private static readonly string server = "localhost";
        private static readonly string userid = "root";
        private static readonly string password = "";
        private static readonly string database = "mediatek86";
        private static readonly string connectionString = "server="+server+";user id="+userid+";password="+password+";database="+database+";SslMode=none";

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public static List<Categorie> GetAllGenres()
        {
            List<Categorie> lesGenres = new List<Categorie>();
            string req = "Select * from genre order by libelle";

            BddMySql curs = BddMySql.GetInstance(connectionString);
            curs.ReqSelect(req, null);

            while (curs.Read())
            {
                Genre genre = new Genre((string)curs.Field("id"), (string)curs.Field("libelle"));
                lesGenres.Add(genre);
            }
            curs.Close();
            return lesGenres;
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Collection d'objets Rayon</returns>
        public static List<Categorie> GetAllRayons()
        {
            List<Categorie> lesRayons = new List<Categorie>();
            string req = "Select * from rayon order by libelle";

            BddMySql curs = BddMySql.GetInstance(connectionString);
            curs.ReqSelect(req, null);

            while (curs.Read())
            {
                Rayon rayon = new Rayon((string)curs.Field("id"), (string)curs.Field("libelle"));
                lesRayons.Add(rayon);
            }
            curs.Close();
            return lesRayons;
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Collection d'objets Public</returns>
        public static List<Categorie> GetAllPublics()
        {
            List<Categorie> lesPublics = new List<Categorie>();
            string req = "Select * from public order by libelle";

            BddMySql curs = BddMySql.GetInstance(connectionString);
            curs.ReqSelect(req, null);

            while (curs.Read())
            {
                Public lePublic = new Public((string)curs.Field("id"), (string)curs.Field("libelle"));
                lesPublics.Add(lePublic);
            }
            curs.Close();
            return lesPublics;
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public static List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = new List<Livre>();
            string req = "Select l.id, l.ISBN, l.auteur, d.titre, d.image, l.collection, ";
            req += "d.idrayon, d.idpublic, d.idgenre, g.libelle as genre, p.libelle as public, r.libelle as rayon ";
            req += "from livre l join document d on l.id=d.id ";
            req += "join genre g on g.id=d.idGenre ";
            req += "join public p on p.id=d.idPublic ";
            req += "join rayon r on r.id=d.idRayon ";
            req += "order by titre ";

            BddMySql curs = BddMySql.GetInstance(connectionString);
            curs.ReqSelect(req, null);

            while (curs.Read())
            {
                string id = (string)curs.Field("id");
                string isbn = (string)curs.Field("ISBN");
                string auteur = (string)curs.Field("auteur");
                string titre = (string)curs.Field("titre");
                string image = (string)curs.Field("image");
                string collection = (string)curs.Field("collection");
                string idgenre = (string)curs.Field("idgenre");
                string idrayon = (string)curs.Field("idrayon");
                string idpublic = (string)curs.Field("idpublic");
                string genre = (string)curs.Field("genre");
                string lepublic = (string)curs.Field("public");
                string rayon = (string)curs.Field("rayon");
                Livre livre = new Livre(id, titre, image, isbn, auteur, collection, idgenre, genre, 
                    idpublic, lepublic, idrayon, rayon);
                lesLivres.Add(livre);
            }
            curs.Close();

            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public static List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = new List<Dvd>();
            string req = "Select l.id, l.duree, l.realisateur, d.titre, d.image, l.synopsis, ";
            req += "d.idrayon, d.idpublic, d.idgenre, g.libelle as genre, p.libelle as public, r.libelle as rayon ";
            req += "from dvd l join document d on l.id=d.id ";
            req += "join genre g on g.id=d.idGenre ";
            req += "join public p on p.id=d.idPublic ";
            req += "join rayon r on r.id=d.idRayon ";
            req += "order by titre ";

            BddMySql curs = BddMySql.GetInstance(connectionString);
            curs.ReqSelect(req, null);

            while (curs.Read())
            {
                string id = (string)curs.Field("id");
                int duree = (int)curs.Field("duree");
                string realisateur = (string)curs.Field("realisateur");
                string titre = (string)curs.Field("titre");
                string image = (string)curs.Field("image");
                string synopsis = (string)curs.Field("synopsis");
                string idgenre = (string)curs.Field("idgenre");
                string idrayon = (string)curs.Field("idrayon");
                string idpublic = (string)curs.Field("idpublic");
                string genre = (string)curs.Field("genre");
                string lepublic = (string)curs.Field("public");
                string rayon = (string)curs.Field("rayon");
                Dvd dvd = new Dvd(id, titre, image, duree, realisateur, synopsis, idgenre, genre,
                    idpublic, lepublic, idrayon, rayon);
                lesDvd.Add(dvd);
            }
            curs.Close();

            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public static List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = new List<Revue>();
            string req = "Select l.id, l.empruntable, l.periodicite, d.titre, d.image, l.delaiMiseADispo, ";
            req += "d.idrayon, d.idpublic, d.idgenre, g.libelle as genre, p.libelle as public, r.libelle as rayon ";
            req += "from revue l join document d on l.id=d.id ";
            req += "join genre g on g.id=d.idGenre ";
            req += "join public p on p.id=d.idPublic ";
            req += "join rayon r on r.id=d.idRayon ";
            req += "order by titre ";

            BddMySql curs = BddMySql.GetInstance(connectionString);
            curs.ReqSelect(req, null);

            while (curs.Read())
            {
                string id = (string)curs.Field("id");
                bool empruntable = (bool)curs.Field("empruntable");
                string periodicite = (string)curs.Field("periodicite");
                string titre = (string)curs.Field("titre");
                string image = (string)curs.Field("image");
                int delaiMiseADispo = (int)curs.Field("delaimiseadispo");
                string idgenre = (string)curs.Field("idgenre");
                string idrayon = (string)curs.Field("idrayon");
                string idpublic = (string)curs.Field("idpublic");
                string genre = (string)curs.Field("genre");
                string lepublic = (string)curs.Field("public");
                string rayon = (string)curs.Field("rayon");
                Revue revue = new Revue(id, titre, image, idgenre, genre,
                    idpublic, lepublic, idrayon, rayon, empruntable, periodicite, delaiMiseADispo);
                lesRevues.Add(revue);
            }
            curs.Close();

            return lesRevues;
        }

        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <returns>Liste d'objets Exemplaire</returns>
        public static List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            List<Exemplaire> lesExemplaires = new List<Exemplaire>();
            string req = "Select e.id, e.numero, e.dateAchat, e.photo, e.idEtat ";
            req += "from exemplaire e join document d on e.id=d.id ";
            req += "where e.id = @id ";
            req += "order by e.dateAchat DESC";
            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@id", idDocument}
                };

            BddMySql curs = BddMySql.GetInstance(connectionString);
            curs.ReqSelect(req, parameters);

            while (curs.Read())
            {
                string idDocuement = (string)curs.Field("id");
                int numero = (int)curs.Field("numero");
                DateTime dateAchat = (DateTime)curs.Field("dateAchat");
                string photo = (string)curs.Field("photo");
                string idEtat = (string)curs.Field("idEtat");
                Exemplaire exemplaire = new Exemplaire(numero, dateAchat, photo, idEtat, idDocuement);
                lesExemplaires.Add(exemplaire);
            }
            curs.Close();

            return lesExemplaires;
        }

        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire"></param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public static bool CreerExemplaire(Exemplaire exemplaire)
        {
            try
            {
                string req = "insert into exemplaire values (@idDocument,@numero,@dateAchat,@photo,@idEtat)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idDocument", exemplaire.IdDocument},
                    { "@numero", exemplaire.Numero},
                    { "@dateAchat", exemplaire.DateAchat},
                    { "@photo", exemplaire.Photo},
                    { "@idEtat",exemplaire.IdEtat}
                };
                BddMySql curs = BddMySql.GetInstance(connectionString);
                curs.ReqUpdate(req, parameters);
                curs.Close();
                return true;
            }catch{
                return false;
            }
        }

        /// <summary>
        /// Ecriture d'un document dans la base de données.
        /// </summary>
        /// <param name="document">Document à insérer dans la base de données.</param>
        /// <returns>true si l'insertion a pu se faire, false sinon.</returns>
        public static bool CreerDocument(Document document)
        {
            try
            {
                string req = "insert into document values (@id,@titre,@image,@idrayon,@idpublic,@idgenre)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@id", document.Id},
                    { "@titre", document.Titre},
                    { "@image", document.Image},
                    { "@idrayon", document.IdRayon},
                    { "@idpublic", document.IdPublic},
                    { "@idgenre", document.IdGenre}
                };
                BddMySql curs = BddMySql.GetInstance(connectionString);
                curs.ReqUpdate(req, parameters);
                curs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Ecriture d'un livre ou d'un DVD dans la base de données.
        /// </summary>
        /// <param name="livreDvd">Livre ou DVD à insérer dans la base de données.</param>
        /// <returns>true si l'insertion a pu se faire, false sinon.</returns>
        public static bool CreerLivreDVD(LivreDvd livreDvd)
        {
            try
            {
                string req = "insert into livres_dvd values (@id)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@id", livreDvd.Id},
                };
                BddMySql curs = BddMySql.GetInstance(connectionString);
                curs.ReqUpdate(req, parameters);
                curs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Ecriture d'un livre dans la base de données. Ajoute le livre dans document, puis dans livres_dvd
        /// avant de l'ajouter dans livre.
        /// </summary>
        /// <param name="livre">Livre à insérer dans la base de données.</param>
        /// <returns>true si l'insertion a pu se faire, false sinon.</returns>
        public static bool CreerLivre(Livre livre)
        {
            try
            {
                if (CreerDocument((Document)livre) && CreerLivreDVD((LivreDvd)livre))
                {
                    string req = "insert into livre values (@id,@isbn,@auteur,@collection)";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@id", livre.Id},
                        { "@isbn", livre.Isbn},
                        { "@auteur", livre.Auteur},
                        { "@collection", livre.Collection}
                    };
                    BddMySql curs = BddMySql.GetInstance(connectionString);
                    curs.ReqUpdate(req, parameters);
                    curs.Close();
                    return true;
                } 
                else 
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Ecriture d'un DVD dans la base de données.
        /// </summary>
        /// <param name="dvd">DVD à insérer dans la base de données.</param>
        /// <returns>true si l'insertion a pu se faire, false sinon.</returns>
        public static bool CreerDvd(Dvd dvd)
        {
            try
            {
                if (CreerDocument((Document)dvd) && CreerLivreDVD((LivreDvd)dvd))
                {
                    string req = "insert into dvd values (@id,@synopsis,@realisateur,@duree)";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@id", dvd.Id},
                        { "@synopsis", dvd.Synopsis},
                        { "@realisateur", dvd.Realisateur},
                        { "@duree", dvd.Duree}
                    };
                    BddMySql curs = BddMySql.GetInstance(connectionString);
                    curs.ReqUpdate(req, parameters);
                    curs.Close();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Ecriture d'une revue dans la base de données.
        /// </summary>
        /// <param name="revue">Revue à insérer dans la base de données.</param>
        /// <returns>true si l'insertion a pu se faire, false sinon.</returns>
        public static bool CreerRevue(Revue revue)
        {
            try
            {
                if (CreerDocument((Document)revue))
                {
                    string req = "insert into revue values (@id,@empruntable,@periodicite,@delaimiseadispo)";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@id", revue.Id},
                        { "@empruntable", revue.Empruntable},
                        { "@periodicite", revue.Periodicite},
                        { "@delaimiseadispo", revue.DelaiMiseADispo}
                    };
                    BddMySql curs = BddMySql.GetInstance(connectionString);
                    curs.ReqUpdate(req, parameters);
                    curs.Close();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Modification d'un document dans la base de données.
        /// </summary>
        /// <param name="document">Document à modifier dans la base de données.</param>
        /// <returns>true si la modification a pu se faire, false sinon.</returns>
        public static bool ModifierDocument(Document document)
        {
            try
            {
                string req = "update document set titre=@titre, image=@image, idRayon=@idRayon, idPublic=@idPublic, idGenre=@idGenre where id=@id";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@id", document.Id},
                    { "@titre", document.Titre},
                    { "@image", document.Image},
                    { "@idRayon", document.IdRayon},
                    { "@idPublic", document.IdPublic},
                    { "@idGenre", document.IdGenre}
                };
                BddMySql curs = BddMySql.GetInstance(connectionString);
                curs.ReqUpdate(req, parameters);
                curs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Modification d'un livre dans la base de données.
        /// </summary>
        /// <param name="livre">Livre à modifier dans la base de données.</param>
        /// <returns>true si la modification a pu se faire, false sinon.</returns>
        public static bool ModifierLivre(Livre livre)
        {
            try
            {
                if (ModifierDocument((Document)livre))
                {
                    string req = "update livre set isbn=@isbn, auteur=@auteur, collection=@collection where id=@id";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@id", livre.Id},
                        { "@isbn", livre.Isbn},
                        { "@auteur", livre.Auteur},
                        { "@collection", livre.Collection}
                    };
                    BddMySql curs = BddMySql.GetInstance(connectionString);
                    curs.ReqUpdate(req, parameters);
                    curs.Close();

                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        ///<summary>
        /// Modification d'un dvd dans la base de données.
        /// </summary>
        /// <param name="dvd">dvd à modifier dans la base de données.</param>
        /// <returns>true si la modification a pu se faire, false sinon.</returns>
        public static bool ModifierDvd(Dvd dvd)
        {
            try
            {
                if (ModifierDocument((Document)dvd))
                {
                    string req = "update dvd set synopsis=@synopsis, auteur=@auteur, realisateur=@realisateur, duree=@duree where id=@id";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@id", dvd.Id},
                        { "@synopsis", dvd.Synopsis},
                        { "@realisateur", dvd.Realisateur},
                        { "@duree", dvd.Duree}
                    };
                    BddMySql curs = BddMySql.GetInstance(connectionString);
                    curs.ReqUpdate(req, parameters);
                    curs.Close();

                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        ///<summary>
        /// Modification d'une revue dans la base de données.
        /// </summary>
        /// <param name="revue">Revue à modifier dans la base de données.</param>
        /// <returns>true si la modification a pu se faire, false sinon.</returns>
        public static bool ModifierRevue(Revue revue)
        {
            try
            {
                if (ModifierDocument((Document)revue))
                {
                    string req = "update reuve set empruntable=@empruntable, periodicite=@periodicite, delaimiseadispo=@delaimiseadispo where id=@id";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@id", revue.Id},
                        { "@empruntable", revue.Empruntable},
                        { "@periodicite", revue.Periodicite},
                        { "@delaimiseadispo", revue.DelaiMiseADispo}
                    };
                    BddMySql curs = BddMySql.GetInstance(connectionString);
                    curs.ReqUpdate(req, parameters);
                    curs.Close();

                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Suppression dans une table de la bdd, d'une ligne à partir de son id.
        /// </summary>
        /// <param name="table">Table dans laquelle on effectue la suppression.</param>
        /// <param name="id">Id de la ligne à supprimer.</param>
        /// <returns>true si la suppression a pu se faire, false sinon.</returns>
        public static bool Supprimer(string table, string id)
        {
            try
            {
                string req = "delete from @table where id=@id";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@table", table},
                    { "@id", id}
                };
                BddMySql curs = BddMySql.GetInstance(connectionString);
                curs.ReqUpdate(req, parameters);
                curs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Suppression d'un livre de la base de données.
        /// </summary>
        /// <param name="livre">Livre à supprimer dans la base de données.</param>
        /// <returns>true si la suppression a pu se faire, false sinon.</returns>
        public static bool SupprimerLivre(Livre livre)
        {
            return (Supprimer("document", livre.Id)
                && Supprimer("livres_dvd", livre.Id)
                && Supprimer("livre", livre.Id));
        }

        /// <summary>
        /// Suppression d'un dvd de la base de données.
        /// </summary>
        /// <param name="dvd">Dvd à supprimer dans la base de données.</param>
        /// <returns>true si la suppression a pu se faire, false sinon.</returns>
        public static bool SupprimerDvd(Dvd dvd)
        {
            return (Supprimer("document", dvd.Id)
                && Supprimer("livres_dvd", dvd.Id)
                && Supprimer("dvd", dvd.Id));
        }

        /// <summary>
        /// Suppression d'une revue de la base de données.
        /// </summary>
        /// <param name="revue">Revue à supprimer dans la base de données.</param>
        /// <returns>true si la suppression a pu se faire, false sinon.</returns>
        public static bool SupprimerRevue(Revue revue)
        {
            return (Supprimer("document", revue.Id)
                && Supprimer("revue", revue.Id));
        }

    }
}
