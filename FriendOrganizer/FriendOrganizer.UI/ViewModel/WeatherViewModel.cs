using System;
using System.Threading.Tasks;
using FriendOrganizer.UI.View.Services;
using Prism.Events;
using APIXULib;
using System.Windows.Input;
using Prism.Commands;

namespace FriendOrganizer.UI.ViewModel
{
    public class WeatherViewModel : DetailViewModelBase
    {
        private readonly string key = "876a92a2b3ed4f89aca130757170311";

        public WeatherViewModel(IEventAggregator eventAggregator, IMessageDialogService messageDialogService) 
            : base(eventAggregator, messageDialogService)
        {
            Title = "Weather";
            UpdateWeatherCommand = new DelegateCommand(OnUpdateWeatherExecute);
        }

        public WeatherModel WeatherProp { get; set; }

        public ICommand UpdateWeatherCommand { get; }

        private async void OnUpdateWeatherExecute()
        {
            WeatherProp = await GetRealTimeWeatherAsync();
        }
       
        public async override Task LoadAsync(int id)
        {
            WeatherProp = await GetRealTimeWeatherAsync(); 
            
            Id = id;
            await Task.CompletedTask;
        }

        private async Task<WeatherModel> GetRealTimeWeatherAsync()
        {
            IRepository repository = new Repository();
            WeatherModel weatherResultByIP = new WeatherModel();
            try
            {
                weatherResultByIP = repository.GetWeatherDataByAutoIP(key, Days.One);

                weatherResultByIP.current.condition.icon = "http:" + weatherResultByIP.current.condition.icon;                
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                await MessageDialogService.ShowInfoDialogAsync($"Could not find weather data.");
            }
            return weatherResultByIP;
        }

        protected override void OnDeleteExecute()
        {
            throw new NotImplementedException();
        }

        protected override bool OnSaveCanExecute()
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveExecute()
        {
            throw new NotImplementedException();
        }
    }
}
