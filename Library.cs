using QualityDevIUT_QM_TF;

using System.Text.Json;

/// <summary>
/// Représente une bibliothèque avec une collection de médias et les emprunts effectués.
/// </summary>
public class Library
{
    private List<Media> medias;   // Stocke les médias disponibles
    private List<Emprunt> emprunts; // Stocke les emprunts effectués

    /// <summary>
    /// Initialise une nouvelle instance de la classe Library avec des listes vides de médias et d'emprunts.
    /// </summary>
    public Library()
    {
        medias = new List<Media>();
        emprunts = new List<Emprunt>();
    }

    /// <summary>
    /// Accède à un média par son numéro de référence.
    /// </summary>
    /// <param name="numeroReference">Numéro de référence unique du média.</param>
    /// <returns>Renvoie le média correspondant ou null s'il n'existe pas.</returns>
    public Media this[int numeroReference]
    {
        get
        {
            return medias.Find(media => media.NumeroReference == numeroReference);
        }
    }

    /// <summary>
    /// Surcharge de l'opérateur "+" pour ajouter un média à la bibliothèque.
    /// Si le média existe déjà, il met à jour le nombre d'exemplaires disponibles.
    /// </summary>
    /// <param name="library">La bibliothèque à laquelle ajouter le média.</param>
    /// <param name="media">Le média à ajouter ou mettre à jour.</param>
    /// <returns>Renvoie la bibliothèque mise à jour.</returns>
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

    /// <summary>
    /// Surcharge de l'opérateur "-" pour retirer un média de la bibliothèque.
    /// Si le nombre d'exemplaires disponibles devient nul, le média est supprimé.
    /// </summary>
    /// <param name="library">La bibliothèque à laquelle retirer le média.</param>
    /// <param name="media">Le média à retirer ou à mettre à jour.</param>
    /// <returns>Renvoie la bibliothèque mise à jour.</returns>
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
            Console.WriteLine("Le média n'a pas été trouvé.");
        }

        return library;
    }

    /// <summary>
    /// Sauvegarde la bibliothèque dans un fichier JSON spécifié.
    /// </summary>
    /// <param name="cheminFichier">Le chemin du fichier où sauvegarder la bibliothèque.</param>
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

    /// <summary>
    /// Charge la bibliothèque à partir d'un fichier JSON.
    /// </summary>
    /// <param name="cheminFichier">Le chemin du fichier JSON contenant les données de la bibliothèque.</param>
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

    // Autres méthodes (Ajout, Retrait, Emprunt, Retour...) peuvent également être commentées de cette manière.
}
