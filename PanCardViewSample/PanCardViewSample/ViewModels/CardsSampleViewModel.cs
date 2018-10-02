using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using FFImageLoading;
using PanCardView.Extensions;
using System;

namespace PanCardViewSample.ViewModels
{
	public sealed class CardsSampleViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private int _currentIndex;
		private int _ImageCount = 500;

		public CardsSampleViewModel()
		{
            Items = new ObservableCollection<object>
            {
                new { Description="Texto de descripción", Date = DateTime.Now.ToShortDateString(), Color = Color.Red },
                new { Description="Texto de descripción en varias líneas líneas líneas líneas líneas líneas líneas líneas líneas líneas líneas líneas líneas líneas líneas líneas", Date = DateTime.Now.ToShortDateString(), Color = Color.Green },
                new { Description="Otro texto de descripción diferente", Date = DateTime.Now.ToShortDateString(), Color = Color.Gold },
                new { Description="Texto de descripción 4324", Date = DateTime.Now.ToShortDateString(), Color = Color.Silver },
                new { Description="Texto de descripción 454554", Date = DateTime.Now.ToShortDateString(), Color = Color.Blue }
            };

            SubItems = new ObservableCollection<string>() { "Texto 1", "Texto 2", "Texto 3", "Texto 4","Texto 5","Texto 6","Texto 7","Texto 8"};


			PanPositionChangedCommand = new Command(v =>
			{
				var val = (bool)v;
				if (val)
				{
					CurrentIndex += 1;
					return;
				}

				CurrentIndex -= 1;
			});

			RemoveCurrentItemCommand = new Command(() =>
			{
				if (!Items.Any())
				{ 
					return;
				}
				Items.RemoveAt(CurrentIndex.ToCyclingIndex(Items.Count));
			});
		}

		public ICommand PanPositionChangedCommand { get; }

		public ICommand RemoveCurrentItemCommand { get; }

		public int CurrentIndex
		{
			get => _currentIndex;
			set
			{
				_currentIndex = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentIndex)));
			}
		}

		public ObservableCollection<object> Items { get; }

        public ObservableCollection<string> SubItems { get; }

		private string CreateSource()
		{
			var source = $"https://picsum.photos/500/500?image={_ImageCount}";
			return source;
		}
	}
}