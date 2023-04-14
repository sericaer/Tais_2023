using System;
using UnityEngine;

public class PersonDetailPanel : MonoBehaviour
{
    private object view;

    internal void SetContext(object view)
    {
        this.view = view;
    }

    private void OnEnable()
    {
        if(view != null)
        {
            //BindMap.Bind(view);
        }
    }

    private void OnDisable()
    {
        if (view != null)
        {
            //BindMap.UnBind(view);
        }
    }
}