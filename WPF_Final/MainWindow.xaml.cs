using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WPF_Final.Models;

namespace WPF_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       static int index = 0;
      


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DataSource();

        }
        class DataSource : INotifyPropertyChanged
        {
            private readonly Command addCommand;
            private readonly Command deleteCommand;
            private readonly Command changeCommand;

            private readonly Command addCommand2;
            private readonly Command deleteCommand2;
            private readonly Command changeCommand2;
            private  ObservableCollection<Project> projects;
            private ObservableCollection<MyTask> tasks;


            public DataSource()
            {
                addCommand = new DelegateCommand(() => Add());
                deleteCommand = new DelegateCommand(() => Delete());
                changeCommand = new DelegateCommand(() => Change());

                addCommand2 = new DelegateCommand(() => AddTask());
                deleteCommand2 = new DelegateCommand(() => DeleteTask());
                changeCommand2 = new DelegateCommand(() => ChangeTask());

                projects = new ObservableCollection<Project>();
                tasks = new ObservableCollection<MyTask>();

                PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName.Equals(nameof(projects)))
                    {
                        addCommand.RaiseCanExecuteChanged();
                        changeCommand.RaiseCanExecuteChanged();
                        deleteCommand.RaiseCanExecuteChanged();

                        addCommand2.RaiseCanExecuteChanged();
                        changeCommand2.RaiseCanExecuteChanged();
                        deleteCommand2.RaiseCanExecuteChanged();
                    }
                };
            }
            public ICommand AddCommand => addCommand;
            public ICommand DeleteCommand => deleteCommand;
            public ICommand ChangeCommand => changeCommand;

            public ICommand AddTaskCommand => addCommand2;
            public ICommand DeleteTaskCommand => deleteCommand2;
            public ICommand ChangeTaskCommand => changeCommand2;


            public ObservableCollection<Project> Collection
            {
                get => projects;
                set
                {

                    projects = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Collection)));

                }
            }

            public ObservableCollection<MyTask> Collection2
            {
                get => projects[index].Tasks;
                set
                {

                    projects[index].Tasks = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Collection2)));

                }
            }
            public void Add()
            {
                AddProjectWindow w1 = new AddProjectWindow();
                w1.ShowDialog();
                Project project = new Project()
                {
                    Name = w1.Text,
                    Description = w1.Text2,
                    Tasks = new ObservableCollection<MyTask>()
                };
                projects.Add(project);
            }
            public void Delete()
            {
                projects.RemoveAt(index);
            }
            public void Change()
            {
                AddProjectWindow w1 = new AddProjectWindow();
                w1.Text = projects[index].Name;
                w1.Text2 = projects[index].Description;

                w1.ShowDialog();
                Project project = new Project()
                {
                    Name = w1.Text,
                    Description = w1.Text2,
                    Tasks = new ObservableCollection<MyTask>()

                };
                projects[index]= project;
               




            }
       




            public void AddTask()
            {
                AddTaskWindow w1 = new AddTaskWindow();
                w1.ShowDialog();
                MyTask task = new MyTask()
                {
                    Name = w1.Text1,
                    Description = w1.Text2,
                    IsCompleted = Convert.ToBoolean(w1.Status),
                    Priority=w1.Priority
               };
                projects[index].Tasks.Add(task);
            }
            public void DeleteTask()
            {

                projects[index].Tasks.RemoveAt(0);

            }
            public void ChangeTask()
            {
                //AddTaskWindow w1 = new AddTaskWindow();
                //w1.Text = projects[index].Name;
                //w1.Text2 = projects[index].Description;

                //w1.ShowDialog();
                //Project project = new Project()
                //{
                //    Name = w1.Text,
                //    Description = w1.Text2
                //};
                //projects[index] = project;





            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                PropertyChanged?.Invoke(this, e);
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index=listBox1.SelectedIndex;
        }
    }

   
}