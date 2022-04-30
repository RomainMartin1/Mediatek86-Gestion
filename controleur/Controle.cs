using System.Collections.Generic;
using Mediatek86.modele;
using Mediatek86.metier;
using Mediatek86.vue;


namespace Mediatek86.controleur
{
    internal class Controle
    {
        private readonly List<Livre> lesLivres;
        private readonly List<Dvd> lesDvd;
        private readonly List<Revue> lesRevues;
        private readonly List<Categorie> lesRayons;
        private readonly List<Categorie> lesPublics;
        private readonly List<Categorie> lesGenres;

        /// <summary>
        /// Ouverture de la fenêtre
        /// </summary>
        public Controle()
        {
            lesLivres = Dao.GetAllLivres();
            lesDvd = Dao.GetAllDvd();
            lesRevues = Dao.GetAllRevues();
            lesGenres = Dao.GetAllGenres();
            lesRayons = Dao.GetAllRayons();
            lesPublics = Dao.GetAllPublics();
            FrmMediatek frmMediatek = new FrmMediatek(this);
            frmMediatek.ShowDialog();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Collection d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return lesGenres;
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Collection d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return lesLivres;
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Collection d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return lesDvd;
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Collection d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return lesRevues;
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Collection d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return lesRayons;
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Collection d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return lesPublics;
        }

        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <returns>Collection d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return Dao.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return Dao.CreerExemplaire(exemplaire);
        }

        /// <summary>
        /// Ajoute un livre dans la bdd.
        /// </summary>
        /// <param name="livre">L'objet livre concerné.</param>
        /// <returns>True si la création a pu se faire, false sinon.</returns>
        public bool CreerLivre(Livre livre)
        {
            return Dao.CreerLivre(livre);
        }

        /// <summary>
        /// Ajoute un dvd dans la bdd.
        /// </summary>
        /// <param name="dvd">L'objet dvd concerné.</param>
        /// <returns>True si la création a pu se faire, false sinon.</returns>
        public bool CreerDvd(Dvd dvd)
        {
            return Dao.CreerDvd(dvd);
        }

        /// <summary>
        /// Ajoute une revue dans la bdd.
        /// </summary>
        /// <param name="dvd">L'objet revue concerné.</param>
        /// <returns>True si la création a pu se faire, false sinon.</returns>
        public bool CreerRevue(Revue revue)
        {
            return Dao.CreerRevue(revue);
        }

        /// <summary>
        /// Modifie un livre dans la bdd.
        /// </summary>
        /// <param name="livre">L'objet livre concerné.</param>
        /// <returns>True si la modification a pu se faire, false sinon.</returns>
        public bool ModifierLivre(Livre livre)
        {
            return Dao.ModifierLivre(livre);
        }

        /// <summary>
        /// Modifie un dvd dans la bdd.
        /// </summary>
        /// <param name="dvd">L'objet dvd concerné.</param>
        /// <returns>True si la modification a pu se faire, false sinon.</returns>
        public bool ModifierDvd(Dvd dvd)
        {
            return Dao.ModifierDvd(dvd);
        }

        /// <summary>
        /// Modifie une revue dans la bdd.
        /// </summary>
        /// <param name="dvd">L'objet revue concerné.</param>
        /// <returns>True si la modification a pu se faire, false sinon.</returns>
        public bool ModifierRevue(Revue revue)
        {
            return Dao.ModifierRevue(revue);
        }

        /// <summary>
        /// Supprime un livre de la bdd.
        /// </summary>
        /// <param name="livre">L'objet livre concerné.</param>
        /// <returns>True si la suppression a pu se faire, false sinon.</returns>
        public bool SupprimerLivre(Livre livre)
        {
            return Dao.SupprimerLivre(livre);
        }

        /// <summary>
        /// Supprime un dvd de la bdd.
        /// </summary>
        /// <param name="dvd">L'objet dvd concerné.</param>
        /// <returns>True si la suppression a pu se faire, false sinon.</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            return Dao.SupprimerDvd(dvd);
        }

        /// <summary>
        /// Supprime une revue de la bdd.
        /// </summary>
        /// <param name="dvd">L'objet revue concerné.</param>
        /// <returns>True si la suppression a pu se faire, false sinon.</returns>
        public bool SupprimerRevue(Revue revue)
        {
            return Dao.SupprimerRevue(revue);
        }

    }

}

