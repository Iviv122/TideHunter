using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace World
{
    public class Win: IStartable 
    {
        public Win(GameTimer timer)
        {
            timer.TimeOut += OnWin;
        }
        void IStartable.Start()
        {
            Debug.Log("Win class created");
        }
        public void OnWin()
        {
            Debug.Log("Win");
            SceneManager.LoadScene("Win");
        }
    }
}
