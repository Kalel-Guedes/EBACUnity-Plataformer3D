using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Animation;



public class EnemyBase : MonoBehaviour
{
    [SerializeField] private AnimationBase _animationBase;
    public int damage = 10;
    public HealthBase healthBase;
    public GameObject enemyArt;

    private void Awake()
    {
        if (healthBase != null)
        {
        healthBase.OnKill += OnEnemyKill;
        }
    }
        
    private void Start()
    {
        enemyArt.transform.DOScale(0,3f).SetEase(Ease.OutBack).From();
    }

    private void OnEnemyKill()
    {
        PlayAnimationByTrigger(AnimationsType.DEATH);
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

    public void PlayAnimationByTrigger(AnimationsType animationsType)
    {
        _animationBase.PlayAnimationByTrigger(animationsType);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
