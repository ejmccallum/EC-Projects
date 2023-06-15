using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace EC
{
    public class WorldSaveGameManager : MonoBehaviour
    {
        public static WorldSaveGameManager instance;

        private PlayerManager player;

        [Header("SAVE/LOAD")]
        [SerializeField] bool saveGame;
        [SerializeField] bool loadGame;

        [Header("World Scene Index")]
        [SerializeField] int worldSceneIndex = 1;

        [Header("Save Data Writer")]
        private SaveFileDataWriter saveFileDataWriter;

        [Header("Current Character Data")]
        public CharacterSlot currentCharacterSlotBeingUsed;
        public CharacterSaveData currentCharacterData;
        private string saveFileName;

        [Header("Character Slots")]
        public CharacterSaveData characterSlot01;
        public CharacterSaveData characterSlot02;
        public CharacterSaveData characterSlot03;
        public CharacterSaveData characterSlot04;
        public CharacterSaveData characterSlot05;
        public CharacterSaveData characterSlot06;
        public CharacterSaveData characterSlot07;
        public CharacterSaveData characterSlot08;
        public CharacterSaveData characterSlot09;
        public CharacterSaveData characterSlot10;


        private void Awake()
        {
            //ONLY ONE AT A TIME    
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if(saveGame)
            {
                saveGame = false;
                SaveGame();
            }

            if(loadGame)
            {
                loadGame = false;
                LoadGame();
            }
        }

        public void DecideCharacterFileNameBasedOnCharacterSlotBeingUsed()
        {
            switch(currentCharacterSlotBeingUsed)
            {
                case CharacterSlot.CharacterSlot01:
                    saveFileName = "characterSlot01";
                    break;
                case CharacterSlot.CharacterSlot02:
                    saveFileName = "characterSlot02";
                    break;
                case CharacterSlot.CharacterSlot03:
                    saveFileName = "characterSlot03";
                    break;
                case CharacterSlot.CharacterSlot04:
                    saveFileName = "characterSlot04";
                    break;
                case CharacterSlot.CharacterSlot05:
                    saveFileName = "characterSlot05";
                    break;
                case CharacterSlot.CharacterSlot06:
                    saveFileName = "characterSlot06";
                    break;
                case CharacterSlot.CharacterSlot07:
                    saveFileName = "characterSlot07";
                    break;
                case CharacterSlot.CharacterSlot08:
                    saveFileName = "characterSlot08";
                    break;
                case CharacterSlot.CharacterSlot09:
                    saveFileName = "characterSlot09";
                    break;
                case CharacterSlot.CharacterSlot10:
                    saveFileName = "characterSlot10";
                    break;
                default:
                    break;
            }
        }

        public void CreateNewGame()
        {
            //CREATE NEW CHARACTER SAVE FILE
            DecideCharacterFileNameBasedOnCharacterSlotBeingUsed();
            currentCharacterData = new CharacterSaveData();

        }

        public void LoadGame()
        {
            //LOAD CHARACTER SAVE FILE
            DecideCharacterFileNameBasedOnCharacterSlotBeingUsed();

            saveFileDataWriter = new SaveFileDataWriter();
            saveFileDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
            saveFileDataWriter.saveFileName = saveFileName;
            currentCharacterData = saveFileDataWriter.LoadSaveFile();

            StartCoroutine(LoadWorldScene());
        }

        public void SaveGame()
        {
            //SAVE CHARACTER SAVE FILE
            DecideCharacterFileNameBasedOnCharacterSlotBeingUsed();

            saveFileDataWriter = new SaveFileDataWriter();
            saveFileDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
            //GENERALLY WORKS ON MULTIPLE MACHINE TYPES
            saveFileDataWriter.saveFileName = saveFileName;

            player.SaveGameDataToCurrentCharacterData(ref currentCharacterData);

            //PASS PLAYER INFO FROM GAME TO SAVE FILE

            saveFileDataWriter.CreateNewCharacterSaveFile(currentCharacterData);
        }

        public IEnumerator LoadWorldScene()
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);

            yield return null;
        }

        public int GetWorldSceneIndex()
        {
            return worldSceneIndex;
        }
    }
}