using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPokemon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private float _vertiacalMoveAmount = 30f;
    [SerializeField] private float _moveTime = 0.1f;
    [Range(0f, 2f), SerializeField] private float _scaleAmount = 1.1f;

    private Vector3 _startPosition;
    private Vector3 _startScale;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        _startScale = transform.localScale;
    }
    private IEnumerator MovePanel(bool startingAnimation) 
    {
        Vector3 endPosition;
        Vector3 endScale;

        float elapsedTime = 0f;
        while (elapsedTime < _moveTime)
        {
            elapsedTime += Time.deltaTime;

            if (startingAnimation)
            {
                endPosition = _startPosition + new Vector3(0f, _vertiacalMoveAmount, 0f);
                endScale = _startScale * _scaleAmount;
            } else {
                endPosition = _startPosition;
                endScale = _startScale;
            }

            //calculate the lerped amounts
            Vector3 lerpedPosition = Vector3.Lerp(transform.position, endPosition, (elapsedTime / _moveTime));
            Vector3 lerpedScale = Vector3.Lerp(transform.localScale, endScale, (elapsedTime / _moveTime));

            //apply changer to the position and scale
            transform.position = lerpedPosition;
            transform.localScale = lerpedScale;

            yield return null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //select the card
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //deselect the card
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        StartCoroutine(MovePanel(true));
    }

    public void OnDeselect(BaseEventData eventData)
    {
        StartCoroutine(MovePanel(false));
    }
}
