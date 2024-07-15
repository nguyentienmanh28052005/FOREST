using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class EnegyBar : MonoBehaviour
{
    [SerializeField] private Image FrameBar;

    public void UpdateBar(float currentEnengy, float maxEnegy)
    {
        FrameBar.fillAmount = currentEnengy / maxEnegy;
    }
}
