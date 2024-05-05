using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MidtermProject.Data;
using System.Collections.ObjectModel;

namespace MidtermProject.ViewModel
{
   
    public  partial class  MainPageViewModel : ObservableObject
    {



       
        [ObservableProperty] 
        ObservableCollection<Note> notes;
        public MainPageViewModel()
        {
            notes = new ObservableCollection<Note>();

            WeakReferenceMessenger.Default.Register<RefreshMessage>(this, async (r, m) =>
            {
                await LoadNotes();
            });

            Task.Run(LoadNotes);
           
        }
        [ObservableProperty]
        string name = ""; 

        [RelayCommand]
        async Task LoadNotes()
        {
            Random rnd = new Random();
            
            for (int i =1; i<=10; i++)
            {
                var note = new Note
                { 
                    userId = rnd.Next(0, 2),
                    noteId = i,
                    Title = $"Note {i}",
                    Content = $"Content {i}",
                    Date = DateTime.Now 


                }; 
                Notes.Add(note);
            }
        }

        [RelayCommand]
        async Task AddNotes()
        {
            
            var note = new Note
            {   
                userId = 1, 
                noteId = Notes.Count + 1,
                Title = $"Note {Notes.Count + 1}",
                Content = $"Content {Notes.Count + 1}",
                Date = DateTime.Now

            };
            Notes.Add(note);
            await Shell.Current.GoToAsync("AddNotes");
        }

        [RelayCommand]
        async Task EditNote(Note note)
        {

            var navigationParameter = new Dictionary<string, object>()
        {
            { "note", note }
        };

            await Shell.Current.GoToAsync("AddNotes", navigationParameter);
         
        }


        [RelayCommand] 
        async Task DeleteNotes(Note note)
        {
            Notes.Remove(note);
        }
      
         
    }
}
