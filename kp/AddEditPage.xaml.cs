using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Tour _currentTour;
        private List<Tour> _tours;

        public AddEditPage(Tour selectedTour, List<Tour> tours)
        {
            InitializeComponent();
            _tours = tours;

            if (selectedTour != null)
            {
                _currentTour = TourCompanyEntities1.GetContext().Tours.FirstOrDefault(t => t.TourID == selectedTour.TourID);
            }
            else
            {
                _currentTour = new Tour();
                TourCompanyEntities1.GetContext().Tours.Add(_currentTour);
            }

            DataContext = _currentTour;
            ComboCities.ItemsSource = TourCompanyEntities1.GetContext().Cities.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentTour.TourName == null || _currentTour.TourName.Trim() == "")
            {
                errors.AppendLine("Введите название тура");
            }
            if (_currentTour.City == null)
            {
                errors.AppendLine("Выберите город");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                TourCompanyEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}