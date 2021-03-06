﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
namespace LoadList
{
    public class LoadingListView: ListView
    {
        public static readonly BindableProperty LoadMoreCommandProperty
            = BindableProperty.Create<LoadingListView, ICommand>(bp => bp.LoadMoreCommand, default(ICommand));

        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        public LoadingListView()
        {
            RegisterLoading();
        }

        public LoadingListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
            RegisterLoading();
        }

        void RegisterLoading()
        {
            ItemAppearing += InfiniteListView_ItemAppearing;
        }

        object lastItem;
        void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            // Cuando llega al final de la lista ejecuta el evento
            if (ItemsSource is IList items && e.Item == items[items.Count - 1])
            {
                if (e.Item != lastItem && LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                {
                    lastItem = e.Item;
                    LoadMoreCommand.Execute(null);
                }
            }
        }
    }
}
