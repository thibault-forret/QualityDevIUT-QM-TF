using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    /// <summary>
    /// Représente un CD, qui est un type de média associé à un artiste.
    /// </summary>
    public class CD : Media
    {
        /// <summary>
        /// Nom de l'artiste associé au CD.
        /// </summary>
        public string Artiste;

        /// <summary>
        /// Initialise une nouvelle instance de la classe CD avec le titre, le numéro de référence,
        /// le nombre d'exemplaires disponibles et le nom de l'artiste.
        /// </summary>
        /// <param name="titre">Le titre du CD.</param>
        /// <param name="numeroReference">Le numéro de référence unique du CD.</param>
        /// <param name="nombreExemplairesDisponibles">Le nombre d'exemplaires disponibles pour ce CD.</param>
        /// <param name="artiste">Le nom de l'artiste du CD.</param>
        public CD(string titre, int numeroReference, int nombreExemplairesDisponibles, string artiste)
            : base(titre, numeroReference, nombreExemplairesDisponibles)
        {
            Artiste = artiste;
        }

        /// <summary>
        /// Affiche les détails spécifiques du CD, y compris l'artiste.
        /// </summary>
        public override void AfficherDetails()
        {
            base.AfficherDetails();
            Console.WriteLine($"Artiste : {Artiste}");
        }
    }
}
