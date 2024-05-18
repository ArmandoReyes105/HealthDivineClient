using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using iTextSharp.text.pdf;
using iTextSharp.text;
using PlanManagementService;
using System;
using System.IO;
using System.Windows.Input;
using UserManagementService;
using System.Diagnostics;

namespace HealthDivineSysClient.Modules.PlanManagementModule.ExportPDF.ViewModel
{
    public class ExportPlanViewModel : ViewModelBase
    {
        //Atributes
        private MealPlan mealPlan; 
        private Patient patient;

        //Commands
        public ICommand ReturnCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SendCommand { get; }

        //Constructor
        public ExportPlanViewModel(int patientId)
        {
            ReturnCommand = new RelayCommand(ExecuteReturnCommand);
            SaveCommand = new RelayCommand(ExecuteSaveCommand);
            SendCommand = new RelayCommand(ExecuteSendCommand);

            LoadData(patientId); 
        }

        //Commands Implementation
        private void ExecuteReturnCommand(object obj)
        {
            NavigationManager.Instance.NavigateBack(); 
        }

        private void ExecuteSaveCommand(object obj)
        {
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = patient.Person.Names +  "_PlanAlimenticio.pdf"; 

            // Especificar el nombre y ruta completa del archivo PDF
            string filePath = Path.Combine(downloadsFolder, fileName);

            // Crear el documento PDF
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            // Abrir el documento para escribir contenido
            doc.Open();

            // Agregar los atributos del MealPlan
            doc.Add(new Paragraph("Paciente: " + patient.Person.Names + " " + patient.Person.FirstLastName));
            doc.Add(new Paragraph("Fecha: " + mealPlan.PlanDate.ToLongDateString()));
            doc.Add(new Paragraph("---------------------------------------------------------"));
            doc.Add(new Paragraph("Comentarios: " + mealPlan.Comments));
            doc.Add(new Paragraph("Recomendaciones: " + mealPlan.Recommendations));
            doc.Add(new Paragraph("Descripción del plan: " + mealPlan.PlanDescription));
            doc.Add(Chunk.NEWLINE);

            // Agregar los detalles de cada Meal
            foreach (Meal meal in mealPlan.Meals)
            {
                doc.Add(new Paragraph("---------------------------------------------------------"));
                doc.Add(new Paragraph("Tipo de Comida: " + meal.MealType));
                doc.Add(new Paragraph("Equivalencias: " + meal.Equivalences));
                doc.Add(new Paragraph("Ejemplos de Comida: " + meal.MealExamples));
                doc.Add(Chunk.NEWLINE);
            }

            // Cerrar el documento
            doc.Close();
            Debug.WriteLine("PDF generado con éxito en: " + filePath);
            DialogManager.ShowNotification("PDF generado con exito", "PGD generado en: " + filePath); 
        }

        private void ExecuteSendCommand(object obj)
        {

        }

        //Methods
        private async void LoadData(int id)
        {
            UserManagementClient patientClient = new UserManagementClient();
            patientClient.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10);

            PlanManagementServiceClient planClient = new();
            planClient.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(10); 

            try
            {
                patient = await patientClient.GetPatientAsync(id);
                mealPlan = await planClient.GetLastMealPlanAsync(id);

                if (patient != null && mealPlan != null)
                {
                    if(mealPlan.IdMealPlan == 0)
                    {
                        DialogManager.ShowNotification("Plan alimenticio inexistente", "Lo sentimos, pero al parecer aun no hay ningun plan asignado a este paciente");
                        NavigationManager.Instance.NavigateBack();
                    }
                }
                else
                {
                    DialogManager.ShowNotification("Error con la base de datos", "Lo sentimos, ocurrio un error al intentar recuperar la información de la base de datos,estamos trabajando para solucionarlo, por favor intentelo más tarde");
                    NavigationManager.Instance.NavigateBack();
                }
            }
            catch
            {
                DialogManager.ShowNotification("Error con el servidor", "Lo sentimos, ocurrio un error al conectarse con el servidor, revise su conexión a internet o intentelo más tarde");
                NavigationManager.Instance.NavigateBack(); 
            }
            finally
            {
                patientClient.Close();
                planClient.Close(); 
            }
        }
    }
}
