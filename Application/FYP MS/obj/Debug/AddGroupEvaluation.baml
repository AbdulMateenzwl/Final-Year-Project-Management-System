   M S B A M L   `   `   `  ����A  =FYP MS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FYP_MSFYP_MS  5   	       FYP_MS.AddGroupEvaluation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:FYP_MS     5   	     � WindowStartupLocation$  CenterScreen=�5   C    � WindowStyle$
 None=�6h    � 
ResizeMode$ NoResize=�6{    � ShowInTaskbar .   � AllowsTransparency .  � Title$ Stu Edit��5      $	��190��6   $	��500��6%   
������ $��10q�6K    J� Effect 5
      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      
BlurRadius$ 15Q�6      	Direction$	 -90Q�6+   	   RenderingBias$	 Quality=�6<   
   ShadowDepth$
 5Q�6U      Color$ Black��6f   .��5      ��    Light Theme Text Color#��[  6   .+�5   
   �� $��Evaluation Name��6    �� Left$ 25��6+   
 �� Top$ 27��6<   $��Center=�6L   $	��Top=�6i   �� 5   
   $��Evaluation Date��6   $	 226��6*   $ 31��6<   $
��Left=�6L   $��Center=�6g   �� 5   
   -   5         ��Name$ EvlName��5       �� 
IsReadOnly . $	 125��65   $ 31��6G   $��88��6W   $
��Left=�6b   $��Center=�6}    �� 	MaxLength$	 100��6�   �� 5   
   $��Obtained Marks��6   $	 225��6)   $ 73��6;   $
��Left=�6K   $��Center=�6f   �� 5   
   -   5        $ 
TotalMarks��5       . $	 105��68   $�� ��6y   $ 77��6�   $	��108��6�   $��Center=�6�   $	��Top=�6�   $ 11��6�   �� 5   
   $��Total Marks��6   $ 22��6&   $ 73��67   $��Center=�6G   $	��Top=�6d   �� 5   
   -   5        $ ObtainedMarks��5   $   $	 325��6    �� TextWrapping$
 Wrap=�6m   $ 77��6�   $	��135��6�   $��Center=�6�   $	��Top=�6�   $ 12��6�   �� 5   
   -   5         ��Name$ donebtn��5      $
��Save��6#   $	 258��62   $	 125��6D    J� RenderTransformOrigin$ 0.681,-1.002&�6U   $��35��6z   $��74��6�   $��Center=�6�   $	��Top=�6�     donebtn#��[ 6�   6�   �� 5   
   -   5        $��Cancel��5      $	 165��6"   $	 125��64   $ 0.681,-1.002&�6E   $��35��6j   $��74��6v   $��Center=�6�   $	��Top=�6�     	cancelbtn#��[ 6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��EvlDatepicker��5      $	 325��6*   $ 31��6<   $
��Left=�6L   $��Center=�6g   $	��135��6�   6�   5      5      