   M S B A M L   `   `   `  ����M  IPOP-SF-40-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_40_2016_GUI.UIPOP_SF_40_2016_GUI.UI  5   	   /    )POP_SF_40_2016_GUI.UI.DodatneUslugeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_40_2016_GUI.UI     5   	     � Title$  DodatneUslugeWindow��5   	   $��317.054��6%   $��698.644��66    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\   ���	#FFA9D0CE.��5	      � .+�5
   
   �� -   5         ��Name$ btnDodaj��5
      $��Dodaj��6#   $
��Left=�63   $��28��6N   $��	21,21,0,0q�6Z   $	��Top=�6m   $��90��6�   
����������	#FF38E70C���	#FF8CF3076�   �� 5   
   -   5        $ 	btnIzmeni��5      $��Izmeni��6$   $
��Left=�65   $��28��6P   $��	21,54,0,0q�6\   $	��Top=�6o   $��90��6�   ���	#FF8EF607���	#FF94F306���	#FFFDFDFD6�   �� 5   
   -   5        $ 
btnIzbrisi��5      $��Izbrisi��6%   $
��Left=�67   $��28��6R   $��	21,87,0,0q�6^   $	��Top=�6q   $��90��6�   
����������	#FFEE0707���	#FFF603036�   �� 5   
   -   5        $ 
btnZatvori��5      $��Zatvori��6%   $
��Left=�67   $��28��6R   $��
21,240,0,0q�6^   $	��Top=�6r   $��90��6�   ���	#FFF40606���	#FFF70A0A
�������6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgUsluga��5   �   $
��Left=�6      CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .  $	��247��6�   $��
139,21,0,0q�6�   $	��Top=�6�   $	��369��6�      
IsReadOnly .  �� SelectedItem 6�   �� 	 �� Path$	 IzabranaUsluga�67  �� 5   
   -   5        $ 
btnPreuzmi��5      $��Preuzmi��6%   $
��Left=�67   $��28��6R   $��
21,120,0,0q�6^   $	��Top=�6r   $��90��6�   ���	#FF15ED07���	#FF0AF10D���	#FFFDFDFD6�   �� 5   
   -   5        $��labSort��5   �   $��	Sortirati��6   $��14(�6$   $
��Left=�62   $��29��6M   $��571,165,0,0q�6Y   $	��Top=�6n   $��61��6�   6�   �� 5   
   -   5        
 ��Name$
 cbSortDodUsluge��5      $
��Left=�6,   $��29��6G   $��541,199,0,0q�6S   $	��Top=�6h   $	��126��6�   6�   �� 5   
   -	   5        $ btnPretragaUsluga��5      $��13(�6,   $��Pretraga��6:   $
��Left=�6M   $��26��6h   $��
559,69,0,0q�6t   $	��Top=�6�   $��85��6�   
����������	#FF07F313���	#FF3EFF016�   �� 5   
   -
   5         ��Name$ tbPretragaUsluga��5      $
��Left=�6,   $��30��6G   $��
532,34,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��135��6�   �� 5   
   -   5        $ btnOSveziUsluge��5      $��Osvezi��6*   $
��Left=�6;   $��24��6V   $��559,103,0,0q�6b   $	��Top=�6w   $��85��6�   
����������	#FF45CB08���	#FF0EEB006�   5      5      