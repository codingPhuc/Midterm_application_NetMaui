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
                if(value.ID == 0)
                {
                    var note = value;
                    var noteId = viewModel.Notes.LastOrDefault().ID +1;
                    note.ID = noteId; 
                    viewModel.Notes.Add(note);
                }

                else
                {
                    var note =  viewModel.Notes.FirstOrDefault(n => n.ID == value.ID);
                    note.Title = value.Title;
                    note.Content = value.Content;
                    note.createAt = value.createAt;

                }   
               
            }
        }

        

   
    }

}
