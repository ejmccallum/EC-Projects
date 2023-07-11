// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace EC{
//     public class MainMenuSaveManager : MonoBehaviour
//     {
//         public static MainMenuSaveManager Instance { get; set; }

//         private void Awake()
//         {
//             if(Instance != null && Instance != this)
//             {
//                 Destroy(gameObject);
//             }
//             else
//             {
//                 Instance = this;
//             }
//         }

//         // public void SaveMusicVolume(float volume)
//         // {
//         //     PlayerPrefs.SetFloat("MusicVolume", volume);
//         //     PlayerPrefs.Save();
//         // }

//         // public float LoadMusicVolume()
//         // {
//         //     return PlayerPrefs.GetFloat("MusicVolume");
//         // }

//         // public void SaveEffectsVolume(float volume)
//         // {
//         //     PlayerPrefs.SetFloat("EffectsVolume", volume);
//         //     PlayerPrefs.Save();
//         // }

//         // public float LoadEffectsVolume()
//         // {
//         //     return PlayerPrefs.GetFloat("EffectsVolume");
//         // }

//         [System.Serializable]
//         public class VolumeSettings
//         {
//             public float music;
//             public float effects; 
//             public float master; 
//         }

//         public void SaveVolumeSettings(float _music, float _effects, float _master)
//         {
//             VolumeSettings volumeSettings = new VolumeSettings()
//             {
//             music = _music;
//             effects = _effects;
//             master = _master;
//             };

//             PlayerPrefs.SetString("Volume", JsonUtility.ToJson(volumeSettings));
//             PlayerPrefs.Save();

//         }

//         public VolumeSettings LoadVolumeSettings()
//         {
//             return JsonUtility.FromJson<VolumeSettings>(PlayerPrefs.GetString("Volume"));
//         }

//     }
// }