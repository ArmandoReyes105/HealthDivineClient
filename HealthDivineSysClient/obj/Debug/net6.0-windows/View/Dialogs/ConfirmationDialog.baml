   M S B A M L   `   `   `  ����P  LHealthDivineSysClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:HealthDivineSysClient.View.Dialogs"HealthDivineSysClient.View.Dialogs  5   	   ;    5HealthDivineSysClient.View.Dialogs.ConfirmationDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:HealthDivineSysClient.View.Dialogs     5   	     � Title$  ConfirmationDialog��5   	   $	��450��6$   $	��500��61   
������  � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��5   	    � 	Resources 5         Start_StoryBoard �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  Close_StoryBoard��%�  &	        &	 �     �� 5   
   .��5      U� $ Principal_Grid��6,   $ (FrameworkElement.Width)�6S   .\�5        $ 00:00:00��6'   $ 0Q�6:     5      $ 00:00:00.3000000��6'   $	 450Q�6B   5      5      �� 5   
   .��5      U� $ Principal_Grid��6,   $  (FrameworkElement.Opacity)�6S   .\�5        $ 00:00:00��6'   $ 1Q�6:     5      $ 00:00:00.2000000��6'   $ 0Q�6B   5      5      5      .��5      � .+�5   
   � -   5        $��Principal_Grid��5   ?   $��20q�6   $	��450��6   $	��Top=�6'   .+�5      ��   PrimaryColor#��[ 6    �� CornerRadius$ 5��6@   	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   ShadowDepth$
 5Q�6'      Color$ Black��5          Opacity$
 0.75Q�5!         
BlurRadius$ 5Q�5"      5$      �� 5%      $��20q�6   .+�5&      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5'      �� $	����6      Regular_Icon#��[ 60     AccentColor#��[ 6V   �� 5(      -   5        $��Title_TextBlock��5(       $��Title of the alert��67     Subtitle_Text#��[ 6Q   $
��15 0q�6x   $��Center=�6�   5)      �� 5*      -   5        $��Message_TextBlock��5*      $M��GHere is the message of the alert, is a description of what is happening��65   $��	0 10 0 25q�6�   $
��Wrap=�6�     Normal_Text#��[ 6�     HolderTextColor#��[ 6�   �� 5+      $ 
Horizontal=�6   $��Center=�66   .+�5,      �� -   5        $��	No_Button��5,        Border_Button#��[ 6.   $	��150��6U   $��Cancelar��6a   $��0 0 15 0q�6t   6�   �� 5-      -   5        $��
Yes_Button��5-       	 Normal_Button#��[	 6/   $	��150��6V    
 Comfortaa-Bold#��[
 6b   $��14(�6�   $��Aceptar��6�   $��Right=�6�   6�   5.      5/      50      52      53      