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
        private Animator panelAnimator;
        private LevelState state;

        public int boatCount;
        public int levelNumber;
        public int objective;
        public int passengerWaitingTime;
        public TimeController panel;

        public void Start()
        {
            this.score = 0;
            this.LevelComplete += this.Complete;

            this.state = LevelState.InProgress;
            this.panel = GameObject.Find("Level Panel").GetComponent<TimeController>();
            this.panelAnimator = this.panel.GetComponent<Animator>();

            new WaitForSeconds(2);
        }

        public void Play()
        {
            switch (this.state)
            {
                case LevelState.Complete:
                    // Play next level
                    this.panel.ToggleTime();
                    Application.LoadLevel(LevelManager.Instance.levelNumber + 1);
                    break;
                case LevelState.Failed:
                    this.panel.ToggleTime();
                    Application.LoadLevel(LevelManager.Instance.levelNumber);
                    break;
                case LevelState.InProgress:
                    // Resume game
                    this.panel.ToggleTime();
                    this.panelAnimator.Play("SlideUp");
                    break;
                default:
                    break;
            }
        }

        private void Complete(object sender, EventArgs e)
        {
            PlayerPrefs.SetInt("LastLevel", this.levelNumber);

            this.Pause();
            this.state = LevelState.Complete;
        }

        public void IncrementScore()
        {
            this.score += 1;
            OnScoreChanged();
            if (this.score == this.objective)
            {
                this.OnLevelComplete();
            }
        }

        public event EventHandler ScoreChanged;
        protected void OnScoreChanged()
        {
            if (this.ScoreChanged != null)
            {
                this.ScoreChanged(this, new EventArgs());
            }
        }

        public void Pause()
        {
            this.panelAnimator.Play("SlideDown");
        }

        public void Restart()
        {
            this.panel.ToggleTime();
            Application.LoadLevel(LevelManager.Instance.levelNumber);
        }

        public void Home()
        {
            this.panel.ToggleTime();
            Application.LoadLevel("Home");
        }

        public event EventHandler LevelComplete;
        protected void OnLevelComplete()
        {
            if (this.LevelComplete != null)
            {
                this.LevelComplete(this, new EventArgs());
            }
        }

        internal void BoatLost()
        {
            this.boatCount -= 1;
            if (this.boatCount == 0)
            {
                this.state = LevelState.Failed;
                this.Pause();
            }
        }
    }

    enum LevelState
    {
        InProgress = 0, 
        Complete = 1,
        Failed = 2
    }
}
