using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFReg.DataAccess;

namespace XFReg.ViewModels
{
    public class ActivityLogViewModel : BaseViewModel
    {
        private ObservableCollection<Log> logs;

        public ObservableCollection<Log> Logs
        {
            get => logs;
            set
            {
                logs = value;
                OnPropertyChanged();
            }
        }

        public ActivityLogViewModel()
        {
            var conn = DependencyService.Get<ISQLiteDB>().GetConnection();

            Task.Run(async () =>
            {
                var result = await conn.QueryAsync<Log>("SELECT * FROM Log");
                this.Logs = new ObservableCollection<Log>(result);
            });

        }
    }
}
