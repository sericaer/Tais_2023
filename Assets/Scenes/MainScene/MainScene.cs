//using Aya.DataBinding;
using Aya.Events;
using Tais.UIViews.Messages;
using Tais.Views;
using Sericaer.UIBind.Runtime;
using UnityEngine;
using System.ComponentModel;

public class MainScene : MonoListener
{
    MainSceneViewMode view;

    public BindContext mainContext;

    public BindContext personDetailContext;
    public BindContext mapDetailContext;


    void Start()
    {
        view = new MainSceneViewMode();
        mainContext.SetContextData(view as INotifyPropertyChanged);
    }

    // Update is called once per frame
    void Update()
    {
        //view.roleHeath = 100;

        view.popNum++;
    }


    [Listen(typeof(MESSAGE_SHOW_PERSON_DETAIL))]
    public void OnShowPersonDetail(MESSAGE_SHOW_PERSON_DETAIL msg)
    {
        personDetailContext.gameObject.SetActive(true);
        personDetailContext.SetContextData(msg.context as INotifyPropertyChanged);
    }

    [Listen(typeof(MESSAGE_SHOW_MAP_DETAIL))]
    public void OnShowMapDetail(MESSAGE_SHOW_MAP_DETAIL msg)
    {
        mapDetailContext.gameObject.SetActive(true);
        mapDetailContext.SetContextData(msg.context as INotifyPropertyChanged);
    }
}
