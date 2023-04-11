//using Aya.DataBinding;
using Aya.Events;
using System;
using Tais.Views;
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