   M S B A M L   `   `   `  ����=  9kp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:kpkp  5          kp.AddEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      "localclr-namespace:kp     5        N� Title$  AddEditPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Название тура��6   $��10,34,10,9.667q�6)   $��20(�6A    �� TextAlignment$ Center=�6O   �� 5   
   $��Цена тура��6   $��1��6%   $��10,33.333,10,14.333q�62   $��20(�6O   $ Center=�6]   �� 5   
   $��
Город��6   $��2��6!   $��10,34.667,10,14q�6.   $��20(�6G   $ Center=�6U   �� 5   
    �� 	MaxLength$	 256��6,   $��1��6<   $��35��6L   ��6   �� *
TourName+6L   �� 5   
   $��1��6-   $��35��6=   $��1��6I   $	��175��6V   $
��Left=�6b   ��6   �� *	TourPrice+6   �� 5   
   -   5         ��Name$ ComboCities��5   Z   $��2��61   $��35��6>   $��1��6J    �� DisplayMemberPath$ CityName��6o    �� SelectedIndex$ 1��6�    �� SelectedItem 6   �� *City+6�   �� 5   
   -   5        $��BtnSave��5   F   $��Сохранить��6   $��2��6%   $��3��69   6m   5      5      