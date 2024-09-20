using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace QualityDevIUT_QM_TF
{
    public class Library
    {
        private List<Media> medias;
        private List<Emprunt> emprunts;

        public Library()
        {
            medias = new List<Media>();
            emprunts = new List<Emprunt>();
        }

        // Indexeur pour accéder aux médias par leur numéro de référence
        public Media this[int numeroReference]
        {
            get
            {
                return medias.Find(media => media.NumeroReference == numeroReference);
            }
        }

        // Surcharge de l'opérateur "+"
        public static Library operator +(Library library, Media media)
        {
            var existingMedia = library.medias.Find(m => m.NumeroReference == media.NumeroReference);

            if (existingMedia != null)
            {
                existingMedia.NombreExemplairesDisponibles += media.NombreExemplairesDisponibles;
                Console.WriteLine($"Média existant mis à jour: {media.Titre}, nouveaux exemplaires: {existingMedia.NombreExemplairesDisponibles}");
            }
            else
            {
                library.medias.Add(media);
                Console.WriteLine($"Nouveau média ajouté: {media.Titre}");
            }

            return library;
        }

        // Surcharge de l'opérateur "-"
        public static Library operator -(Library library, Media media)
        {
            var existingMedia = library.medias.Find(m => m.NumeroReference == media.NumeroReference);

            if (existingMedia != null && existingMedia.NombreExemplairesDisponibles >= media.NombreExemplairesDisponibles)
            {
                existingMedia.NombreExemplairesDisponibles -= media.NombreExemplairesDisponibles;

                if (existingMedia.NombreExemplairesDisponibles == 0)
                {
                    library.medias.Remove(existingMedia);
                    Console.WriteLine($"Média supprimé: {media.Titre}");
                }
                else
                {
                    Console.WriteLine($"{media.NombreExemplairesDisponibles} exemplaire(s) retiré(s) de {media.Titre}. Restant: {existingMedia.NombreExemplairesDisponibles}");
                }
            }
            else
            {
                Console.WriteLine("Le média n'a pas été trouver.");
            }

            return library;
        }

        // Méthode pour sauvegarder la bibliothèque dans un fichier JSON
        public void SauvegarderBibliotheque(string cheminFichier)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(medias, options);
                File.WriteAllText(cheminFichier, json);
                Console.WriteLine("La bibliothèque a été sauvegardée avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la sauvegarde : {ex.Message}");
            }
        }

        // Méthode pour charger la bibliothèque à partir d'un fichier JSON
        public void ChargerBibliotheque(string cheminFichier)
        {
            try
            {
                if (File.Exists(cheminFichier))
                {
                    string json = File.ReadAllText(cheminFichier);
                    medias = JsonSerializer.Deserialize<List<Media>>(json);
                    Console.WriteLine("La bibliothèque a été chargée avec succès.");
                }
                else
                {
                    Console.WriteLine("Le fichier spécifié n'existe pas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement : {ex.Message}");
            }
        }

        public void AjouterMedia(Media media)
        {
            medias.Add(media);
            Console.WriteLine($"Le média '{media.Titre}' a été ajouté à la bibliothèque.");
        }

        public void RetirerMedia(int numeroReference)
        {
            var media = medias.Find(media => media.NumeroReference == numeroReference);
            if (media != null)
            {
                medias.Remove(media);
                Console.WriteLine($"Le média '{media.Titre}' a été retiré de la bibliothèque.");
            }
            else
            {
                Console.WriteLine("Média non trouvé.");
            }
        }

        public void EmprunterMedia(int numeroReference, string utilisateur)
        {
            var media = this[numeroReference];
            if (media != null && media.NombreExemplairesDisponibles > 0)
            {
                media.NombreExemplairesDisponibles--;
                emprunts.Add(new Emprunt(utilisateur, media));
            }
            else
            {
                throw new InvalidOperationException("Le média n'est pas disponible.");
            }
        }

        public void RetournerMedia(int numeroReference, string utilisateur)
        {
            var emprunt = emprunts.Find(e => e.MediaEmprunte.NumeroReference == numeroReference && e.Utilisateur == utilisateur);
            if (emprunt != null)
            {
                emprunt.MediaEmprunte.NombreExemplairesDisponibles++;
                emprunts.Remove(emprunt);
            }
        }


        public List<Media> RechercherMedia(string critere)
        {
            return medias.FindAll(media => media.Titre.Contains(critere) || (media is Livre && ((Livre)media).Auteur.Contains(critere)));
        }

        public List<Media> ListerEmpruntsUtilisateur(string utilisateur)
        {
            var empruntsUtilisateur = emprunts.FindAll(e => e.Utilisateur == utilisateur);
            return empruntsUtilisateur.ConvertAll(e => e.MediaEmprunte);
        }

        public void AfficherStatistiques()
        {
            int totalMedias = medias.Count;
            int empruntes = emprunts.Count;
            int disponibles = 0;
            foreach (var media in medias)
            {
                disponibles += media.NombreExemplairesDisponibles;
            }

            Console.WriteLine($"Total de médias: {totalMedias}");
            Console.WriteLine($"Total empruntés: {empruntes}");
            Console.WriteLine($"Total disponibles: {disponibles}");
        }
    }
}
