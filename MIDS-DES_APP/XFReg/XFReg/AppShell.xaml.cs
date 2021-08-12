using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFReg.DataAccess;
using XFReg.ViewModels;
using XFReg.Views;

namespace XFReg
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private SQLiteAsyncConnection sqliteConn;
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            this.sqliteConn = DependencyService.Get<ISQLiteDB>().GetConnection();

            Task.Run(async () =>
            {
                var result = await sqliteConn.InsertAsync(
                    new Log()
                    {
                        Date = DateTime.Now,
                        Module = "Main AppShel",
                        Operation = "El usuario inicio la aplicación"
                    }, typeof(Log));
            });

        }

    }
}
