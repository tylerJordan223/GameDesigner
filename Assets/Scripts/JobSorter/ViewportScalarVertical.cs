using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewportScalarVertical : MonoBehaviour
{
    private RectTransform content;

    //floats to get the original space
    private float base_content_height;
    private float base_content_position;
    private float content_spacing;

    private void Start()
    {
        //get the content object to be scaled
        content = gameObject.GetComponent<RectTransform>();

        //set the basice postiions
        base_content_position = content.position.y;
        base_content_height = content.sizeDelta.y;

        //get the layout group spacing to account for it
        content_spacing = GetComponent<VerticalLayoutGroup>().spacing;

        //update with teh current jobs
        UpdateHeight();
    }

    public void UpdateHeight()
    {

        //get the width of all of the children combined
        float content_height = 0f;
        for (int i = 0; i < transform.childCount; i++)
        {
            //adds the width of the rect transform
            content_height += transform.GetChild(i).gameObject.GetComponent<RectTransform>().sizeDelta.y;
            //add the spacing as well
            content_height += content_spacing;
        }

        //only do this if its not smaller than the base
        if (!(content_height <= base_content_height))
        {
            //set the new width of the content
            //moves the position by double to keep the x=0 in the same spot
            content.sizeDelta = new Vector2(content.rect.width, content_height);
            content.position = new Vector3(content.position.x, base_content_position + content_height * 2, content.position.z);
        }
        else
        {
            //only runs if its smaller, setting it to the base
            content.sizeDelta = new Vector2(content.sizeDelta.x, base_content_height);
            content.position = new Vector3(content.position.x, base_content_position, content.position.z);
        }
    }
}
