   M S B A M L   `   `   `  ����=  9kp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:kpkp  5          kp.TourList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      "localclr-namespace:kp     5        N� Title$  TourList��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �  � Orientation$ 
Horizontal=�6   $��Center=�6-   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $/��)Введите название тура:��6   $	��175��6:    �� TextAlignment$ Right=�6F   $��18��6\   6j   �� 5      -   5         ��Name$ 
TBoxSearch��5   2   $��16��6   $	��225��6&   6F   5      5      �� 5   
   -   5        $��
LViewTours��5       $��1��6   $��Disabled=�62   $��Center=�6h   ��5      �� 5      .R�5      � $ 
Horizontal=�6    $��Center=�69   6X   5      ��5      �� 5      .R�5       � $��20q�6   $	��400��6'    5!      �� 5"      $��70 �6,   6:   �� 5#      $	��310 �6,   6;   �� 5$      $
��auto �6,   6<   �� 5%      $
��auto �6,   6<   .+�5'      �� $	��400��6    $��1��6,   $��UniformToFill=�69   $��Center=�6Q   $��5q�6n   ��5(      �� 5)   "    �� Path$ ImagePreview�6*    �� TargetNullValue 5*   &   ��5+   *   Resources/noimg.jpg��6K   5-   #   5/      �� 50      $��Center=�6>   $ Center=�6Y   $	��390��6p   $
��Wrap=�51       $��Center=�64   $	��5 5q�6Q   $��26(�6^   $��0 ��6l   ��50   $   �� *
TourName+51   |   �� 52      $��2��6X   $��	 5 5 5 15q�6e   $��Center=�6x   $��26(�6�   $
��Bold"�6�   ��6$   �� *	TourPrice+ �� StringFormat$ {0:N2} $��6�   �� 53      $��3��6>   $��14(�6K   $
��Left=�6Y   ��6$   �� *
TourDate+6v   �� 54      $��3��6%   $ 
Horizontal=�62   $��22q�6K   .+�55      �� $��14(�6p   $
��Left=�6~   ��6(   �� *TravelPackageQty+$* $Билетов осталось: {0}��6�   �� 56      $��TBoxTicketsCount��61   -   5        $��45��56   &   $��10 0 0 0q�6t   6�   �� 57      -   5        $��Купить��57   %   $��5 0 0 0q�6N   $	��160��6_   6m   58      59      5:      5<      5=      5>      