using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MidtermProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MidtermProject.ViewModel
{   
    public partial class AddNotesViewModels : ObservableObject
    {

        [ObservableProperty]
        string title = "";
        [ObservableProperty]
        string content = "";
        [ObservableProperty]
        string date = "";
        [ObservableProperty]
        string userId ;
        [ObservableProperty]
        int noteId = 0 ;
        public AddNotesViewModels()
        {  


        }
        [RelayCommand]
        public async Task SaveNote()
        {


            if (NoteId == 0)
            {
                await NoteManagement.Add(Title, Content);
            }
            else
            {
                await NoteManagement.Update( Title, Content, NoteId );
            }
          
            WeakReferenceMessenger.Default.Send(new RefreshMessage(true));
            await Shell.Current.GoToAsync(".." );
        }



        [RelayCommand]
        public async Task CancelNote()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
