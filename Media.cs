using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    /// <summary>
    /// Représente un média de base avec un titre, un numéro de référence et un nombre d'exemplaires disponibles.
    /// </summary>
    public class Media
    {
        /// <summary>
        /// Titre du média.
        /// </summary>
        public string Titre;

        /// <summary>
        /// Numéro de référence unique du média.
        /// </summary>
        public int NumeroReference;

        /// <summary>
        /// Nombre d'exemplaires disponibles pour ce média.
        /// </summary>
        public int NombreExemplairesDisponibles;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Media avec un titre, un numéro de référence
        /// et un nombre d'exemplaires disponibles.
        /// </summary>
        /// <param name="titre">Le titre du média.</param>
        /// <param name="numeroReference">Le numéro de référence unique du média.</param>
        /// <param name="nombreExemplairesDisponibles">Le nombre d'exemplaires disponibles pour ce média.</param>
        public Media(string titre, int numeroReference, int nombreExemplairesDisponibles)
        {
            Titre = titre;
            NumeroReference = numeroReference;
            NombreExemplairesDisponibles = nombreExemplairesDisponibles;
        }

        /// <summary>
        /// Affiche les détails de base du média, y compris son titre, son numéro de référence
        /// et le nombre d'exemplaires disponibles.
        /// </summary>
        public virtual void AfficherDetails()
        {
            Console.WriteLine($"Titre : {Titre}");
            Console.WriteLine($"Numéro de référence : {NumeroReference}");
            Console.WriteLine($"Nombre d'exemplaires disponibles : {NombreExemplairesDisponibles}");
        }
    }
}
