using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewportScalarHorizontal : MonoBehaviour
{
    private RectTransform content;

    //floats to get the original space
    private float base_content_width;
    private float base_content_position;
    private float content_spacing;

    private void Start()
    {
        //get the content object to be scaled
        content = gameObject.GetComponent<RectTransform>();

        //set the basice postiions
        base_content_position = content.position.x;
        base_content_width = content.sizeDelta.x;

        //get the layout group spacing to account for it
        content_spacing = GetComponent<HorizontalLayoutGroup>().spacing;

        //update with teh current jobs
        UpdateWidth();
    }

    public void UpdateWidth()
    {

        //get the width of all of the children combined
        float content_width = 0f;
        for (int i = 0; i < transform.childCount; i++)
        {
            //adds the width of the rect transform
            content_width += transform.GetChild(i).gameObject.GetComponent<RectTransform>().sizeDelta.x;
            //account for spacing
            content_width += content_spacing;
        }

        //only do this if its not smaller than the base
        if (!(content_width <= base_content_width))
        {
            //set the new width of the content
            //moves the position by double to keep the x=0 in the same spot
            content.sizeDelta = new Vector2(content_width, content.rect.height);
            content.position = new Vector3(base_content_position + content_width * 2, content.position.y, content.position.z);
            Debug.Log("set new size");
        }
        else
        {
            //only runs if its smaller, setting it to the base
            content.sizeDelta = new Vector2(base_content_width, content.sizeDelta.y);
            content.position = new Vector3(base_content_position, content.position.y, content.position.z);
        }
    }
}
