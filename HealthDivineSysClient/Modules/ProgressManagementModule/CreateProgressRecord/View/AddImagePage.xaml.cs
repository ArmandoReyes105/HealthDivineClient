using Microsoft.Win32;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.Data;
using ProgressManagementService;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.View
{
    public partial class AddImagePage : Page
    {

        private byte[] imagenBytes = null;

        public AddImagePage()
        {
            InitializeComponent();
        }

        private void BtnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                imgPreview.Source = bitmap;
                imagenBytes = File.ReadAllBytes(filePath);
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.Instance.NavigateBack(); 
        }

        private void BtnSaveImage_Click(object sender, RoutedEventArgs e)
        {
            if (imagenBytes != null)
            {
                if(imagenBytes.Length < 50 * 1024)
                {
                    if (!string.IsNullOrWhiteSpace(Comments_TextBox.Text))
                    {
                        DiagnosisImage image = new DiagnosisImage();
                        image.Image = imagenBytes;
                        image.Comments = Comments_TextBox.Text;

                        RegisterRecordInfo.Instance.Diagnosis.Image = image;
                        NavigationManager.Instance.NavigateBack();
                    }
                    else
                    {
                        DialogManager.ShowNotification("Campos vacios", "Debe tener un texto para poder guardar la imagen");
                    }
                }
                else
                {
                    DialogManager.ShowNotification("Archivo demasiado grande", "El tamaño maximo de archivo permitidos es de 50 KB"); 
                }
                
            }
            else
            {
                DialogManager.ShowNotification("No hay imagen", "No ah seleccionado ninguna imagen, por lo tanto no puede guardarla"); 
            }
        }

    }
}
