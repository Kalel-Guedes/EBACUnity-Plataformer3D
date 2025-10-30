using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Animation
{
    public enum AnimationsType
    {
        NONE,
        IDLE,
        RUN,
        DEATH,
        ATTACK
    }
    public class AnimationBase : MonoBehaviour
    {
        public Animator animation;
        public List<AnimationSetup> animationSetup;

        public void PlayAnimationByTrigger(AnimationsType animationsType)
        {
            var setup = animationSetup.Find(i => i.animationsType == animationsType);
           if(setup != null)
            {
                animation.SetTrigger(setup.trigger);
            }
        }
    }


    [System.Serializable]
    public class AnimationSetup
    {
        public AnimationsType animationsType;
        public string trigger;
    }

}