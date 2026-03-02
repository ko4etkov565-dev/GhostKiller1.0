using UnityEngine;
using UnityEngine.EventSystems; 
public class NewMonoBehaviourScript : MonoBehaviour, IPointerEnterHandler
{
   public AudioSource audioSource;
   public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.Play();
    }
}
