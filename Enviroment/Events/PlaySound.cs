using UnityEngine;

namespace Events
{
    [RequireComponent(typeof(AudioSource))]
    public class PlaySound : Event
    {
        [SerializeField] AudioClip[] sounds;
        [SerializeField] AudioSource source;

        public override void Act()
        {
            source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
        }
        public override void Act(float value)
        {
            source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
        }
        public override void Act(bool state)
        {
            source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
        }
    }
}