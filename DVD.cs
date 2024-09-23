using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    /// <summary>
    /// Représente un DVD, qui est un type de média avec une durée spécifique.
    /// </summary>
    public class DVD : Media
    {
        /// <summary>
        /// Durée du DVD en minutes.
        /// </summary>
        public double Duree;

        /// <summary>
        /// Initialise une nouvelle instance de la classe DVD avec le titre, le numéro de référence, 
        /// le nombre d'exemplaires disponibles et la durée.
        /// </summary>
        /// <param name="titre">Le titre du DVD.</param>
        /// <param name="numeroReference">Le numéro de référence du DVD.</param>
        /// <param name="nombreExemplairesDisponibles">Le nombre d'exemplaires disponibles pour ce DVD.</param>
        /// <param name="duree">La durée du DVD en minutes.</param>
        public DVD(string titre, int numeroReference, int nombreExemplairesDisponibles, double duree)
            : base(titre, numeroReference, nombreExemplairesDisponibles)
        {
            Duree = duree;
        }

        /// <summary>
        /// Affiche les détails spécifiques du DVD, y compris sa durée.
        /// </summary>
        public override void AfficherDetails()
        {
            base.AfficherDetails();
            Console.WriteLine($"Durée : {Duree} minutes");
        }
    }
}
