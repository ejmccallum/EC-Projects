using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC
{
    public class CharacterManager : MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}