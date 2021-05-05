using UnityEngine;
using System;

namespace Arkanoid.DataWork
{
    public class SaveLoad : MonoBehaviour, ISaveLoad
    {
        public void Save(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public int LoadInt(string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                return PlayerPrefs.GetInt(key);
            }
            throw new Exception("Key is not found in the PlayerPrefs.");
        }
    }
}