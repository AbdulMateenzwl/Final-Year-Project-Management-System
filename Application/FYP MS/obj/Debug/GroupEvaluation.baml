   M S B A M L   `   `   `  ����A  =FYP MS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FYP_MSFYP_MS  5          FYP_MS.GroupEvaluation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:FYP_MS     5      .��5	      ]� 
�������.+�5
   
   � $	��Top=�6     � ColumnDefinitions  5      �� 5      $
��289* �6#   62   �� 5      $
��278* �6#   62   �� 5      $
��112* �6#   62   �� 5      $
��121* �6#   62   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��
10 10 0 10q�6   $��Search��6,   6?   �� 5      -   5        $��	SearchBar��5      $	��120��6+   $��20��6[   $��5q�6g   6t   �� 5      -   5         ��Name$ ClearBtn��5   9   $��
Clear Text��6   $��5q�6.   $��70��6b      Btntype1#��[  6m   6�   5      �� 5      $ 
Horizontal=�6   $��1��62   .+�5      �� $��
10 10 0 10q�6   $��Select Evaluation��6,   6J   �� 5      -   5         ��Name$ EvaluationNamecmbox��5      $	��150��6p   $��	5 10 5 10q�6|   6�   5      �� 5      -   5        $ EvalateGroupBtn��5   R   $��2��6   $��Evaluate Group��6%   $��	5,10,5,11q�6>   #��[  6�   �� 5      -   5        $ UpdateEvlBtn��5   ?   $��3��6   $��Edit Evaluation��6%   #��[  6p   $��
5,10,10,11q�6�   5      � 5   
    � RowDefinitions 5      �� 5       $��1* �6    6.   �� 5!      $��5* �6    6.   �� 5"      $��1* �6    6.   �� 5#      $��5* �6    6.     5%      �� 5&      6%   �� 5'      6%   .+�5*      �� .��6   UnEvaluated Groups6(   &   System.Windows.Controls.DataGrid  5+      -   5          Name$ UnEvlGroupGrid��5-   U      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5+      $��1��6'   
�������   RowBackground
 �����$	��Top=�6g     Light Theme Text Color   AlternatingRowBackground# [ 5,      $��Stretch=�5-      $��Stretch=�69   $��5q�6m   	   CanUserAddRows	 .  
   CanUserDeleteRows
 .     CanUserResizeRows .     
IsReadOnly . $	��300��5.   x   5/      �� 51      $��0��6   $��1��6!   .��61   Group Members6@     52      -   5        $ GroupMembersGrid��54   U   $ * 52      $��1��6'   $��1��64   
�������
 �����$	��Top=�6w   # [ 53      $��Stretch=�54      $��Stretch=�69   $��5q�6o   	 .  
 .   .   . $	��300��55   x   56      �� 58      $��2��6   .��6!   Evaluated Group62     59      -   5        $ EvlGroupGrid��5;   U   $��3��59      $ * 6$   
�������
 �����# [ 5:      $��Stretch=�5;      $��Stretch=�69   $��5q�6k   	 .  
 .   .   . 5=      �� 5?      $��2��6   $��1��6!   .��61   Evaluation Details6E     5@      -	   5        $ EvaluationsDetailsGrid��5B   U   $��3��5@      $ * 6$   $��1��64   
�������
 �����# [ 5A      $��Stretch=�5B      $��Stretch=�69   $��5q�6u   	 .  
 .   .   . 5D      5E      5F      5G      