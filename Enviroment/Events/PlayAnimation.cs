using UnityEngine;

namespace Events
{
    public class PlayAnimation : Event
    {
        [SerializeField] Animator controller;
        [SerializeField] string animationName;
        private void PlayAnim()
        {
            controller.ResetTrigger(animationName);
            controller.SetTrigger(animationName);
        }
        public override void Act()
        {
            PlayAnim();
        }
        public override void Act(float value)
        {
            PlayAnim();
        }
        public override void Act(bool state)
        {
            PlayAnim();
        }
    }
}