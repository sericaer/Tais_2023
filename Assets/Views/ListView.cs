//using Aya.DataBinding;
using Loxodon.Framework.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

namespace Tais.Views
{
    public class ListView<TItemViewModel> : MonoBehaviour
        where TItemViewModel : class, IViewModel
    {
        public UIView<TItemViewModel> itemViewTemplate;

        public ReadOnlyObservableCollection<TItemViewModel> itemViewModels
        {
            get
            {
                return _itemViewModels;
            }
            set
            {
                if(_itemViewModels != null)
                {
                    throw new Exception();
                }

                if(_itemViewModels == value)
                {
                    return;
                }

                if (_itemViewModels != null)
                {
                    ((INotifyCollectionChanged)_itemViewModels).CollectionChanged -= _itemViewModels_CollectionChanged;
                }

                _itemViewModels = value;

                ((INotifyCollectionChanged)_itemViewModels).CollectionChanged += _itemViewModels_CollectionChanged;

                _itemViewModels_CollectionChanged(_itemViewModels, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, _itemViewModels));
            }
        }

        private ReadOnlyObservableCollection<TItemViewModel> _itemViewModels;

        void OnDestroy()
        {
            if(_itemViewModels != null)
            {
                ((INotifyCollectionChanged)_itemViewModels).CollectionChanged -= _itemViewModels_CollectionChanged;
            }
        }

        private void _itemViewModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(var item in e.NewItems)
                    {
                        var itemView = Instantiate(itemViewTemplate, itemViewTemplate.transform.parent);
                        itemView.viewModel = item as TItemViewModel;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    var itemViews = itemViewTemplate.transform.parent.GetComponentsInChildren<UIView<TItemViewModel>>();
                    foreach (var itemView in itemViews.Where(x => e.OldItems.Contains(x.viewModel)).ToArray())
                    {
                        Destroy(itemView.gameObject);
                    }
                    break;
                default:
                    throw new NotImplementedException(e.Action.ToString());
            }
        }
    }
}