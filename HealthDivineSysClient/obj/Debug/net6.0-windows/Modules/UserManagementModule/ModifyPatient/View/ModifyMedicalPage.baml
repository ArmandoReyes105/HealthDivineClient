   M S B A M L   `   `   `  ����P  LHealthDivineSysClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Sclr-namespace:HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.ViewEHealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.View  5      a5clr-namespace:HealthDivineSysClient.View.UserControls'HealthDivineSysClient.View.UserControls  5      ]    WHealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.View.ModifyMedicalPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      elocalSclr-namespace:HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.View     5      JControls5clr-namespace:HealthDivineSysClient.View.UserControls     5        N� Title$  ModifyMedicalPage��5
      .��5      � -   5        $��	Main_Grid��5      $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	����6      Icon_Button#��[  6(   $��Center=�6M   $��0 0 15 0q�6h   ��6z   �� *ReturnCommand+�� 5      $B��<Mis pacientes >> Modificar información >> Historial médico��6     Normal_Text#��[ 6Z   $��Center=�6   5      �� 5   
   $ 
Horizontal=�6   $��Right=�6.   .+�5      �� $��Actualizar ��6     
Title_Text#��[ 6+   �� 5      $��Información��6   #��[ 6+     AccentColor#��[ 6O   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5       $��* �6#   .+�5$      �� $��0 20 0 0q�6   .+�5%      C   =HealthDivineSysClient.View.UserControls.ProgressCircleControl  -   5          Name$ Medical_ProgressControl��5%   1      Icon$	 ��6R      Text$ Historial médico��6c      LineVisibility$ 	Collapsed=�6{   5&      � 5)      -   5        $��	Form_Grid��5)      $��1��6$   $��	40 20 0 0q�64    5*      �� 5+      $
��auto �6$   �� 5,      $��* �6$   �� 5-      $
��auto �6$   .+�51      �� -   5        $��Header_TextBlock��51      $��Historial médico��64   #��[ 6L   �� 54      -   5        $��Medical_Panel��54      $��1��64   $
��Auto=�6A   .��55      �  56      �� 57      $��* �6/   $	��200��69   �� 58      $��* �6/   $	��200��69   .+�5;      �� $��	0 20 15 0q�6%   .+�5<      <   6HealthDivineSysClient.View.UserControls.DividerControl     DividerText$ Enfermedades��66   �� 5=      $��Enfermedades crónicas��6(     
Small_Text#��[ 6E   �� 5>      
	 � Tag$"	 ¿Que enfermedades presenta?��6n     Normal_TextBox#��[ 5?   &   
 �� TextWrapping$

 Wrap=�6N   ��5>   &   �� *ChronicalDiseases+ �� UpdateSourceTrigger$ PropertyChanged=�5?   N   �� 5@      $$��Antecedentes heredo-familiares��6(   #��[ 6N   �� 5A      $#	 ¿Enfermedades en su familia?��6t   #��[ 5B   &   $

 Wrap=�6N   ��5A   &   �� *HereditaryFamilyHistory+$ PropertyChanged=�5B   N   �� 5C      $%��Enfermedades gastrointestinales��6(   #��[ 6O   �� 5D      $	 ¿Malestar estomacal?��6u   #��[ 5E   &   $

 Wrap=�6N   ��5D   &   �� *GastrointestinalDiseases+$ PropertyChanged=�5E   N     5F      $ Alergias��66    � Cursor$  ��6M   �� 5G      $��Alergias alimenticias��6(   #��[ 6E   �� 5H      $"	 ¿Alergia a algún alimento?��6j   #��[ 5I   &   $

 Wrap=�6N   ��5H   &   �� *FoodAllergies+$ PropertyChanged=�5I   N   �� 5J      $��Alergias no alimenticias��6(   #��[ 6H   �� 5K      $4	 .¿Alergia a algún medicamento, producto, etc?��6m   #��[ 5L   
   $

 Wrap=�62   ��5K   &   �� *NonFoodAllergies+$ PropertyChanged=�5L   2   5M      �� 5N      $��1��6%   $��	15 20 0 0q�65   .+�5O        $ Historial médico��66   �� 5P      $��Historial quirúrgico��6(   #��[ 6D   �� 5Q      $	 ¿Le han operado?��6l   #��[ 5R   &   $

 Wrap=�6N   ��5Q   &   �� *SurgicalHistory+$ PropertyChanged=�5R   N   �� 5S      $��Medicamentos��6(   #��[ 6<   �� 5T      $ 	 ¿Toma algún medicamento?��6h   #��[ 5U   
   $

 Wrap=�62   ��5T   &   �� *Medications+$ PropertyChanged=�5U   2     5V      $ Comentarios��66   �� 5W      $$��Comentarios médicos generales��6(   #��[ 6M   �� 5X      $%	 ¿Algo que considere relevante?��6s   #��[ 5Y      $

 Wrap=�6)   ��5X   &   �� *GeneralMedicalComments+$ PropertyChanged=�5Y   )   �� 5Z        PrimaryTextColor#��[ 6%    �� CornerRadius$ 5��6U   $��1q�6f   ._�5[   "   � $��10q�6'    5\   &   �� 5]   *   $
��auto �6;   �� 5^   *   $��* �6;   .+�5`   &   �� $	����60     FontAwesomeSolid#��[ 6@   #��[ 6o   $��24(�6�   � 5a   &   $��1��6+   $��15 0 0 0q�6;   .+�5b   *   �� $����Los campos de información médica no son obligatorios, sin embargo, es FUNDAMENTAL rellenarla si es necesario, por el bien y salud de su paciente��64   #��[ 6�   $
��Wrap=�6�   5c   '   5d   #   5e      5f      5g      5h      �� 5j      -   5        $��Animation_Border��5j        BackgroundColor#��[ 61   $��2��6_   $	��Top=�6p   �� 5k      $ 
Horizontal=�6   $��2��66   $��Right=�6C   .+�5l      �� $	��200��6   $��
Actualizar��6*    	 Normal_Button#��[	 6@   ��6g   �� *
UpdateInfo+5m      5n      5o      5p      5q      