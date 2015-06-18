using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StoryManager : MonoBehaviour
    {

        // Setup level buttons' colors
        // Calculate game completion percentage

        private int completeLevel;

        // Use this for initialization
        void Start()
        {
            this.completeLevel = PlayerPrefs.GetInt("LastLevel");
            var buttons = GameObject.FindGameObjectsWithTag("LevelButton");

            for (int i = 0; i < completeLevel; i++)
            {
                buttons[i].GetComponent<Image>().color = Color.green;
            }
        }

        public void LoadLevel(int index)
        {
            if (index <= this.completeLevel + 1)
            {
                Application.LoadLevel(index);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}