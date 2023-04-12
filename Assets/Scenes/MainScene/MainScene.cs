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
        view.Update();
    }


    [Listen(typeof(MESSAGE_SHOW_PERSON_DETAIL))]
    public void OnShowPersonDetail(MESSAGE_SHOW_PERSON_DETAIL msg)
    {
        var detailPanel = Instantiate(personDetailContext, mapDetailContext.transform.parent);
        detailPanel.gameObject.SetActive(true);

        var view = new PersonDetailViewMode();
        detailPanel.SetContextData(view);

        detailPanel.OnDestroyEvent.AddListener(() => view.Dispose());
    }

    [Listen(typeof(MESSAGE_SHOW_MAP_DETAIL))]
    public void OnShowMapDetail(MESSAGE_SHOW_MAP_DETAIL msg)
    {
        var detailPanel = Instantiate(mapDetailContext, mapDetailContext.transform.parent);
        detailPanel.gameObject.SetActive(true);

        var view = new MapDetailViewModel(msg.model);
        detailPanel.SetContextData(view);

        detailPanel.OnDestroyEvent.AddListener(() => view.Dispose());
    }
}
