using ImageClassificationApp.Forms;

namespace ImageClassificationApp
{
    public static class CustomMessageBox
    {
        public static DialogResult Show(string predictedName) 
        {
            DialogResult result = DialogResult.None;
            using (CustomMessageBoxForm customMessageBoxForm = new()) 
            {
                customMessageBoxForm.Message = predictedName;
                result = customMessageBoxForm.ShowDialog();
            }       
            return result;
        }
    }
}
