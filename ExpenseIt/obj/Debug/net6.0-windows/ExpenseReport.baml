   M S B A M L   `   `   `  ����D  @ExpenseIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ExpenseIt	ExpenseIt  5   	       ExpenseIt.ExpenseReport   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ExpenseIt     5   	     � Title$  ExpenseIt - View Expense��5   	   $	��450��6*   $	��800��67   .��5	      � $��
10,0,10,10q�6    � ColumnDefinitions 5
   
   �� 5      �� 5      ��5   
   �� 5       �� ImageSource$> 8D:\Coding\C#\exercises_revamped\ExpenseIt\watermark.jpeg��6    � RowDefinitions 5   
   �� 5      $	��175 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��200 �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6   $��0��6    $��Black"�6-   $
��32px(�6@   
����  �.��6f   Expense Report For:6{   � 5   
   $��1��6   $��1��6     5      �� 5      �� 5       5      �� 5       $
��Auto �6    .+�5"      �� $��0��6   $��0��6$   $��Black"�61   $
��20px(�6D   
���   �.��6h   Name:6o   �� 5#      $��1��6   $��0��6$   $��Black"�61   $
��20px(�6D   ��6T   ��  �� Path$
 Name�6t   5$      � 5&   
   $��1��6   $��2��6     5'      �� 5(      �� 5)       5,      �� 5-      $
��Auto �6    .+�5/      �� $��0��6   $��0��6$   $��Black"�61   $
��20px(�6D   
���   �.��6g   Department:6t   �� 50      $��1��6   $��0��6$   $��Black"�61   $
��20px(�6D   ��6T   �� $ 
Department�6z   51      &   System.Windows.Controls.DataGrid  52   
   $��1��6   $��3��6#      AutoGenerateColumns$ False��53         RowHeaderWidth$ 1Q�6)      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6<   ��52   0   �� $ Expenses�   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ExpenseType��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 56      �� $ ExpenseType�  57      $	 Amount��6%   
 65   �� $ ExpenseAmount�59      5=      5>      