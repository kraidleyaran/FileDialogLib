namespace FileDialogLib.Objects
{
    public class Response
    {
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
        public string DirectoryPath { get; set; }
    }
}