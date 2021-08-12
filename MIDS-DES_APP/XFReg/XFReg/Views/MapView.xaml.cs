using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace XFReg.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();
            //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(1)));

            var location = new GeolocationRequest(GeolocationAccuracy.High);
            //var position = CrossGeolocator.Current.GetPositionAsync(new TimeSpan(0, 0, 10)).Result;
            Task.Run(async () =>
            {
                var position = await Geolocation.GetLocationAsync(location);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
                Pin customPin = new Pin()
                {
                    Type = PinType.Place,
                    Label = "Mi ubicación",
                    Address = "Aquí",
                    Position = new Position(position.Latitude, position.Longitude)
                };

                customPin.MarkerClicked += async (s, args) =>
                {
                    args.HideInfoWindow = true;
                    await DisplayAlert("Click en el pin", $"{((Pin)s).Label} fue oprimido", "Aceptar");
                };

                map.Pins.Add(customPin);
            });




            //map.Pins.Add(new Pin()
            //{
            //    Type = PinType.Place,
            //    Label = "Mi ubicación",
            //    Address = "Aquí",
            //    Position = new Position(37, -122)                
            //}); ;
        }


        private void StreetMap_Clicked(object sender, EventArgs e)
        {
            this.map.MapType = Xamarin.Forms.Maps.MapType.Street;
        }

        private void HibrydMap_Clicked(object sender, EventArgs e)
        {
            this.map.MapType = Xamarin.Forms.Maps.MapType.Hybrid;
        }

        private void SatelliteMap_Clicked(object sender, EventArgs e)
        {
            this.map.MapType = Xamarin.Forms.Maps.MapType.Satellite;
        }
    }
}