using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    /// <summary>
    /// Représente un livre, qui est un type de média avec un auteur.
    /// </summary>
    public class Livre : Media
    {
        /// <summary>
        /// Auteur du livre.
        /// </summary>
        public string Auteur;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Livre avec le titre, le numéro de référence,
        /// le nombre d'exemplaires disponibles et l'auteur.
        /// </summary>
        /// <param name="titre">Le titre du livre.</param>
        /// <param name="numeroReference">Le numéro de référence unique du livre.</param>
        /// <param name="nombreExemplairesDisponibles">Le nombre d'exemplaires disponibles pour ce livre.</param>
        /// <param name="auteur">Le nom de l'auteur du livre.</param>
        public Livre(string titre, int numeroReference, int nombreExemplairesDisponibles, string auteur)
            : base(titre, numeroReference, nombreExemplairesDisponibles)
        {
            Auteur = auteur;
        }

        /// <summary>
        /// Affiche les détails spécifiques du livre, y compris l'auteur.
        /// </summary>
        public override void AfficherDetails()
        {
            base.AfficherDetails();
            Console.WriteLine($"Auteur : {Auteur}");
        }
    }
}
