using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input;
public class Test : MonoBehaviour
{
    [SerializeField]private InputSwipePanel _swipePanel;
    // Start is called before the first frame update

    private void OnEnable()
    {
        _swipePanel.Swiping += OnSwiping;
    }
    private void OnDisable()
    {
        _swipePanel.Swiping -= OnSwiping;
    }
    private void OnSwiping(Swipe swipe)
    {
        transform.position += (Vector3)swipe.Delta;
    }
}
