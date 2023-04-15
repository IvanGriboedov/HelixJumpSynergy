using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class InputSwipePanel : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public event Action<Swipe> SwipeBegun;
        public event Action<Swipe> Swiping;
        public event Action<Swipe> SwipeEnded;

        private Vector2 _startPos;
        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPos = eventData.position;
            Invoke(SwipeBegun, eventData);
        }
        public void OnDrag(PointerEventData eventData) =>
            Invoke(Swiping, eventData);

        public void OnEndDrag(PointerEventData eventData) =>
            Invoke(SwipeEnded, eventData);

        private void Invoke(Action<Swipe> action, PointerEventData eventData) =>
            action?.Invoke(CreateSwipeFrom(_startPos, eventData));
        private Swipe CreateSwipeFrom(Vector2 startPos, PointerEventData eventData) =>
            new Swipe(startPos, eventData.position, eventData.delta);
    }

}
