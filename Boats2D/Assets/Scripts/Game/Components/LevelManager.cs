using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Components
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;

        public static LevelManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<LevelManager>();
                }
                return instance;
            }
        }

        private int score;

        public int levelNumber;
        public int objective;
        public int passengerWaitingTime;

        public void Start()
        {
            this.score = 0;
        }

        public void IncrementScore()
        {
            this.score += 1;
            if (this.score == this.objective)
            {
                this.Complete();
            }
        }

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Resume()
        {
            Time.timeScale = 1;
        }

        public void Complete()
        {
            PlayerPrefs.SetInt("LastLevel", this.levelNumber);
            Application.LoadLevel("Home");
        }
    }
}
