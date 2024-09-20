using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityDevIUT_QM_TF
{
    public class Emprunt
    {
        public string Utilisateur;
        public Media MediaEmprunte;

        public Emprunt(string utilisateur, Media mediaEmprunte)
        {
            Utilisateur = utilisateur;
            MediaEmprunte = mediaEmprunte;
        }
    }
}
