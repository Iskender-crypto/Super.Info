using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace News.App
{
    public class MainPageViewModel : BindableObject
    {
        private ObservableCollection<NewsItem> _newsItems;
        private bool _isLoading;

        public MainPageViewModel()
        {
            NewsItems = new ObservableCollection<NewsItem>();
            RefreshCommand = new Command(async () => await RefreshNewsAsync());
            LoadNews();
        }

        public ObservableCollection<NewsItem> NewsItems
        {
            get => _newsItems;
            set
            {
                _newsItems = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; }

        private void LoadNews()
        {
            // Загружаем начальные данные (например, заглушки)
            NewsItems.Add(new NewsItem
            {
                Title = "Hello World",
                Summary = "A Florida Proud Boys member and adult film star involved in the January 6 insurrection has been sentenced to two years in jail for his actions. This includes a year of supervised release after serving",
                Date = DateTime.Now,
                ImageUrl = "https://thumbs.dreamstime.com/b/news-woodn-dice-depicting-letters-bundle-small-newspapers-leaning-left-dice-34802664.jpg"
            });
            NewsItems.Add(new NewsItem
            {
                Title = "News 2",
                Summary = "Summary 2",
                Date = DateTime.Now,
                ImageUrl = "https://example.com/image2.jpg"
            });
        }

        private async Task RefreshNewsAsync()
        {
            IsLoading = true;

            // Имитация загрузки данных
            await Task.Delay(2000);

            // Обновление данных
            NewsItems.Clear();
            NewsItems.Add(new NewsItem
            {
                Title = "Updated News 1",
                Summary = "Updated Summary 1",
                Date = DateTime.Now,
                ImageUrl = "https://thumbs.dreamstime.com/b/news-woodn-dice-depicting-letters-bundle-small-newspapers-leaning-left-dice-34802664.jpg"
            });
            
                NewsItems.Add(new NewsItem
                {
                    Title = "Hello World",
                    Summary = "A Florida Proud Boys member and adult film star involved in the January 6 insurrection has been sentenced to two years in jail for his actions. This includes a year of supervised release after serving",
                    Date = new DateTime(2024, 2, 24),
                    ImageUrl = "https://thumbs.dreamstime.com/b/news-woodn-dice-depicting-letters-bundle-small-newspapers-leaning-left-dice-34802664.jpg"
                });
                // Добавьте вторую новость здесь, если это необходимо.
            


            IsLoading = false;
        }
    }
}
