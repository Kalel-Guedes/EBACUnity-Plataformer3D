using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Animation;
using Health;


namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] private AnimationBase _animationBase;
        public int damage = 10;
        public HealthBase healthBase;
        public GameObject enemyArt;
        public string compareTag = "Player";
        

        private void Awake()
        {
            if (healthBase != null)
            {
                healthBase.OnKill += OnEnemyKill;
            }
        }

        private void Start()
        {
            //enemyArt.transform.DOScale(0, 2f).SetEase(Ease.OutBack).From();
        }

        private void OnEnemyKill()
        {
            PlayAnimationByTrigger(AnimationsType.DEATH);
            healthBase.OnKill += OnEnemyKill;

        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.transform.name);

            if (collision.transform.CompareTag(compareTag))
            {
                var health = collision.gameObject.GetComponent<HealthBase>();

                if (health != null)
                {
                    health.Damage(damage);
                }
            }
        }

        public void PlayAnimationByTrigger(AnimationsType animationsType)
        {
            _animationBase.PlayAnimationByTrigger(animationsType);
        }

        public void Damage(int amount)
        {
            healthBase.Damage(amount);
        }
    }
}
