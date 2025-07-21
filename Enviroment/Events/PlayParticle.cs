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
    }
}