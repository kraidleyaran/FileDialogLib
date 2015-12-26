namespace FileDialogLib.Objects
{
    public class Response
    {
        private string directoryPath = "";
        public Response()
        {
            
        }
        public Response(bool validData)
        {
            ValidData = validData;
        }

        public Response(bool validData, object gameData)
        {
            ValidData = validData;
            Data = gameData;
        }

        public object Data { get; set; }
        public bool ValidData { get; set; }
        public string DirectoryPath 
        { 
            get { return directoryPath; }
            set
            {
                directoryPath = value;
                int startChar = directoryPath.LastIndexOf(@"\") + 1;
                int endChar = directoryPath.LastIndexOf(@".") - 1;
                int length = endChar - startChar;
                
                FileName = directoryPath.Substring(startChar,length);
            } 
        }
        public string FileName { get; private set; }
    }
}