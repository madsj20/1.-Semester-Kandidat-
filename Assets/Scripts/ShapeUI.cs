using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class ShapeUI : MonoBehaviour
{

    public GameObject canvas;
    TextMeshProUGUI xText;
    TextMeshProUGUI yText;
    TextMeshProUGUI zText;


    void Start()
    {
        GameObject canvasClone = Instantiate<GameObject>(canvas);
        //set canvas parent to current GameObject
        canvasClone.transform.parent = transform;
        //set target camera
        canvasClone.GetComponent<Canvas>().worldCamera = Camera.main;
        //set size of canvas appropriately
        canvasClone.GetComponent<RectTransform>().sizeDelta = transform.localScale + (Vector3.one * 0.4f);
        //set position of canvas to front of object
        canvasClone.transform.localPosition =  new Vector3(0,0,transform.localScale.z/-2);
        //set rotation of canvas
        canvasClone.transform.rotation = transform.rotation;
        //make text references
        xText = canvasClone.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        yText = canvasClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        zText = canvasClone.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        //move texts to appropriate positions
        xText.gameObject.transform.localPosition = new Vector3(0, -transform.localScale.y/2 - 0.1f, 0);
        yText.gameObject.transform.localPosition = new Vector3(transform.localScale.x / 2 + 0.1f, 0, 0);
        zText.gameObject.transform.localPosition = new Vector3(transform.localScale.x / 2 + 0.1f, -transform.localScale.y / 2 - 0.1f, transform.localScale.z / 2);
    }

    // Update is called once per frame
    void Update()
    {
        //set text texts
        xText.text = transform.localScale.x.ToString();
        yText.text = transform.localScale.y.ToString();
        zText.text = transform.localScale.z.ToString();

    }
}
