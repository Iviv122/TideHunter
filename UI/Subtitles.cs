using System.Collections;
using Modules;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SubTitles : MonoBehaviour
    {
        [SerializeField] AudioSource AudioSource;
        [SerializeField] TextMeshProUGUI label;
        [SerializeField] AudioClip[] clips;
        [SerializeField] string[] subtitles;
        [SerializeField] Radar radar;

        [Header("Lose")]
        [SerializeField] string LoseSubtitle;
        [SerializeField] AudioClip loseSound;

        bool lost = false;
        int i = 0;
        Coroutine subtitleRoutine;

        public void Awake()
        {
            Debug.Log("SubTitles");
            i = 0;
            radar.OnLose += LoseSound;
        }

        public void Start()
        {
            subtitleRoutine = StartCoroutine(PlayAudioCoroutine());
        }

        private IEnumerator PlayAudioCoroutine()
        {
            yield return new WaitForSeconds(2f);

            while (i < clips.Length)
            {
                AudioSource.PlayOneShot(clips[i]);
                label.text = subtitles[i];
                yield return new WaitForSeconds(clips[i].length + 1f);
                i++;
            }

            label.text = "";
        }

        public void LoseSound()
        {
            if (!lost)
            {
                lost = true;

                if (subtitleRoutine != null)
                {
                    StopCoroutine(subtitleRoutine);
                }

                StartCoroutine(LoseCoroutine());
            }
        }

        private IEnumerator LoseCoroutine()
        {
            AudioSource.PlayOneShot(loseSound);
            label.text = LoseSubtitle;
            yield return new WaitForSeconds(loseSound.length + 0.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnDestroy()
        {
            if (subtitleRoutine != null)
            {
                StopCoroutine(subtitleRoutine);
            }

            StopAllCoroutines();
        }
    }
}
