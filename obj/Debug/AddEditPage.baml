   M S B A M L   `   `   `  ����=  9kp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:kpkp  5          kp.AddEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      "localclr-namespace:kp     5        N� Title$  AddEditPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Название тура��6   $��10,10,10,10.667q�6)   $��20(�6B    �� TextAlignment$ Center=�6P   �� 5   
   $��Цена тура��6   $��1��6%   $��	10,10.333q�62   $��20(�6E   $ Center=�6S   �� 5   
   $��
Город��6   $��2��6!   $��10,10.667,10,11q�6.   $��20(�6G   $ Center=�6U   �� 5   
   $)��#Количество билетов��6   $��3��6.   $��10q�6;   $��19(�6G   $ Center=�6U   �� 5   
   $��Номер тура��6   $��4��6&   $��10q�63   $��19(�6?   $ Center=�6M   �� 5   
   $#��Количество дней��6   $��5��6+   $��10q�68   $��19(�6D   $ Center=�6R   �� 5    
   $��Дата тура��6   $��6��6%   $��10q�62   $��19(�6>   $ Center=�6L   �� 5!   
    �� 	MaxLength$	 256��6,   $��1��6<   $��35��6L   ��6   �� *
TourName+6L   �� 5"   
   $��1��6-   $��35��6=   $��1��6I   $	��175��6V   $
��Left=�6b   $��10,11.333,0,10.333q�6}   ��6   �� *	TourPrice+6�   �� 5#   
   $��1��64   $��35��6D   $��
10,11,0,10q�6P   $��3��6d   $
��Left=�6q   $	��175��6�   ��6   �� *TravelPackageQty+6�   �� 5$   
   -   5         ��Name$ ComboCities��5$   Z   $��2��61   $��35��6>   $��1��6J    �� DisplayMemberPath$ CityName��6o    �� SelectedIndex$ 1��6�    �� SelectedItem 6   �� *City+6�   �� 5&   
   -   5        $��BtnSave��5&   2   $��Сохранить��6   $��7��6%   $��1��6W   $��212,10,213,16q�6g   �� 5'   
   $��1��6*   $
��Left=�6:   $��36��6U   $��	10,10,0,0q�6a   $��4��6t   	 �� TextWrapping$
	 Wrap=�6�   $	��Top=�6�   $	��208��6�   ��6   �� *TourID+6�   �� 5(   
   $��1��6*   $
��Left=�6:   $��
10,10,0,10q�6U   $��5��6i   $
	 Wrap=�6v   $	��208��6�   ��6   �� *DayQty+6�   �� 5)   
   $��1��6,   $
��Left=�6<   $��36��6W   $��	10,10,0,0q�6c   $��6��6v   $
	 Wrap=�6�   $	��Top=�6�   $	��208��6�   ��6   �� *
TourDate+6�   5*      5+      