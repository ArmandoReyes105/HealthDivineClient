   M S B A M L   `   `   `  ����P  LHealthDivineSysClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Tclr-namespace:HealthDivineSysClient.Modules.PlanManagementModule.UpdateMealPlan.ViewFHealthDivineSysClient.Modules.PlanManagementModule.UpdateMealPlan.View  5      a5clr-namespace:HealthDivineSysClient.View.UserControls'HealthDivineSysClient.View.UserControls  5      [    UHealthDivineSysClient.Modules.PlanManagementModule.UpdateMealPlan.View.UpdateMealPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      flocalTclr-namespace:HealthDivineSysClient.Modules.PlanManagementModule.UpdateMealPlan.View     5      JControls5clr-namespace:HealthDivineSysClient.View.UserControls     5        N� Title$  UpdateMealPage��5
      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   ]� .+�5      �� $
��Left=�6    �� Orientation$ 
Horizontal=�64   .+�5      �� $	����6      Icon_Button#��[  6,   $��Center=�6Q   ��6l   �� *ReturnCommand+�� 5      $1��+Mis pacientes >> Modificar plan alimenticio��6   $��15 0 0 0q�6O     Normal_Text#��[ 5      $��Center=�6A   5      �� 5      $ 
Horizontal=�6   $��Right=�62   .+�5      �� $��Modificar plan ��6     
Title_Text#��[ 63   �� 5      $��alimenticio��6   #��[ 6/     AccentColor#��[ 6S   5      5      � 5"   
   $��0 20 0 0q�6   $��1��6!    � ColumnDefinitions 5#      �� 5$      $��* �6#   �� 5%      $��40 �6#   �� 5&      $��* �6#   .+�5*      �  5+      �� 5,      $��* �6$   �� 5-      $��* �6$   .+�50      �� .+�51      <   6HealthDivineSysClient.View.UserControls.DividerControl     DividerText$ Comentarios��6.   �� 52      $��Descripción del plan��6      
Small_Text#��[ 6<   �� 53        Normal_TextBox#��[ 6I    �� TextWrapping$
 Wrap=�6q   ${�False��6�   ��6   �� *MealPlan.PlanDescription+6�   �� 55      $��Comentarios��6    #��[ 63   �� 56      #��[ 6A   $
 Wrap=�6i   ${�False��6}   ��6   �� *MealPlan.Comments+6}   �� 58      $��Recomendaciones��6    #��[ 67   �� 59      #��[ 6I   $
 Wrap=�6q   ${�False��6�   ��6   �� *MealPlan.Recommendations+6�   5:      �� 5<      $��1��6   .+�5=        $ Comidas agregadas��6.   �� 5>      ��6#   �� *Meals+��5?      �� 5@      .R�5A   "   �� 5B      ��5D      �� 5E      .R�5F   "   ��   PrimaryColor#��[ 6)    �� CornerRadius$ 5��6T   $��0 0 0 5q�6e   ._�5G   &   �  5H   *   �� 5I   .   $��* �6?   �� 5J   .   $
��auto �6?   .+�5L   *   �� $��10q�65   .+�5M   .   �� #��[ 6R   ��68   �� *
MealType+6R   �� 5N   .     SuperSmall_Text#��[ 6V   #��[ 6   $��0 5 0 0q�6�   ��68   �� *Equivalences+6�   5O   +   �� 5P   *   $��1��61   $	����6A   #��[  6T   $��Center=�5Q   1   $��Right=�6L     FontAwesomeRegular#��[ 5R   1   $��10q�6b   ��5S   1   �� *DataContext.SetMealCommand+ �� RelativeSource ��  �� Mode$ FindAncestor=�	 �� AncestorType"	 ����5T   1   �� *IdMeal+5U   '   5V   #   5W      5Y      5Z      5[      �� 5]       	 PrimaryTextColor#��[	 6   $��1��6D   $��1��6T   $��Center=�6^   �� 5`      $��2��6   .+�5a      �� $��Tipo de comida��6   #��[ 62   �� 6W   $� *��6[   
���  ��6e   6y   �� 5b      #��[ 64   

 � Tag$"
 Desayuno, Comida, Cena, etc.��6\   ��6   �� *
MealType+6\   �� 5d      $��Equivalencias��6   #��[ 61   �� 6V   $� *��6Z   
���  ��6d   6x   �� 5e      #��[ 68   $#
 0 Proteina + 0 Verdura + etc.��6`   $
 Wrap=�6�   ��6   �� *Equivalences+6�   �� 5g      $��Ejemplos de comidas��6   #��[ 67   �� 6\   $� *��6`   
���  ��6j   6~   �� 5h      #��[ 68   $
 Omelette: 2 pzas de huevo��6`   $
 Wrap=�6�   ��6   �� *MealExamples+6�   5i      �� 5k      $��2��6   $��Actualizar comida��6%   $��Bottom=�6A    
 Normal_Button#��[
 6\   $��Right=�6�   $	��200��6�   ��6�   �� *UpdateMealCommand+5l      5m      5n      