using HealthDivineSysClient.Helpers;
using HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.View;
using HealthDivineSysClient.ViewModel.ViewModelTemplates;
using ProgressManagementService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;

namespace HealthDivineSysClient.Modules.ProgressManagementModule.CreateProgressRecord.ViewModel
{
    class DiagnosisFormViewModel : ViewModelBase
    {
        //Atributes
        private int patientId = 0; 

        //Fields
        private Diagnosis _diagnosis = new(); 
        
        //Properties
        public Diagnosis Diagnosis
        {
            get => _diagnosis; 
            set
            {
                _diagnosis = value; OnPropertyChanged(nameof(Diagnosis));
            }
        }

        //Commands
        public ICommand NextCommand { get; }
        public ICommand ReturnCommand { get; }
        public ICommand AddImageCommand { get; }

        //Constructor
        public DiagnosisFormViewModel(int id)
        {
            NextCommand = new RelayCommand(ExecuteNextCommand);
            ReturnCommand = new RelayCommand(ExecuteReturnCommand);
            AddImageCommand = new RelayCommand(ExecuteAddImageCommand); 

            patientId = id;
            Diagnosis.PatientId = patientId;
        }

        //Commands Methods

        private void ExecuteAddImageCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new AddImagePage()); 
        }

        private void ExecuteNextCommand(object obj)
        {
            if (AreFieldsComplete())
            {
                Diagnosis.PatientId = patientId; 
                Diagnosis.DiagnosisDate = DateTime.Today;
                NavigationManager.Instance.NavigateTo(new MeasuresFormPage(Diagnosis)); 
            }
            else
            {
                DialogManager.ShowNotification("Campos incompletos", "Para poder pasar a la siguiente etapa todos los campos deben estar completos"); 
            }
        }

        private void ExecuteReturnCommand(object obj)
        {
            NavigationManager.Instance.NavigateBack(); 
        }

        //Methods
        private bool AreFieldsComplete()
        {
            List<string> fields = new()
            {
                Diagnosis.PhysicalActivity,
                Diagnosis.PhysicalPerception,
                Diagnosis.StomachUpset,
                Diagnosis.Dream,
                Diagnosis.EnergyLevel,
                Diagnosis.StressLevel,
                Diagnosis.Feeding,
                Diagnosis.Appetite,
                Diagnosis.WaterConsumption,
                Diagnosis.SubstanceUse,
                Diagnosis.GeneralComments
            };

            Debug.WriteLine(Diagnosis.PhysicalActivity) ; 

            return ValidationManager.AreAllFieldsComplete(fields); 
        }
    }
}
