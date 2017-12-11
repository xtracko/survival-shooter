using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class Potions_PotionManager : MonoBehaviour
    {
        public GameObject potion;

        public static Potions_PotionManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void CreatePotion(Vector3 position)
        {
            Instantiate(potion, position, Quaternion.identity);
        }
    }
}