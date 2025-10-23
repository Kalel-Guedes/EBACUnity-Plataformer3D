using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace EBAC.StateMachine
{
    public class StateBase
    {
    
        public virtual void OnStateEnter(object o = null)
        {
            Debug.Log("OnStateEnter");
        }

        public virtual void OnStatestay()
        {
            Debug.Log("OnStateStay");
        }

        public virtual void OnStateExit()
        {
            Debug.Log("OnStateExit");
        }
    }
}
