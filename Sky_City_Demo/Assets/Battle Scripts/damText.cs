using UnityEngine;
using System.Collections;

public class damText : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().sortingOrder = 10;
        GetComponent<TextMesh>().text = GameFlow.currentDamage.ToString();
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
