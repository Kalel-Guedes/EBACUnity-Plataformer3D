using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Health
{
    public class HealthBase : MonoBehaviour
    {
        public int startLife = 10;

        public bool destroyOnKill = false;

        public float delayKill = 0f;

        public int _currentLife;
        private bool _isDead = false;

        public bool isPlayer = false;

        public Action OnKill;
        //public AudioSource audioDamage;


        void Awake()
        {
            Init();
        }

        public void Init()
        {
            _isDead = false;
            _currentLife = startLife;
        }

        public void Damage(int damage)
        {
            if (_isDead) { return; }

            _currentLife -= damage;

            //if (isPlayer==true) {if (audioDamage != null) audioDamage.Play();}

            if(isPlayer) CameraShake.Instance.Shake();

            if (_currentLife <= 0)
            {
                Kill();
            }
        }

        private void Kill()
        {
            _isDead = true;

            if (destroyOnKill)
            {
                Destroy(gameObject, delayKill);
            }

            OnKill.Invoke();



        }
    }
}
    
