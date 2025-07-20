using UnityEngine;

namespace Events
{
    public class ParticleInstance : Event
    {

        [SerializeField] ParticleSystem particle;
        public override void Act()
        {
            particle.Play();
        }
        public override void Act(float value)
        {

        }
        public override void Act(bool state)
        {
        }
    }
}