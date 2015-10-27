using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
        }

        public Response LoadFile()
        {
            Response returnResponse = new Response(false);
            // TODO: Add in default path that can be set
            using (OpenFileDialog openFileDialog = new OpenFileDialog { InitialDirectory = @"C:\", Filter = "GameCraft Data Files (*.gcd)|*.gcd|All Files (*.*)|*.*" })
            {
                switch (openFileDialog.ShowDialog())
                {
                    case DialogResult.OK:
                        returnResponse.GameData = GameArchive.Instance.LoadData<GameData>(openFileDialog.FileName);
                        returnResponse.ValidData = true;
                        returnResponse.DirectoryPath = openFileDialog.FileName;
                        break;
                }
            }

            return returnResponse;
        }


        public Response SaveFile(GameData gameData)
        {
            Response returnResponse = new Response();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog {InitialDirectory = @"C:\", Filter = "GameCraft Data Files (*.gcd)|*.gcd|All Files (*.*)|*.*"})
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
    }
}
