using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CqrsIntroduction;

namespace TestClient
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<NameId> Candidates { get; set; }
        public ObservableCollection<NameId> Animals { get; set; }

        private readonly NameId[] availableCandidates
            = new[]
                  {
                      new NameId{Id = Guid.NewGuid(), Name = "Ann"},
                      new NameId{Id = Guid.NewGuid(), Name = "Robert"},
                      new NameId{Id = Guid.NewGuid(), Name = "Joe"},
                      new NameId{Id = Guid.NewGuid(), Name = "Sue"},
                      new NameId{Id = Guid.NewGuid(), Name = "Sarah"},
                      new NameId{Id = Guid.NewGuid(), Name = "Norbert"},
                  };

        private readonly NameId[] availableAnimals
            = new[]
                  {
                      new NameId {Id = Guid.NewGuid(), Name = "A0001"},
                      new NameId {Id = Guid.NewGuid(), Name = "A0002"},
                      new NameId {Id = Guid.NewGuid(), Name = "A0003"},
                      new NameId {Id = Guid.NewGuid(), Name = "Ab0001"},
                      new NameId {Id = Guid.NewGuid(), Name = "Ab0002"},
                      new NameId {Id = Guid.NewGuid(), Name = "Ab0003"},
                      new NameId {Id = Guid.NewGuid(), Name = "Ab0004"},
                  };

        private readonly Random random = new Random((int) DateTime.Now.Ticks);

        public MainWindow()
        {
            Candidates = new ObservableCollection<NameId>(); 
            Animals = new ObservableCollection<NameId>();
            DataContext = this;

            InitializeComponent();
        }

        private void OnNewTask(object sender, RoutedEventArgs e)
        {
            TaskName.Text = null;
            DueDate.SelectedDate = DateTime.Today;
            Instructions.Text = null;
            Animals.Clear();
            Candidates.Clear();
            TaskName.Focus();

            ScheduleTask.IsEnabled = true;
            NewTask.IsEnabled = false;
        }

        private void OnScheduleNewTask(object sender, RoutedEventArgs e)
        {
            var command = new ScheduleNewTask
                              {
                                  Id = new TaskId(Guid.NewGuid()),
                                  TaskName = TaskName.Text,
                                  DueDateTime = DueDate.SelectedDate.GetValueOrDefault(),
                                  Instructions = Instructions.Text,
                                  CandidateIds = Candidates.Select(x => x.Id).ToArray(),
                                  AnimalIds = Animals.Select(x => x.Id).ToArray()
                              };
            Bus.Send(command, result => OnNewTask(null, null));
        }

        private void OnAddCandidate(object sender, RoutedEventArgs e)
        {
            if (Candidates.Count == availableCandidates.Count()) return;
            var diff = availableCandidates.Except(Candidates).ToArray();
            var index = random.Next(diff.Count());
            Candidates.Add(diff[index]);
        }

        private void OnAddAnimal(object sender, RoutedEventArgs e)
        {
            if (Animals.Count == availableAnimals.Count()) return;
            var diff = availableAnimals.Except(Animals).ToArray();
            var index = random.Next(diff.Count());
            Animals.Add(diff[index]);
        }
    }
}
