using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Sericaer.UIExtensions
{
    public class TimeSpeedControl : MonoBehaviour
    {
        public static TimeSpeedControl inst;

        public Button speedInc;
        public Button speedDec;
        public Toggle speedPause;
        public TimeIncEvent timeIncEvent;

        public List<int> speedValues = new List<int>()
        {
            200,
            100,
            50,
            20
        };

        public int speedIndex { get; set; }
        public bool isSysPause { get; set; }

        public bool isUserPause => speedPause.isOn;

        public bool isPause => isSysPause || isUserPause;

        public int MAX_SPEED => 4;
        public int MIN_SPEED => 1;

        private int currUpdateCount = 0;

        internal static GameObject CreateGameObject(GameObject parent)
        {
            GameObject instance = (GameObject)Instantiate(Resources.Load("TimeSpeedControl"), parent.transform);
            return instance;
        }


        void Start()
        {
            inst = this;

            isSysPause = false;

            speedIndex = 1;

            UpdateSpeedControl();

            speedInc.onClick.AddListener(() =>
            {
                speedIndex++;
                UpdateSpeedControl();
            });

            speedDec.onClick.AddListener(() =>
            {
                speedIndex--;
                UpdateSpeedControl();
            });

            speedPause.onValueChanged.AddListener((value) =>
            {
                Time.timeScale = value ? 0 : 1;

                UpdateSpeedControl();
            });
        }

        void FixedUpdate()
        {
            if (isPause)
            {
                return;
            }

            currUpdateCount++;

            if (currUpdateCount > speedValues[speedIndex])
            {
                timeIncEvent?.Invoke();

                currUpdateCount = 0;
            }
        }

        private void UpdateSpeedControl()
        {
            speedInc.interactable = !speedPause.isOn && speedIndex < speedValues.Count - 1;
            speedDec.interactable = !speedPause.isOn && speedIndex > 0;
        }
    }

    [System.Serializable]
    public class TimeIncEvent : UnityEvent
    {

    }
}
