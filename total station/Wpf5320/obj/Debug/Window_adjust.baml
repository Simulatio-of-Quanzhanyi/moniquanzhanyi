   M S B A M L   `   `   `  ����  Wpf5320    Wpf5320.Window_adjust   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Window_adjust��5      $	��388��6   $	��640��6*    � AllowsTransparency .  � WindowStyle$
 None=�6P    � WindowStartupLocation$ CenterScreen=�6c   
������ .��5      � .+�5   
   �� 
���   � �� CornerRadius$ 25��6%   $��1q�67   $
��Left=�6K   $	��388��6f   $	��Top=�6s   $	��640��6�   �� 5   
   $
��Left=�6   $	��388��6+   $��Center=�68   $	��640��6S   $%��/Wpf5320;component/RES/xin2.png��6_   $
��Fill=�6�   � 5
   
   $
��Left=�6   $	��242��6*   $��	64,75,0,0q�67   $	��Top=�6J   $	��319��6b   #��� ��6n   }�. .+�5      �� $�� ��6   $
��Left=�6    $��31��6;   $��	150,0,0,0q�6G   $	��Top=�6Z   $	��169��6r   �� 5      $��校准��6   $
��Left=�6"   $��31��6=   $	��Top=�6I   $	��150��6a   �� 5      $�� ��6   $
��Left=�6    $��31��6;   $	��Top=�6G   $	��319��6_   $��	0,211,0,0q�6k   �� 5      -   5         ��Name$ Button_project��5      $��项目��6-   $
��Left=�6:   $��36��6U   $	��Top=�6a   $��75��6y   $��0,31,0,0q�6�   $
��Bold"�6�    � Cursor$
 Hand��6�   6�   �� 5      -   5        $ Button_data��5      $��数据��6*   $
��Left=�67   $��36��6R   $	��Top=�6^   $��75��6v   $��0,67,0,0q�6�   $
��Bold"�6�   $
 Hand��6�   6�   �� 5      -   5        $ Button_calculate��5      $��计算��6/   $
��Left=�6<   $��36��6W   $	��Top=�6c   $��75��6{   $��	0,103,0,0q�6�   $
��Bold"�6�   $
 Hand��6�   6�   �� 5      -   5        $ Button_setting��5      $��设置��6-   $
��Left=�6:   $��36��6U   $	��Top=�6a   $��75��6y   $��	0,139,0,0q�6�   $
��Bold"�6�   $
 Hand��6�   6�   �� 5      -   5        $ Button_adjust��5      $��校准��6,   $
��Left=�69   $��36��6T   $	��Top=�6`   $��75��6x   $��	0,175,0,0q�6�   $
��Bold"�6�   $
 Hand��6�   6�   �� 5      -   5        $ Button_convention��5      $��常规��60   $
��Left=�6=   $��36��6X   $	��Top=�6d   $��75��6|   $��	75,31,0,0q�6�   $
��Bold"�6�   $
 Hand��6�   6�   �� 5      -   5        $ Button_Build��5      $��建站��6+   $
��Left=�68   $��36��6S   $	��Top=�6_   $��75��6w   $��	75,67,0,0q�6�   $
��Bold"�6�   $
 Hand��6�   6�   �� 5      -	   5        $ Button_Collect��5      $��采集��6-   $
��Left=�6:   $��36��6U   $	��Top=�6a   $��75��6y   $��
75,103,0,0q�6�   $
��Bold"�6�   $
 Hand��6�   6�   �� 5      -
   5        $ Button_FangYang��5      $��放样��6.   $
��Left=�6;   $��36��6V   $	��Top=�6b   $��75��6z   $��
75,139,0,0q�6�   $
��Bold"�6�   $
 Hand��6�   6�   �� 5      -   5        $ Button_Road��5      $��道路��6*   $
��Left=�67   $��36��6R   $	��Top=�6^   $��75��6v   $��
75,175,0,0q�6�   $
��Bold"�6�   $
 Hand��6�   6�   �� 5      $
��Left=�6   $	��180��64   $	��Top=�6A   $	��169��6Y    �� TabStripPlacement$ Right=�6e   $��
150,31,0,0q�6   
�������.@�5      �� $��A��6   $��90��6%   $��	0,-2,-3,2q�61   .��5      � $��-3,-3,-3,-5q�6    � ColumnDefinitions 5      �� 5      $	��63* �6/   �� 5      $	��31* �6/   .+�5!      �� -   5        $ 	BuChangQi��5!   !   $(��" 1    补偿器校正             ��64   $
��Left=�6W   $	��Top=�6r   $	��141��6�   $��36��6�   
�������$��2��6�   $��0q�6�   $��0q�6�   
�������$
 Hand��6  �� 5"      -   5        $ ChuiZhiJiao��5"   !   $'��! 2    垂直角基准校正      ��66   $
��Left=�6T   $	��Top=�6o   $	��141��6�   $��36��6�   
�������$��2��6�   $��0,36,0,0q�6�   $��0q�6�   
�������$
 Hand��6  �� 5#      -   5        $ YiQiChangShu��5#   !   $'��! 3    仪器加常数校正      ��67   $
��Left=�6U   $	��Top=�6p   $	��141��6�   $��36��6�   
�������$��2��6�   $��0,72,0,0q�6�   $��0q�6�   
�������$
 Hand��6  �� 5$      -   5        $ 	ChuMoPIng��5$   !   $(��" 4    触摸屏校验             ��64   $
��Left=�6W   $	��Top=�6r   $	��141��6�   $��36��6�   
�������$��2��6�   $��	0,108,0,0q�6�   $��0q�6�   
�������$
 Hand��6  �� 5%      -   5        $ TuoLuoYi��5%   !   $(��" 5    陀螺仪校正             ��63   $
��Left=�6V   $	��Top=�6q   $	��141��6�   $��36��6�   
�������$��2��6�   $��	0,144,0,0q�6�   $��0q�6�   
�������$
 Hand��6  5(      5)      �� 5*      $��B��6   $��90��6%   $��	0,-2,-3,2q�61   .��5,      � $��-4,-5,-5,-4q�6   .+�5-      �� -   5        $ YingXiangCenter��5-   !   $'��!1    影像中心校正          ��6:   $
��Left=�6Z   $	��Top=�6u   $	��143��6�   $��36��6�   
�������$��0,1,0,0q�6�   $��0q�6�   
�������$
 Hand��6  5.      5/      50      53      �� 54   
   -   5        	 ��Name$	 systime��54      $��Label��6!   $
��Left=�61   $��27��6L   $��331,290,0,71q�6X   $��Center=�6n   $��49��6�   �� 56   
   -   5        $ Bt_Power��56      $��Button��6#   $
��Left=�64   $��25��6O   $��25��6\   $��
553,60,0,0q�6h   $	��Top=�6|   ���	#FFDDDDDD
 J� Opacity$
 0Q�6�    J� RenderTransformOrigin$ -1.138,1.172&�6�   $
 Hand��6�   6�   �� 57   
   -   5        $	 ESC��57      $��Button��6   $
��Left=�6/   $��24��6J   $��552,293,0,0q�6V   $	��Top=�6k   $��27��6�   ���	#FFDDDDDD$
 0Q�6�   $ -1.138,1.172&�6�   $
 Hand��6�   �� 58   
   $
��Left=�6   $��17��6+   $��
350,83,0,0q�67   $	��Top=�6K   $��30��6c   $(��"/Wpf5320;component\RES\battery.jpg��6n   $
��Fill=�6�   �� 59   
   $
��Left=�6   $��23��6+   $��
318,80,0,0q�67   $	��Top=�6K   $��23��6c   $%��/Wpf5320;component\RES\star.png��6n   $
��Fill=�6�   �� 5:   
   -   5        $ 
Shortcuts1��5:      $
��Left=�6%   $��23��6@   $��
318,80,0,0q�6L   $	��Top=�6`   $��23��6x   ���	#FF0A0909 J� OpacityMask �	#FFCBBEBE���	#FFDED6D6$
 0Q�6�   $
 Hand��6�   �� 5;   
   -   5        $ Battery1��5;      $
��Left=�6#   $��17��6>   $��
350,82,0,0q�6J   $	��Top=�6^   $��33��6v   ���	#FF0A0909 �	#FFCBBEBE���	#FFDED6D6$
 0Q�6�   $
 Hand��6�   �� 5<   
   -   5        $ 	Shortcuts��5<      $
��Left=�6$   $��23��6?   $��
513,60,0,0q�6K   $	��Top=�6_   $��23��6w   ���	#FF0A0909 �	#FFCBBEBE���	#FFDED6D6$
 0Q�6�   $
 Hand��6�   5>      5@      