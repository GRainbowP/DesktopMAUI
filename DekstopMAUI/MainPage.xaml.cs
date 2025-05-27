namespace DekstopMAUI
{
    public partial class MainPage : ContentPage
    {
        string password = string.Empty;

        string smallLettersList = "abcdefghijklmnopqrstuvwxyz";
        string bigLettersList = "abcdefghijklmnopqrstuvwxyz".ToUpper();
        string numbersList = "0123456789";
        string specialLettersList = "!@#$%^&*()_+-=";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void GeneratePass_Clicked(object sender, EventArgs e)
        {
            int chars = Int32.Parse(HowManyChars.Text);

            bool letters = SmallAndBigLetters.IsChecked;
            bool numbers = Numbers.IsChecked;
            bool specialChars = SpecialLetters.IsChecked;

            Random r = new Random();

            char[] pass = new char[chars];

            if(numbers) pass[0] = numbersList[r.Next(1, numbersList.Length)];
            if(specialChars) pass[1] = specialLettersList[r.Next(1, specialLettersList.Length)];
            if(letters) pass[2] = bigLettersList[r.Next(1, bigLettersList.Length)];

            for(int i = 3; i < chars; i++)
            {
                pass[i] = smallLettersList[r.Next(i, smallLettersList.Length)];
            }

            for (int i = 0; i < pass.Length; i++)
            {
                password += pass[i];
            }


            await Application.Current.MainPage.DisplayAlert("", $"{password}", "OK");
        }

        private async void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string role = PickerRole.Items[PickerRole.SelectedIndex];

            await Application.Current.MainPage.DisplayAlert("", $"Dane pracownika: {firstName} {lastName} {role} Hasło: {password}", "OK");
        }
    }

}
