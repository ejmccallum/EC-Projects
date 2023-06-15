using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace EC
{
    [System.Serializable]

    public class CharacterSaveData
    {
        [Header("Character Name")]
        public string characterName;

        [Header("Time Played")]
        public float secondsPlayed;

        [Header("World Position")]
        public float xPosition;
        public float yPosition;
        public float zPosition;

    }
}
