using System;

namespace PVCSClient.Libraries
{
    public class PVCSFileInfo : PVCSBasicFileInfo
    {
        public PVCSFileLabelCollection Labels { get; private set; }

        public PVCSFileGroupCollection Groups { get; private set; }

        public PVCSFileReviewCollection Reviews { get; private set; }

        public PVCSFileInfo() { }
        public PVCSFileInfo(string input) : this()
        {
            //Localiza el bloque de Etiquetas
            string etiquetas = this.ExtractLabelsText(input);
            this.Labels = new PVCSFileLabelCollection(etiquetas);

            //Localiza el bloque de Grupos
            string grupos = this.ExtractGroupsText(input); 
            this.Groups = new PVCSFileGroupCollection(grupos);

            //Localiza el bloque de Revisiones
            string revisiones = this.ExtractReviewsText(input);  
            this.Reviews = new PVCSFileReviewCollection(revisiones);
        }

        internal string ExtractReviewsText(string input)
        {
            //TODO: Implement
            throw new NotImplementedException();
        }

        internal string ExtractGroupsText(string input)
        {
            //TODO: Implement
            throw new NotImplementedException();
        }

        internal string ExtractLabelsText(string input)
        {
            //TODO: Implement
            throw new NotImplementedException();
        }
    }
}