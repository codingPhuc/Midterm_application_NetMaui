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
        DateTime date = DateTime.Now;
        [ObservableProperty]
        int userId ;
        [ObservableProperty]
        int noteId ;
        public AddNotesViewModels()
        {  


        }
        [RelayCommand]
        public async Task SaveNote()
        {
            var note = new Data.Note
            {
                Title = Title,
                Content = Content,
                Date = Date,
                userId = userId,
                noteId = noteId
            };
            var navigationParameter = new Dictionary<string, object>()
        {
            { "note", note }
        };

            await Shell.Current.GoToAsync(".." , navigationParameter);
        }



        [RelayCommand]
        public async Task CancelNote()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
