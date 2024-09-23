using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    /// <summary>
    /// Représente un emprunt d'un média par un utilisateur.
    /// </summary>
    public class Emprunt
    {
        /// <summary>
        /// Nom de l'utilisateur qui a emprunté le média.
        /// </summary>
        public string Utilisateur;

        /// <summary>
        /// Média emprunté par l'utilisateur.
        /// </summary>
        public Media MediaEmprunte;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Emprunt avec un utilisateur et le média emprunté.
        /// </summary>
        /// <param name="utilisateur">Le nom de l'utilisateur qui effectue l'emprunt.</param>
        /// <param name="mediaEmprunte">Le média emprunté par l'utilisateur.</param>
        public Emprunt(string utilisateur, Media mediaEmprunte)
        {
            Utilisateur = utilisateur;
            MediaEmprunte = mediaEmprunte;
        }
    }
}
