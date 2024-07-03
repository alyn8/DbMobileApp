using DbMyDemo.Models;

namespace DbMyDemo;

public partial class CoursePage : ContentPage
{
    private CourseClass _selectedCourse;

    public CourseClass SelectedCourse
    {
        get=> _selectedCourse;
        set
        {
            if(_selectedCourse != value)
            {
                _selectedCourse = value;
                OnPropertyChanged();
                DeleteButton.IsVisible = _selectedCourse != null;
            }
        }
    }
	public CoursePage()
	{
		InitializeComponent();
        LoadCourses();
        this.BindingContext = this;
    }

    private void LoadCourses()
    {
       
       Crs_List_View.ItemsSource = App.DBTrans.GetAllCourses();
    }

    private  void Btn_Crs_Add_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(CourseCode.Text) || string.IsNullOrEmpty(CourseName.Text))
        {
            DisplayAlert("Error", "Course code and name cannot be empty.", "OK");
            return;
        }

        var newCourse = new CourseClass
        {
            CourseID = int.Parse(CourseCode.Text),
            Name = CourseName.Text
        };

        App.DBTrans.AddCourse(newCourse);
        LoadCourses();

    }

    private  void Button_Clicked(object sender, EventArgs e)
    {
        if (SelectedCourse == null)
        {
            DisplayAlert("Error", "No course selected.", "OK");
            return;
        }

        App.DBTrans.DeleteCourse(SelectedCourse.CourseID);
        LoadCourses();
        SelectedCourse = null; 
    }
}