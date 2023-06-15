/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace EC
{
    public class SaveGameDataWriter : MonoBehaviour
    {
        public string saveDataDirectory = "";
        public string saveDataFileName = "";

        public bool checkForFile()
        {
            if(File.Exists(Path.Combine(saveDataDirectory, saveDataFileName)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void DeleteSaveFile()
        {
            File.Delete(Path.Combine(saveDataDirectory, saveDataFileName));
        }

        public void CreatNewCharacterSaveFile(CharacterSaveData characterSaveData)
        {
            string savePath = Path.Combine(saveDataDirectory, saveDataFileName);

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                Debug.Log("CREATING SAVE FILE, AT SAVE PATH: " + savePath);

                string dataToStore = JsonUtility.ToJson(characterSaveData, true);

                using(FileStream = new FileStream(savePath,FileMode.Create))
                {
                    using(StreamWriter fileWriter = new StreamWriter(stream))
                    {
                        fileWriter.Write(dataToStore);
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.LogErrorFormat("ERROR WHILST SAVING CHARACTER DATA, GAME NOT SAVED"+ savePath + "\n" + ex);
            }
        }
        
        public CharacterSaveData LoadSaveFile()
        {
            CharacterSaveData characterData = null;

            string loadPath = Path.Combine(saveDataDirectory, saveDataFileName);

            if(File.Exists(loadPath))
            {
                try{
                string dataToLoad = "";

                using(FileStream stream = new FileStream(loadPath,FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                characterData = JsonUtility.FromJson<CharacterSaveData>(dataToLoad);
                }
                catch(Exception ex)
                {
                    Debug.LogErrorFormat("ERROR WHILST LOADING CHARACTER DATA, GAME NOT LOADED"+ loadPath + "\n" + ex);
                }
            }

            return characterData;
        }
    }
}
\*/