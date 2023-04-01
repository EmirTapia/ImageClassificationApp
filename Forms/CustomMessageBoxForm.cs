using MaterialSkin;
using MaterialSkin.Controls;

namespace ImageClassificationApp.Forms
{
    public partial class CustomMessageBoxForm : MaterialForm
    {
        private readonly MaterialSkinManager _materialSkinManager;
        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }
        public CustomMessageBoxForm()
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
    }
}
