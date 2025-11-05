using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using EBAC.StateMachine;
using NaughtyAttributes;
using DG.Tweening;
using Animation;
using System;
using Health;


namespace Boss
{
    public enum BossAction
    {
        NONE,
        IDLE,
        RUN,
        ATTACK,
        DEATH
    }
    public class BossBase : MonoBehaviour
    {

        private StateMachine<BossAction> stateMachine;
        [SerializeField] private AnimationBase _animationBase;

        [Header("Life")]
        public int damage = 10;
        public HealthBase healthBase;

        [Header("Walk")]
        public float speed = 5f;
        public GameObject enemy;
        public List<Transform> waypoints;

        [Header("Attack")]
        public int attackAmount = 5;
        public float timeAttacks = .5f;

        public void Awake()
        {
            Init();
            if (healthBase != null)
            {
                healthBase.OnKill += OnEnemyKill;
            }
        }
        private void Init()
        {
            stateMachine = new StateMachine<BossAction>();
            stateMachine.Init();


            stateMachine.RegisterStates(BossAction.IDLE, new BossStateInit());
            stateMachine.RegisterStates(BossAction.RUN, new BossStateWalk());
            stateMachine.RegisterStates(BossAction.ATTACK, new BossStateAttack());
            stateMachine.RegisterStates(BossAction.DEATH, new BossStateDeath());
        }

        #region Walk

        public void RandomPoint(Action onArrive = null)
        {
            int point = UnityEngine.Random.Range(0, waypoints.Count);
            StartCoroutine(GoRandomPoint(waypoints[point], onArrive));
            PlayAnimationByTrigger(AnimationsType.RUN);
            enemy.transform.LookAt(waypoints[point]);
            Debug.Log("moveu");
        }

        IEnumerator GoRandomPoint(Transform t, Action onArrive = null)
        {
            while (Vector3.Distance(transform.position, t.position) > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
            }
            onArrive?.Invoke();
        }
        public void PlayAnimationByTrigger(AnimationsType animationsType)
        {
            _animationBase.PlayAnimationByTrigger(animationsType);
        }
        #endregion

        #region Attack
        public void StartAttack(Action endCallback = null)
        {
            StartCoroutine(GoAttack(endCallback));
        }
        IEnumerator GoAttack(Action endCallback)
        {
            int attacks = 0;
            while (attacks < attackAmount)
            {
                attacks++;
                PlayAnimationByTrigger(AnimationsType.ATTACK);
                yield return new WaitForSeconds(timeAttacks);
            }
            endCallback?.Invoke();
        }

        #endregion

        #region  Health
        public void Damage(int amount)
        {
            healthBase.Damage(amount);
        }
        private void OnEnemyKill()
        {
            PlayAnimationByTrigger(AnimationsType.DEATH);
            Switchstate(BossAction.DEATH);
            healthBase.OnKill += OnEnemyKill;

        }
        private void OnColliderEnter(Collider collision)
        {
            Debug.Log(collision.transform.name);

            var health = collision.gameObject.GetComponent<HealthBase>();

            if (health != null)
            {
                health.Damage(damage);
            }
        }
        [NaughtyAttributes.Button]
        public void Damage()
        {
            Damage(10);
        }
        #endregion

        #region Debug
        [NaughtyAttributes.Button]
        private void SwitchInit()
        {
            Switchstate(BossAction.IDLE);
        }
        [NaughtyAttributes.Button]
        private void SwitchWalk()
        {
            Switchstate(BossAction.RUN);
        }
         [NaughtyAttributes.Button]
        private void SwitchAttack()
        {
            Switchstate(BossAction.ATTACK);
        }
        public void Switchstate(BossAction state)
        {
            stateMachine.Switchstate(state, this);
        }
        #endregion
    }
}

