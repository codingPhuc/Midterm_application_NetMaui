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
           
            Notes.Clear();
            var notes = await NoteManagement.GetAll();
            foreach (var note in notes)
            {
                Notes.Add(note);
            }
        }

        [RelayCommand]
        async Task AddNotes()
        {
            
           

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
           await NoteManagement.Delete(note.ID);
            WeakReferenceMessenger.Default.Send(new RefreshMessage(true));
        }
        [RelayCommand]
        async Task SignOut()
        {
            bool answer = await Shell.Current.DisplayAlert("Confirmation", "Do you really want to sign out?", "Yes", "No");
            if (answer)
            {
                await Shell.Current.GoToAsync("//SignIn");
            }

        }


    }
}
