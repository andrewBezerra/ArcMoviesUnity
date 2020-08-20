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
    [Preserve(AllMembers = true)]
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        protected IPageDialogService PageDialogService { get; private set; }
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        private bool _isbusy;
        public bool isBusy
        {
            get { return _isbusy; }
            set { SetProperty(ref _isbusy, value); }
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
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

       
       

       


        
     


       
     

       

      
    }

}
