   M S B A M L   `   `   `  ����B  >Wpf5320, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Wpf5320Wpf5320  5   �       Wpf5320.Window_Project11   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   'localclr-namespace:Wpf5320     6�   -   5          � Title$  Window_Project11��5   	   $	��388��6"   $	��640��6/    � AllowsTransparency .  � WindowStyle$
 None=�6U    � WindowStartupLocation$ CenterScreen=�6h    � Cursor$ Arrow��6�   
������ .��5      � .+�5   
   �� $
��Left=�6   $	��388��6+   $��Center=�68   $	��640��6S   $%��/Wpf5320;component/RES/xin2.png��6_   $
��Fill=�6�   �� 5   
   $
��Left=�6   $��31��6,   $	��Top=�68   $	��152��6P   $��	63,75,0,0q�6\   $��新建项目��6o   � 5	   
   $
��Left=�6   $	��182��6*   $��
64,106,0,0q�67   $	��Top=�6K   $	��320��6c   ���	#FFFDFAFA.+�5
      �� -   5         ��Name$ 
tbItemName��5
      $
��Left=�6*   $��23��6E   $��	78,11,0,0q�6Q    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��114��6�   6�   �� 5      -   5        $ tbItemAuthor��5      $
��Left=�6,   $��23��6G   $��	78,62,0,0q�6S   $
 Wrap=�6f   $	��Top=�6z   $	��114��6�   6�   �� 5      -   5        $ tbItmeAnnotation��5      $
��Left=�60   $��23��6K   $��
78,117,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��114��6�   6�   �� 5      $��	名称：��6   $
��Left=�6"   $��24��6=   $��	15,10,0,0q�6I   $	��Top=�6\   $��63��6t   �� 5      $��	作者：��6   $
��Left=�6"   $��24��6=   $��	15,61,0,0q�6I   $	��Top=�6\   $��63��6t   �� 5      $��	注释：��6   $
��Left=�6"   $��24��6=   $��
15,116,0,0q�6I   $	��Top=�6]   $��63��6u   5      �� 5   
   $
��Left=�6   $��31��6,   $��
215,75,0,0q�68   $	��Top=�6L   $	��169��6d   �� 5   
   -   5         ��Name$ 
lb_default��5      $��default��6$   $��31��66   $	��321��6B   $��
64,288,0,0q�6N   $
��Left=�6b   $	��Top=�6}   #��� ��6�   #��� ��6�   ���	#FFDDDDDD$��1q�6J  $��16(�6^  $��Center=�6l  �� 5   
   -   5        $ systime��5      $��Label��6!   $
��Left=�61   $��29��6L   $��333,290,0,0q�6X   $	��Top=�6m   $��48��6�   �� 5   
   $
��Left=�6   $��23��6+   $��
64,293,0,0q�67   $	��Top=�6K   $��23��6c   $&�� /Wpf5320;component/RES/cross.png��6n   $
��Fill=�6�   �� 5   
   $
��Left=�6   $��23��6+   $��
91,293,0,0q�67   $	��Top=�6K   $��23��6c   $%��/Wpf5320;component/RES/tick.png��6n   $
��Fill=�6�   �� 5   
   -   5         ��Name$ Cancel��5      $
��Left=�6!   $��23��6<   $��
64,292,0,0q�6H   $	��Top=�6\   $��23��6t   ���	#FF0A0909	 J� OpacityMask	 �	#FFCBBEBE���	#FFDED6D6
 J� Opacity$
 0Q�6�   $
 Hand��6�   �� 5   
   -   5        $ Ensure��5      $
��Left=�6!   $��23��6<   $��
92,292,0,0q�6H   $	��Top=�6\   $��23��6t   ���	#FF0A0909	 �	#FFCBBEBE���	#FFDED6D6$
 0Q�6�   $
 Hand��6�   �� 5   
   $
��Left=�6   $��29��6+   $��292,290,0,0q�67   $	��Top=�6L   $��41��6d   $-��'/Wpf5320;component/RES/softkeyboard.png��6o   $
��Fill=�6�   �� 5   
   -	   5        $ softkeyboard��5      $
��Left=�6'   $��29��6B   $��292,290,0,0q�6N   $	��Top=�6c   $��41��6{   ���	#FF0A0909	 �	#FFCBBEBE���	#FFDED6D6$
 0Q�6�   $
 Hand��6�   6�      Wpf5320.softKey  5O   
   -
   5          Name$ softKey��5O         Wpf5320.softKey   PreviewMouseLeftButtonUp$&  softKey_PreviewMouseLeftButtonUp��6�   $
��Left=�6)   $	��182��6D   $��275,107,0,0q�6Q   $	��Top=�6f   $	��108��6~   $y�	Collapsed=�6�   6�      Wpf5320.keyboard  5P   
   -   5          Name$ keyboard��5P         Wpf5320.keyboard   PreviewMouseLeftButtonUp$' !keyboard_PreviewMouseLeftButtonUp��6�   $
��Left=�6+   $��
417,50,0,0q�6F   $	��Top=�6Z   $	��303��6r   $	��170��6   $
 0Q�6�   5V      5W      