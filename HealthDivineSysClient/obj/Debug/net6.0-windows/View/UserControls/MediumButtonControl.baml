   M S B A M L   `   `   `  ����P  LHealthDivineSysClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:HealthDivineSysClient.View.UserControls'HealthDivineSysClient.View.UserControls  5      A    ;HealthDivineSysClient.View.UserControls.MediumButtonControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:HealthDivineSysClient.View.UserControls     5        � 	Resources  5	         MouseEnter_StoryBoard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime  ColorAccent �� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  MouseLeave_StoryBoard��%�  &	        7  &	 d    �� 5
   
   .��5      �� $ Icon_TextBlock��6+   $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�6R   .g�5        $ 00:00:00��6&     5      $ 00:00:00.3000000��6&   8   6A   5      U� 5      $ Gradient_Border��6,   $  (FrameworkElement.Opacity)�6T   .\�5        $ 00:00:00��6'   $ 0Q�6:     5      $ 00:00:00.3000000��6'   $ .3Q�6B   5      U� 5      $ Background_Border��6,   $ (FrameworkElement.Height)�6V   .\�5        $ 00:00:00��6'   $ 45Q�6:     5      $ 00:00:00.3000000��6'   $ 90Q�6B   5      5      �� 5   
   .��5      �� $ Icon_TextBlock��6+   $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�6R   .g�5        $ 00:00:00��6&     5      $ 00:00:00.3000000��6&   $ White��6A   5      U� 5      $ Gradient_Border��6,   $  (FrameworkElement.Opacity)�6T   .\�5        $ 00:00:00��6'   $ .3Q�6:     5       $ 00:00:00.3000000��6'   $ 0Q�6B   5!      U� 5"      $ Background_Border��6,   $ (FrameworkElement.Height)�6V   .\�5#        $ 00:00:00��6'   $ 90Q�6:     5$      $ 00:00:00.3000000��6'   $ 45Q�6B   5%      5&      5'      .��5)      � -   5        $��Principal_Grid��5)      .+�5*   
   �� -   5        $��Background_Border��5*        PrimaryColor#��[ 6*    �� CornerRadius$ 5��6U   $��0q�6f   $��2��6z    J� Effect 5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,      	   
BlurRadius$	 5Q�6#   
   Opacity$
 .3Q�62      	Direction$	 270Q�6?   5.      �� 50   
   -   5        $��Gradient_Border��50       J� Opacity$ 0Q�6(   $ 5��64   ��51      
� 52       
� GradientOrigin$
 1,.5&�6&    
� Center$
 1,.5&�6<    
� RadiusX$	 .25Q�6J    
� RadiusY$ .7Q�6X   .��53      �  � Color# [ 6#    � Offset$	 0.0Q�6H   � 54        ColorPrimary# [ 6#   $	 1.0Q�6I   55       57      -  'System.Windows.Media.Effects.BlurEffect  58         Radius$ 0Q�6   5:      � 5=   
   $��10q�6    � ColumnDefinitions 5?      �� 5@      $
��auto �6#   �� 5A      $��* �6#   �� 5B      $
��auto �6#   .+�5E      �� -   5        $��Icon_TextBlock��5E        
Solid_Icon#��[ 6~   $��Center=�5F      $��Center=�63   $��20(�6P     PrimaryTextColor#��[ 5G      ��5E   .   �� *Icon+ �� RelativeSource ��  �� AncestorType UserControl5G      �� 5I      $��Center=�6   $��1��64   $
��10 0q�6D   .+�5J      �� -   5        $��Title_TextBlock��5J        Normal_Text#��[ 6�   $
��Wrap=�6�   ��63   �� *Title+ ��  UserControl6�   �� 5K      -   5        $��Message_TextBlock��5K        SuperSmall_Text#��[ 6�   $
��Wrap=�6�    	 HolderTextColor#��[	 6�   $y�	Collapsed=�6�   $��0 5 0 0q�6
  ��65   �� *	Message+ ��  UserControl6
  5L      �� 5N      $��2��6    �� Orientation$ 
Horizontal=�6)   .+�5O      �� -   5        $��Arrow_Button��5O      $	����6-    
 Icon_Button#��[
 6@   5P      5Q      �� 5R   
   #��[
 6   ��66   �� *	Command+ ��  UserControl��6�   �� *CommandParameter+ ��  UserControl5S      5T      