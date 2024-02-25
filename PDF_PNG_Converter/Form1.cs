
using System.Drawing.Imaging;
using System.Reflection.Metadata;
using PdfiumViewer;



namespace PDF_PNG_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_File_Select_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var file_PDF_Path = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect= true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var files_PDF_Paths = openFileDialog.FileNames;
                    
                    //try
                    {
                        for (int i = 0; i < files_PDF_Paths.Length; i++)
                            
                        {
                            var document = PdfiumViewer.PdfDocument.Load(files_PDF_Paths[i]);
                            
                                var image = document.Render(0, 300, 300, PdfRenderFlags.CorrectFromDpi);
                                var file_PNG_Path = new FileInfo(files_PDF_Paths[i]).Directory;
                                string stringToSavePNG = String.Format(file_PNG_Path + "\\" + "scr{0}.jpg", i);
                                //MessageBox.Show(stringToSavePNG);
                                image.Save(String.Format(stringToSavePNG), ImageFormat.Jpeg);
                            
                        }
                        
                        //catch (Exception ex)
                        {
                           // MessageBox.Show("Error");
                        }
                    }

                }
            }

            


        }
    }
}