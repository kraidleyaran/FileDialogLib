using System.Windows.Forms;
using FileDialogLib.Objects;
using GameArchiveLib;
using GameDataLib;

namespace FileDialogLib
{
    public class GameFileDialog
    {
        
        public GameFileDialog()
        {
            InitialDirectory = @"C:\";
        }
        public string InitialDirectory { get; set; }
        public Response LoadFile()
        {
            Response returnResponse = new Response(false);
            // TODO: Add in default path that can be set
            using (OpenFileDialog openFileDialog = new OpenFileDialog { InitialDirectory = InitialDirectory, Filter = "GameCraft Data Files (*.gcd)|*.gcd|All Files (*.*)|*.*" })
            {
                switch (openFileDialog.ShowDialog())
                {
                    case DialogResult.OK:
                        returnResponse.Data = GameArchive.Instance.LoadData<GameData>(openFileDialog.FileName);
                        returnResponse.ValidData = true;
                        returnResponse.DirectoryPath = openFileDialog.FileName;
                        break;
                }
            }

            return returnResponse;
        }

        public Response LoadFile<DataType>(string extension, string name)
        {
            Response returnResponse = new Response(false);
            // TODO: Add in default path that can be set
            using (OpenFileDialog openFileDialog = new OpenFileDialog { InitialDirectory = InitialDirectory, Filter = "GameCraft " + name + " Data Files (*." + extension + ")|*." + extension })
            {
                switch (openFileDialog.ShowDialog())
                {
                    case DialogResult.OK:
                        returnResponse.Data = GameArchive.Instance.LoadData<DataType>(openFileDialog.FileName);
                        returnResponse.ValidData = true;
                        returnResponse.DirectoryPath = openFileDialog.FileName;
                        break;
                }
            }

            return returnResponse;
        }


        public Response SaveFile<DataType>(DataType gameData)
        {
            Response returnResponse = new Response();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { InitialDirectory = InitialDirectory, Filter = "GameCraft Data Files (*.gcd)|*.gcd|All Files (*.*)|*.*" })
            {
                switch (saveFileDialog.ShowDialog())
                {
                    case DialogResult.OK:
                        GameArchive.Instance.SaveData(gameData, saveFileDialog.FileName);
                        returnResponse.ValidData = true;
                        returnResponse.DirectoryPath = saveFileDialog.FileName;
                        break;
                }


            }
            return returnResponse;
        }
        public Response SaveFile<DataType>(DataType gameData, string extension, string name, string defaultFileName)
        {
            Response returnResponse = new Response();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { InitialDirectory = InitialDirectory, Filter = "GameCraft " + name + " Data Files (*." + extension + ")|*." + extension })
            {
                saveFileDialog.FileName = defaultFileName + "." + extension;
                
                switch (saveFileDialog.ShowDialog())
                {
                    case DialogResult.OK:
                        GameArchive.Instance.SaveData(gameData, saveFileDialog.FileName);
                        returnResponse.ValidData = true;
                        returnResponse.DirectoryPath = saveFileDialog.FileName;
                        break;
                }


            }
            return returnResponse;
        }


    }
}
