   M S B A M L   `   `   `  ����P  LHealthDivineSysClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Sclr-namespace:HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.ViewEHealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.View  5      a5clr-namespace:HealthDivineSysClient.View.UserControls'HealthDivineSysClient.View.UserControls  5      ]    WHealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.View.ModifyPatientPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      elocalSclr-namespace:HealthDivineSysClient.Modules.UserManagementModule.ModifyPatient.View     5      JControls5clr-namespace:HealthDivineSysClient.View.UserControls     5        N� Title$  PersonalInfoPage��5
      .��5      � -   5        $��	Main_Grid��5      $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	����6      Icon_Button#��[  6(   $��Center=�6M   $��0 0 15 0q�6h   ��6z   �� *CancelCommand+�� 5      $F��@Mis pacientes >> Modificar información >> Información personal��6     Normal_Text#��[ 6^   $��Center=�6�   5      �� 5   
   $ 
Horizontal=�6   $��Right=�6.   .+�5      �� $��Actualizar ��6     
Title_Text#��[ 6+   �� 5      $��Paciente��6   #��[ 6(     AccentColor#��[ 6L   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5       $��* �6#   .+�5$      �� $��0 20 0 0q�6   .+�5%      C   =HealthDivineSysClient.View.UserControls.ProgressCircleControl  -   5          Name$ Personal_ProgressControl��5%   1      Icon$	 ��6S      Text$ Información personal��6c      LineVisibility$ 	Collapsed=�6   5&      � 5)      -   5        $��	Form_Grid��5)      $��1��6$   $��	40 20 0 0q�64    5*      �� 5+      $
��auto �6$   �� 5,      $��* �6$   �� 5-      $
��auto �6$   .+�51      �� -   5        $��Header_TextBlock��51      $��Información personal��64   #��[ 6P   �� 53      -   5        $��Personal_Panel��53      $��1��65   $
��Auto=�6B   $	��500��6e   $
��auto=�6t     Nomal_ScrollViewer#��[ 6�   $y�Visible=�6�   .��54      � $��1��6   $
��0 20q�6(    55      �� 56      $
��auto �6/   �� 57      $��* �6/   .+�5:      �� .+�5;      <   6HealthDivineSysClient.View.UserControls.DividerControl     DividerText$ Nombre completo��66   �� 5<      $��	Nombre(s)��6(     
Small_Text#��[ 69   �� 6^   $� *��6b   
���  ��6l   6�   �� 5=        Normal_TextBox#��[ 6&   
	 � Tag$	 Nombre��6�   $	��270��6�   $
��Left=�6�   
 �� 	MaxLength$
 50��6�    � Cursor$ IBeam��6�   ��6N   �� *Patient.Person.Names+ �� UpdateSourceTrigger$ PropertyChanged=�6�   � 5>       5?   "   �� 5@   &   $
��auto �67   �� 5A   &   $
��auto �67   .+�5C   "   �� $��0 0 5 0q�6-   .+�5D   &   �� $��Primer apelllido��60   #��[ 6H   �� 6m   $	� * ��6q   
���  ��6|   6�   �� 5E   &   #��[ 6.   $	 Primer apellido��6�   $	��270��6�   $
��Left=�6�   $
 50��6�   ��6V   �� *Patient.Person.FirstLastName+$ PropertyChanged=�6�   5F   #   �� 5G   "   $��1��6-   $��5 0 0 0q�6=   .+�5H   &   �� $��Segundo apelllido��60   #��[ 6I   �� 6n   $	� * ��6r   
���  ��6}   6�   �� 5I   &   #��[ 6.   $	 Segundo apellido��6�   $	��270��6�   $
��Left=�6�   $
 50��6�   ��6V   �� *Patient.Person.SecondLastName+$ PropertyChanged=�6�   5J   #   5K        5M      $ Contacto��66   �� 5N      $��	Teléfono��6(   #��[ 68   �� 6]   $	� * ��6a   
���  ��6l   6�   �� 5O      -   5        #��[ 5P      $	 000-000-0000��5R      $	��270��5S      $
��Left=�5W      $
 12��5X      ��5Q      �� *Phone+$ PropertyChanged=�5X      �� 5Y      $��Correo electronico��6(   #��[ 6B   �� 6g   $	� * ��6k   
���  ��6v   6�   �� 5Z      #��[ 6&   $	 ejemplo@gmail.com��6�   $	
 250��6�   ��6N   �� *Patient.Person.Email+$ PropertyChanged=�6�   5[      �� 5\      $��1��6%   $��30 0 0 0q�65   .+�5]        $ Información��66   � 5^       5_   "   �� 5`   &   $
��auto �67   �� 5a   &   $
��auto �67   �� 5b   &   $
��auto �67   �� 5c   &   $
��auto �67    5e   "   �� 5f   &   $
��auto �64   �� 5g   &   $
��auto �64   .+�5j   "   �� $��Fecha de nacimiento��6,   #��[ 6G   �� 6l   $� *��6p   
���  ��6z   6�   �� 5k   "   $��Edad: 00 años��6,   $��1��6A   #��[ 6Q   �� 5l   "   $��Estatura��6,   $��2��6<   #��[ 6L   �� 6q   $� *��6u   
���  ��6   6�   �� 5m   "   $��Metros��6,   $��3��6:   $��1��6J   #��[ 6W   $	��Top=�6{   $��10 20q�6�   ?   9HealthDivineSysClient.View.UserControls.DatePickerControl  5o   "   $��1��6�   $��2��6�   $��0 0 10 0q�6�   $	��270��6�      Text 6=   �� *
Birthday+ �� Mode$ TwoWay=�$ PropertyChanged=�6�   �� 5p   "   -   5        $��1��5q   !   $��2��5r   !   #��[ 5s   !   $
	 0.00��5u   !   $��70��6,   $
��Left=�5y   !   $	��Top=�5z   !   $
 4��5{   !   ��5t   !   �� *Height+$ PropertyChanged=�5{   !   5|      �� 5}      $
��Sexo��6(   #��[ 64   $  ��6X   �� 6c   $� *��6g   
���  ��6q   6�   �� 5~      $ 
Horizontal=�6)   $��0 5 0 15q�6B   .+�5   "   	� -   5        $��Male_RadioBtn��5   .     BigIcon_RadioButton#��[ 6C   $��M��6�   $��	Masculino��6�    d� 	IsChecked$
 TrueY�6�   $		 ��6�   ��6p   �� *ChangeGender+6�   	� 5�   "   -	   5        $��Female_RadioBtn��5�   .   #��[ 6E   $��F��6�   $��Femenino��6�   $		 ��6�   $
��10 0q�6�   ��6r   �� *ChangeGender+6�   5�      �� 5�      $%��* El correo debe ser @gmail.com��6(   #��[ 6O   $��Right=�6s   �� 5�      $"��* Indica campos obligatorios��6(   #��[ 6L   $��Right=�6p   �� 6�   $� *��6�   
���  ��6�   6�   5�      5�      5�      �� 5�      -
   5        $��Animation_Border��5�        BackgroundColor#��[ 61   $��2��6_   $��0��6p   $	��Top=�6{   �� 5�      $ 
Horizontal=�6   $��2��66   $��Right=�6C   .+�5�      �� $��Cancelar��6?   $��2��6R   $	��200��6_    	 Border_Button#��[	 6k   $��0 0 15 0q�6�   ��6   �� *CancelCommand+6�   �� 5�      $	��200��6   $��
Actualizar��6)    
 Normal_Button#��[
 6>   ��6f   �� *UpdateCommand+5�      5�      5�      5�      5�      