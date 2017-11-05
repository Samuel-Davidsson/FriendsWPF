using FriendOrganizer.UI.Event;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using FriendOrganizer.UI.Data.Lookups;
using System;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IFriendLookupDataService _friendLookupDataService;
        private IEventAggregator _eventAggregator;
        public ObservableCollection<NavigationItemViewModel> Friends { get; }


        public NavigationViewModel(IFriendLookupDataService friendLookupDataService, IEventAggregator eventAggregator)
        {
            _friendLookupDataService = friendLookupDataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterDetailSavedEvent>().Subscribe(AfterDetailSaved);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Subscribe(AfterDetailDeleted);
        }

        public async Task LoadAsync()
        {
            var lookup = await _friendLookupDataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(new NavigationItemViewModel(item.Id,item.DisplayMember, nameof(FriendDetailViewModel),
                    _eventAggregator));
            }
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {

            switch (args.ViewModelName)
            {
                case nameof(FriendDetailViewModel):
                    var friend = Friends.SingleOrDefault(f => f.Id == args.Id);
                    if (friend != null)
                    {
                        Friends.Remove(friend);
                    }
                    break;
            }
        }

        private void AfterDetailSaved(AfterDetailSavedEventArgs obj)
        {
            switch (obj.ViewModelName)
            {
                case nameof(FriendDetailViewModel):
                    var loookupItem = Friends.SingleOrDefault(f => f.Id == obj.Id);
                    if (loookupItem == null)
                    {
                        Friends.Add(new NavigationItemViewModel(obj.Id, obj.DisplayMember,
                            nameof(FriendDetailViewModel), _eventAggregator));
                    }
                    else
                    {
                        loookupItem.DisplayMember = obj.DisplayMember;
                    }
                    break;
            }
        }
      }
    }

