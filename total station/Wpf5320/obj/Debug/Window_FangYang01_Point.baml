   M S B A M L   `   `   `  ����  Wpf5320%    Wpf5320.Window_FangYang01_Point   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Window_FangYang01_Point��5   	   $	��388��6)   $	��640��66    � AllowsTransparency .  � WindowStyle$
 None=�6\    � WindowStartupLocation$ CenterScreen=�6o   
������ .��5      � .+�5   
   �� $
��Left=�6   $	��388��6+   $��Center=�68   $	��640��6S   $%��/Wpf5320;component/RES/xin2.png��6_   $
��Fill=�6�   �� 5   
   $
��Left=�6   $��32��6,   $	��Top=�68   $	��326��6P   $��
61,287,0,0q�6\   ���	#FFF5EBEB6p   �� 5
   
   -   5         ��Name$ TabControl1��5
      $
��Left=�6*   $	��243��6E   $��	63,74,0,0q�6R   $	��Top=�6e   $	��323��6}    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -180.219Q�6&   T� 5      5      .@�5      �� $��放样��6   $��185,-3,-185,3q�6"   $ 0.5,0.5&�69   $��29��6Y   $��3��6e   z�5      V� 5      .~�5      �� �� 5      �� 5      $	 180Q�6*   T� 5      5      .��5      � 
�������$ 0.5,0.5&�6*   $��-5,-8,-5,-2q�6J   z�5      V� 5       .~�5!      �� �� 5"      �� 5#      $	 180Q�6.   T� 5$      5%      .+�5'      �� $��	点放样��6   $
��Left=�6+   $��31��6F   $��1,-1,0,0q�6R   $	��Top=�6d   $	��156��6|   �� 5(      $�� ��6   $
��Left=�6(   $��31��6C   $��
157,-1,0,0q�6O   $	��Top=�6c   $	��164��6{   �� 5)      -   5         ��Name$ Measure1��5)      $��测量��6/   $
��Left=�6<   $��24��6W   $��251,182,0,0q�6c   $	��Top=�6x   $��50��6�    � Cursor$
 Hand��6�   �� 5*      -   5        $
 Save��5*      $��存储��6+   $
��Left=�68   $��24��6S   $��189,182,0,0q�6_   $	��Top=�6t   $��50��6�   $
 Hand��6�   �� 5+      -   5        	 ��Name$	 	Com_Point��5+      $��24��62   $��207,37,96,0q�6>   $	��Top=�6S   {�. 
 �� 
IsReadOnly
 .   �� 
IsEditable .  �� Text 6�   �� *v1+.@�5,      �� -   5        $ 	diaoyong1��5,   !   $��调用��64   $��23��6A   $��38��6M   
�������
�������6   �� 5-      -   5        $ xinjian1��5-   !   $��新建��63   $��23��6@   $��39��6L   
�������
�������6~   5.      �� 5/      -   5        $ PreviousPoint��5/      $��上点��64   $
��Left=�6A   $��24��6\   $��
251,36,0,0q�6h   $	��Top=�6|   $��50��6�   $
 Hand��6�   �� 50      -	   5        $ 	NextPoint��50      $��下点��60   $
��Left=�6=   $��24��6X   $��
251,71,0,0q�6d   $	��Top=�6x   $��50��6�   $
 Hand��6�   �� 51      $��点名��6   $
��Left=�6)   $��24��6D   $��	90,35,0,0q�6P   $	��Top=�6c   $��35��6{   �� 52      $��镜高��6   $
��Left=�6)   $��24��6D   $��	90,71,0,0q�6P   $	��Top=�6c   $��35��6{   �� 53      $��左转��6   $
��Left=�6)   $��24��6D   $��	0,100,0,0q�6P   $	��Top=�6c   $��35��6{   �� 54      $��移远��6   $
��Left=�6)   $��24��6D   $��	1,128,0,0q�6P   $	��Top=�6c   $��35��6{   �� 55      $��向右��6   $
��Left=�6)   $��24��6D   $��	1,153,0,0q�6P   $	��Top=�6c   $��35��6{   �� 56      $��填方��6   $
��Left=�6)   $��24��6D   $��	1,181,0,0q�6P   $	��Top=�6c   $��35��6{   �� 57      $��HA��6   $
��Left=�6)   $��24��6D   $��157,100,0,0q�6P   $	��Top=�6e   $��35��6}   �� 58      $��HD��6   $
��Left=�6)   $��24��6D   $��157,129,0,0q�6P   $	��Top=�6e   $��35��6}   �� 59      $��Z��6   $
��Left=�6(   $��24��6C   $��157,153,0,0q�6O   $	��Top=�6d   $��35��6|   �� 5:      -
   5         ��Name$ DianMing��5:      $
��Left=�60   $��23��6K   $��
127,38,0,0q�6W    �� TextWrapping$
 Wrap=�6k   $	��Top=�6�   $��66��6�   ��6   �� *v1+6�   �� 5;      -   5        $ JingGao��5;      $
��Left=�6/   $��23��6J   $��
127,71,0,0q�6V   $
 Wrap=�6j   $	��Top=�6�   $��66��6�   ��6~   �� *v2+6�   �� 5<      -   5         ��Name$ Point_TurnLeft��5<      $��104.1627��64   $
��Left=�6G   $��24��6b   $��
40,100,0,0q�6n   $	��Top=�6�   $��62��6�   �� 5=      -   5        $ Point_MoveFar��5=      $��5301.909��63   $
��Left=�6F   $��24��6a   $��
40,132,0,0q�6m   $	��Top=�6�   $��62��6�   �� 5>      -   5        $ Point_Right��5>      $��      6.322��61   $
��Left=�6G   $��24��6b   $��
40,158,0,0q�6n   $	��Top=�6�   $��62��6�   �� 5?      -   5        $ Point_TianFang��5?      $��1698.403��64   $
��Left=�6G   $��24��6b   $��
40,181,0,0q�6n   $	��Top=�6�   $��62��6�   �� 5@      -   5        $ Point_HA��5@      $��255.4207��6.   $
��Left=�6A   $��24��6\   $��196,100,0,0q�6h   $	��Top=�6}   $��71��6�   �� 5A      -   5        $ Point_HD��5A      $��5308.433��6.   $
��Left=�6A   $��24��6\   $��198,128,0,0q�6h   $	��Top=�6}   $��69��6�   �� 5B      -   5        $ Point_Z��5B      $��1900.000��6-   $
��Left=�6@   $��24��6[   $��198,152,0,0q�6g   $	��Top=�6|   $��69��6�   $ 0.5,0.5&�6�   z�5C      V� 5D      .~�5E   "   �� �� 5F   "    �� AngleX$
 6.59Q�60   �� 5G   "   T� 5H   "    T� X$ 1.386Q�65   5I      5K      �� 5L      $��m��6   $
��Left=�6(   $��23��6C   $��
198,71,0,0q�6O   $	��Top=�6c   $��21��6{   �� 5M      $	��dms��6   $
��Left=�6*   $��24��6E   $��107,100,0,0q�6Q   $	��Top=�6f   $��36��6~   �� 5N      $��m��6   $
��Left=�6(   $��24��6C   $��107,132,0,0q�6O   $	��Top=�6d   $��36��6|   �� 5O      $��m��6   $
��Left=�6(   $��24��6C   $��107,158,0,0q�6O   $	��Top=�6d   $��36��6|   �� 5P      $��m��6   $
��Left=�6(   $��24��6C   $��107,181,0,0q�6O   $	��Top=�6d   $��36��6|   �� 5Q      $	��dms��6   $
��Left=�6*   $��24��6E   $��267,100,0,0q�6Q   $	��Top=�6f   $��34��6~   �� 5R      $��m��6   $
��Left=�6(   $��24��6C   $��267,128,0,0q�6O   $	��Top=�6d   $��34��6|   �� 5S      $��m��6   $
��Left=�6(   $��24��6C   $��267,152,0,0q�6O   $	��Top=�6d   $��34��6|   �� 5T      $
��Left=�6   $��56��67   $��	10,38,0,0q�6C   $	��Top=�6V   $��67��6n   $$��/Wpf5320;component/RES/001.jpg��6y   5W      5X      �� 5Z      $��数据��6   $��108,-3,-108,3q�6"   $ 0.5,0.5&�69   $��29��6Y   $��1��6e   z�5[      V� 5\      .~�5]      �� �� 5^      �� 5_      $ 179.938Q�6*   T� 5`      5a      .��5c      � 
�������$��-5,-5,-5,-2q�6*   $ 0.5,0.5&�6?   z�5d      V� 5e      .~�5f      �� �� 5g      �� 5h      $ -179.903Q�6.   T� 5i      5j      .+�5m      �� $��数据��6   $
��Left=�6*   $��31��6E   $��1,-2,0,0q�6Q   $	��Top=�6c   $	��156��6{   �� 5n      $�� ��6   $
��Left=�6(   $��31��6C   $��
157,-2,0,0q�6O   $	��Top=�6c   $	��164��6{   �� 5o      -   5        $ Point_N1��5o      $��24279847.000��6.   $
��Left=�6E   $��26��6`   $��	41,47,0,0q�6l   $	��Top=�6   $��96��6�   �� 5p      -   5        $ Point_E1��5p      $��	31848.621��6.   $
��Left=�6B   $��25��6]   $��	42,64,0,0q�6i   $	��Top=�6|   $��94��6�   �� 5q      -   5        $ Point_Z1��5q      $��378.251��6.   $
��Left=�6@   $��25��6[   $��	42,80,0,0q�6g   $	��Top=�6z   $��95��6�   �� 5r      -   5        $ 	Point_HA1��5r      $��255.4207��6/   $
��Left=�6B   $��24��6]   $��
45,121,0,0q�6i   $	��Top=�6}   $��71��6�   �� 5s      -   5        $ 	Point_VA1��5s      $��104.1627��6/   $
��Left=�6B   $��23��6]   $��
44,138,0,0q�6i   $	��Top=�6}   $��62��6�   �� 5t      -   5        $ 	Point_HD1��5t      $��5301.909��6/   $
��Left=�6B   $��24��6]   $��
44,157,0,0q�6i   $	��Top=�6}   $��62��6�   �� 5u      -   5        $ 	Point_VD1��5u      $��      6.322��6/   $
��Left=�6E   $��23��6`   $��
43,174,0,0q�6l   $	��Top=�6�   $��62��6�   �� 5v      -   5        $ 	Point_SD1��5v      $��1698.403��6/   $
��Left=�6B   $��23��6]   $��45,190,0,-4q�6i   $	��Top=�6~   $��62��6�   �� 5w      $	��dms��6   $
��Left=�6*   $��25��6E   $��124,138,0,0q�6Q   $	��Top=�6f   $��36��6~   �� 5x      $��m��6   $
��Left=�6(   $��26��6C   $��132,157,0,0q�6O   $	��Top=�6d   $��28��6|   �� 5y      $��m��6   $
��Left=�6(   $��133,173,0,11q�6C   $��28��6Y   �� 5z      $��m��6   $
��Left=�6(   $��25��6C   $��133,188,0,-4q�6O   $	��Top=�6e   $��28��6}   �� 5{      $��N��6   $
��Left=�6(   $��30��6C   $��7,44,0,0q�6O   $	��Top=�6a   $��29��6y   �� 5|      $��E��6   $
��Left=�6(   $��25��6C   $��7,63,0,0q�6O   $	��Top=�6a   $��28��6y   �� 5}      $��Z��6   $
��Left=�6(   $��25��6C   $��7,79,0,0q�6O   $	��Top=�6a   $��29��6y   �� 5~      $��m��6   $
��Left=�6(   $��26��6C   $��
135,45,0,0q�6O   $	��Top=�6c   $��28��6{   �� 5      $��m��6   $
��Left=�6(   $��26��6C   $��
135,62,0,0q�6O   $	��Top=�6c   $��27��6{   �� 5�      $��m��6   $
��Left=�6(   $��26��6C   $��
135,79,0,0q�6O   $	��Top=�6c   $��27��6{   �� 5�      $��VA��6   $
��Left=�6)   $��23��6D   $��	0,135,0,0q�6P   $	��Top=�6c   $��35��6{   �� 5�      $��HD��6   $
��Left=�6)   $��24��6D   $��	1,152,0,0q�6P   $	��Top=�6c   $��35��6{   �� 5�      $��VD��6   $
��Left=�6)   $��23��6D   $��	1,170,0,0q�6P   $	��Top=�6c   $��35��6{   �� 5�      $��SD��6   $
��Left=�6)   $��23��6D   $��	1,186,0,0q�6P   $	��Top=�6c   $��35��6{   �� 5�      $��HA��6   $
��Left=�6)   $��24��6D   $��	0,116,0,0q�6P   $	��Top=�6c   $��35��6{   �� 5�      $	��dms��6   $
��Left=�6*   $��26��6E   $��125,121,0,0q�6Q   $	��Top=�6f   $��37��6~   �� 5�      $��点名��6   $
��Left=�6)   $��26��6D   $��0,27,0,0q�6P   $	��Top=�6b   $��32��6z   �� 5�      $��编码��6   $
��Left=�6)   $��26��6D   $��	-1,98,0,0q�6P   $	��Top=�6c   $��33��6{   5�      5�      �� 5�      $��图形��6   $��31,-3,-31,3q�6"   $ 0.5,0.5&�67   $
��Left=�6W   $��38��6r   $��Bottom=�6}   $��29��6�   $��2��6�    J� IsHitTestVisible . z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $	 180Q�6*   T� 5�      5�      .��5�      � 
�������$ 0.5,0.5&�6*   $��-6,-7,-5,-3q�6J   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 179.904Q�6.   T� 5�      5�      .+�5�      �� $��图形��6   $
��Left=�6*   $��30��6E   $	��Top=�6Q   $	��158��6i   $��2,0,0,0q�6u   �� 5�      $�� ��6   $
��Left=�6(   $��30��6C   $��	160,0,0,0q�6O   $	��Top=�6b   $	��161��6z   �� 5�      -   5         ��Name$ 
CanvasDraw��5�      $
��Left=�61   $	��182��6L   $	��Top=�6Y   $	��321��6q   $��0,30,0,0q�6}   5�      5�      5�      �� 5�   
   -   5        $ systime��5�      $��Label��6!   $
��Left=�61   $��29��6L   $��332,288,0,71q�6X   $��Center=�6n   $��49��6�   �� 5�   
   -   5        $ Bt_Power��5�      $��Button��6#   $
��Left=�64   $��25��6O   $��
552,60,0,0q�6[   $	��Top=�6o   $��25��6�   ���	#FFDDDDDD J� Opacity$ 0Q�6�   $ -1.138,1.172&�6�   $
 Hand��6�   6�   �� 5�   
   -   5        $	 ESC��5�      $��Button��6   $
��Left=�6/   $��20��6J   $��553,290,0,0q�6V   $	��Top=�6k   $��24��6�   ���	#FFDDDDDD$ 0Q�6�   $ -1.138,1.172&�6�   $
 Hand��6�   5�      5�      