   M S B A M L   `   `   `  ����  Wpf53201    +Wpf5320.Window_FangYang03_DirectionLine3_DY   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$)  #Window_FangYang03_DirectionLine3_DY��5   	   $	��388��65   $	��640��6B    � AllowsTransparency .  � WindowStyle$
 None=�6h    � WindowStartupLocation$ CenterScreen=�6{   
������ .��5      � .+�5   
   �� $
��Left=�6   $	��388��6+   $��Center=�68   $	��640��6S   $%��/Wpf5320;component/RES/xin2.png��6_   $
��Fill=�6�   �� 5   
   -   5         ��Name$ Bt_Power��5      $��Button��6#   $
��Left=�64   $��15��6O   $��
557,65,0,0q�6[   $	��Top=�6o   $��15��6�   ���	#FFDDDDDD J� Opacity$ 0Q�6�    J� RenderTransformOrigin$ -1.138,1.172&�6�    � Cursor$
 Hand��6�   6�   �� 5   
   -   5        $ Bt_enter��5      $��Button��6#   $
��Left=�64   $��15��6O   $��558,335,0,0q�6[   $	��Top=�6p   $��15��6�   ���	#FFDDDDDD$ 0Q�6�   $ -1.138,1.172&�6�   $
 Hand��6�   6�   � 5	   
   $
��Left=�6   $	��242��6*   $��	64,75,0,0q�67   $	��Top=�6J   $	��319��6b   #��� ��6n   }�. .+�5
      �� $�� ��6   $
��Left=�6    $��31��6;   $��	112,0,0,0q�6G   $	��Top=�6Z   $	��207��6r   �� 5      $��坐标数据��6   $
��Left=�6$   $��31��6?   $	��Top=�6K   $	��112��6c   �� 5      $�� ��6   $
��Left=�6    $��31��6;   $	��Top=�6G   $	��319��6_   $��	0,211,0,0q�6k   �� 5      -   5        $ first��5      $��第一��6$   $
��Left=�61   $��121,181,0,0q�6L   $	��Top=�6a   $��66��6y   $��30��6�   $
 Hand��6�   6�   �� 5      -   5        $
 last��5      $��最后��6$   $
��Left=�61   $��187,181,0,0q�6L   $	��Top=�6a   $��66��6y   $��30��6�   $
 Hand��6�   6�   �� 5      $
��Left=�6   $��30��61    �� TextWrapping$
 Wrap=�6=   $�� ��6Q   $	��Top=�6Y   $	��121��6q   $��	0,181,0,0q�6}   �� 5      -   5        	 ��Name$	 LV��5      $
��Left=�6#   $	��150��6>   $	��Top=�6K   $	��319��6c   $��0,31,0,0q�6o   $��Visible=�6�   $��Visible=�6�   
 � BindingGroup
 5      &   System.Windows.Data.BindingGroup  5       �� View 5      �� 5      -   5        gridview121212��.P�5      �� $��名称              ��6)    �� Width$ 86��6C    �� DisplayMemberBinding 6N   ��  �� Path$ 测站��� 5      $��编码                ��6)   $ 86��6E    6P   �� $ 编码��� 5      $��类型               ��6)   $ 86��6D    6O   �� $ 类型��� 5      $��N                ��6)   $ 86��6D    6O   �� $ N��� 5      $��E                ��6)   $ 86��6D    6O   �� $ E��� 5      $��Z                ��6)   $ 86��6D    6O   �� $ Z�5      5      5      �� 5    
   -   5         ��Name$ systime��5       $��Label��6!   $
��Left=�61   $��27��6L   $��334,288,0,73q�6X   $��Center=�6n   $��49��6�   �� 5!   
   -	   5        $	 ESC��5!      $��Button��6   $
��Left=�6/   $��15��6J   $��558,296,0,0q�6V   $	��Top=�6k   $��15��6�   ���	#FFDDDDDD$ 0Q�6�   $ -1.138,1.172&�6�   $
 Hand��6�   �� 5#   
   $
��Left=�6   $��23��6+   $��	65,0,0,73q�67   $��Bottom=�6J   $��23��6e   $&�� /Wpf5320;component/RES/cross.png��6p   $
��Fill=�6�   �� 5$   
   -
   5        $ Cancel��5$      $
��Left=�6!   $��23��6<   $��
65,292,0,0q�6H   $	��Top=�6\   $��23��6t   ���	#FF0A0909 J� OpacityMask �	#FFCBBEBE���	#FFDED6D6$ 0Q�6�   $
 Hand��6�   �� 5%   
   $
��Left=�6   $��23��6+   $��
91,292,0,0q�67   $	��Top=�6K   $��23��6c   $%��/Wpf5320;component/RES/tick.png��6n   $
��Fill=�6�   �� 5&   
   -   5        $ Ensure��5&      $
��Left=�6!   $��23��6<   $��
91,292,0,0q�6H   $	��Top=�6\   $��23��6t   ���	#FF0A0909 �	#FFCBBEBE���	#FFDED6D6$ 0Q�6�   $
 Hand��6�   5'      5(      