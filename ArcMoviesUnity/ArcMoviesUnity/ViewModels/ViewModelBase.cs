using ArcMoviesUnity.Droid;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcMoviesUnity.ViewModels
{
    [Preserve(AllMembers =true)]
    public abstract class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected IPageDialogService PageDialogService { get; private set; }
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !isBusy;
            }
        }

        bool isNotBusy = true;

        public bool IsNotBusy
        {
            get => isNotBusy;
            set
            {
                if (SetProperty(ref isNotBusy, value))
                    IsBusy = !isNotBusy;
            }
        }

        bool canLoadMore = true;

        public bool CanLoadMore
        {
            get => canLoadMore;
            set => SetProperty(ref canLoadMore, value);
        }

        public ViewModelBase(INavigationService navigationService, 
            IPageDialogService pagedialogservice)
        {
            NavigationService = navigationService;
            PageDialogService = pagedialogservice;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
