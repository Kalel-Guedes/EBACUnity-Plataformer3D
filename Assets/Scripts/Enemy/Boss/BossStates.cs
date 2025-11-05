using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using EBAC.StateMachine;

namespace Boss
{
    
    public class BossStatesBase : StateBase
    {
        protected BossBase boss;

        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss = (BossBase)objs[0];
        }
    }
    public class BossStateInit : BossStatesBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            Debug.Log("Boss" + boss);
        }
    }
    public class BossStateWalk : BossStatesBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.RandomPoint(OnArrive);
            Debug.Log("Boss" + boss);
        }

        private void OnArrive()
        {
            boss.Switchstate(BossAction.ATTACK);
        }
        public override void OnStateExit()
        {
            base.OnStateExit();
            boss.StopAllCoroutines();

        }
    }
    public class BossStateAttack : BossStatesBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.StartAttack(EndAttack);
            Debug.Log("Boss" + boss);
        }
        private void EndAttack()
        {
            boss.Switchstate(BossAction.RUN);
        }
         public override void OnStateExit()
        {
            base.OnStateExit();
            boss.StopAllCoroutines();

        }

    }
    public class BossStateDeath : BossStatesBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            Debug.Log("Boss" + boss);
        }
    }
}
