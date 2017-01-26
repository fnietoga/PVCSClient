using System;

namespace PVCSClient.Libraries
{
    public class PVCSFileInfo : PVCSBasicFileInfo
    {
        PVCSFileLabelCollection Labels { get; set; }

        PVCSFileGroupCollection Groups { get; set; }

        PVCSFileReviewCollection Reviews { get; set; }

        public PVCSFileInfo() { }
        public PVCSFileInfo(string input) : this()
        {
            //Localiza el bloque de Etiquetas
            string etiquetas = this.ExtractLabelsText();
            this.Labels = new PVCSFileLabelCollection(etiquetas);

            //Localiza el bloque de Grupos
            string grupos = this.ExtractGroupsText(); 
            this.Groups = new PVCSFileGroupCollection(grupos);

            //Localiza el bloque de Revisiones
            string revisiones = this.ExtractReviewsText();  
            this.Reviews = new PVCSFileReviewCollection(revisiones);
        }

        private string ExtractReviewsText()
        {
            throw new NotImplementedException();
        }

        private string ExtractGroupsText()
        {
            throw new NotImplementedException();
        }

        private string ExtractLabelsText()
        {
            throw new NotImplementedException();
        }
    }
}