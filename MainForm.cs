using MaterialSkin;
using MaterialSkin.Controls;
using static ImageClassificationApp.MLModelTheSimpsons;

namespace ImageClassificationApp
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager _materialSkinManager;

        public MainForm()
        {
            _materialSkinManager = MaterialSkinManager.Instance;
            InitializeComponent();
            InitializeMaterialSkin();
        }
        private void InitializeMaterialSkin()
        {
            _materialSkinManager.EnforceBackcolorOnAllComponents = true;
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            _materialSkinManager.ColorScheme = new ColorScheme(Color.FromArgb(47, 100, 214), Color.FromArgb(47, 100, 214), Color.FromArgb(47, 100, 214), Color.FromArgb(47, 100, 214), TextShade.WHITE);
        }

        private void LoadImage(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName is not null) { 
                pictureBox1.ImageLocation = openFileDialog.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void EvaluateImage(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pictureBox1.ImageLocation))
                return;

            EnableForm();
            var predictionResult = GetPrediction();

            DisableForm();
            CustomMessageBox.Show(predictionResult);
        }
        private string GetPrediction() 
        {
            var imageBytes = File.ReadAllBytes(pictureBox1.ImageLocation);
            ModelInput input = new();
            input.ImageSource = imageBytes;
            var result = MLModelTheSimpsons.Predict(input);
            double acceptableValue = 0.50;

            return result.Score.All(x => x < acceptableValue) ?
                "This picture does not match a Simpsons family member." : result.PredictedLabel;
        }
        private void EnableForm() 
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
        }
        private void DisableForm()
        {
            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }
    }
}