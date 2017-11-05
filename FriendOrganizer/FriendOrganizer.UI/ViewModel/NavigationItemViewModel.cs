using Prism.Commands;
using System.Windows.Input;
using System;
using FriendOrganizer.UI.Event;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private IEventAggregator _eventAggregator;
        private string _detailViewModelName;

        public NavigationItemViewModel(int id, string displayMember, string detailViewModelName, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Id = id;
            _detailViewModelName = detailViewModelName;
            DisplayMember = displayMember;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
        }
        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenDetailViewCommand { get; }

        private void OnOpenDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                       .Publish(
                new OpenDetailViewEventEventArgs
                {
                    Id = Id,
                    ViewModelName = _detailViewModelName
                });
        }
    }
}
