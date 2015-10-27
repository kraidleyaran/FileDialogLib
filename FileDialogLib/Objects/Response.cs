using GameArchiveLib;
using GameDataLib;

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

        public Response(bool validData, GameData gameData)
        {
            ValidData = validData;
            GameData = gameData;
        }

        public GameData GameData { get; set; }
        public bool ValidData { get; set; }
        public string DirectoryPath { get; set; }
    }
}