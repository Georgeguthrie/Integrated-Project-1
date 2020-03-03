using UnityEngine;
using UnityEngine.SceneManagement;
class Loadgame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Level Select");
    }
}