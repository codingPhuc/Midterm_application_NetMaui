using MidtermProject.Data;
using MidtermProject.ViewModel;



namespace MidtermProject
{
    [QueryProperty("AddedNote", "note")]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel = new MainPageViewModel(); 
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel; 
        }

        public Note AddedNote
        {       

            set
            { 
                if(value.noteId == 0)
                {
                    var note = value;
                    var noteId = viewModel.Notes.LastOrDefault().noteId +1;
                    note.noteId = noteId; 
                    viewModel.Notes.Add(note);
                }

                else
                {
                    var note =  viewModel.Notes.FirstOrDefault(n => n.noteId == value.noteId);
                    note.Title = value.Title;
                    note.Content = value.Content;
                    note.Date = value.Date;

                }   
               
            }
        }

        

   
    }

}
