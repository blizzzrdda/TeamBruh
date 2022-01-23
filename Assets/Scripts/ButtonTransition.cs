using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1.15f, 1.15f, 1), .4f).SetEase(Ease.OutExpo);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, .4f).SetEase(Ease.OutExpo);
    }
}