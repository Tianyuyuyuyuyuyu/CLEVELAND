using UnityEngine;

public class TestAnimatedButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AnimatedButton animatedButton = GetComponent<AnimatedButton>();
        animatedButton.onClick.AddListener(() => { Debug.Log("TestAnimatedButton"); });
    }

}
