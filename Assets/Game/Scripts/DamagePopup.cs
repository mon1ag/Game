using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 1);
    }

    public void SetText(float text)
    {
        GetComponent<TMPro.TMP_Text>().text = text.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right*0.01f;
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
