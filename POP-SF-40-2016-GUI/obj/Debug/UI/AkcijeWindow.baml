   M S B A M L   `   `   `  ����M  IPOP-SF-40-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_40_2016_GUI.UIPOP_SF_40_2016_GUI.UI  5   	   (    "POP_SF_40_2016_GUI.UI.AkcijeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_40_2016_GUI.UI     5   	     � Title$  AkcijeWindow��5   	   $��457.242��6   $��707.864��6/    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterScreen=�6U   ���	#FFA9D0CE.��5	      � $��0,0,2,-4q�6   .+�5
   
   �� -   5         ��Name$ btnDodaj��5
      $��Dodaj��6#   $
��Left=�63   $��31��6N   $��
20,382,0,0q�6Z   $	��Top=�6n   $��83��6�   
����������	#FF20FA09���	#FF48F1076�   �� 5   
   -   5        $ 	btnIzmeni��5      $��Izmeni��6$   $
��Left=�65   $��31��6P   $��108,382,0,0q�6\   $	��Top=�6q   $��83��6�   ���	#FF4AEE0C���	#FF21F60B
�������6�   �� 5   
   -   5        $ 
btnIzbrisi��5      $��Izbrisi��6%   $
��Left=�67   $��31��6R   $��196,382,0,0q�6^   $	��Top=�6s   $��83��6�   ���	#FFE7E7E7���	#FFF60606���	#FFF408086�   �� 5   
   -   5        $ 
btnZatvori��5      $��Zatvori��6%   $
��Left=�67   $��31��6R   $��599,382,0,0q�6^   $	��Top=�6s   $��83��6�   
����������	#FFDD0B0B���	#FFCE09096�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgAkcija��5   �   $
��Left=�6      CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .  $	��229��6�   $��	20,10,0,0q�6�   $	��Top=�6�   $	��662��6�      
IsReadOnly .  �� SelectedItem 6�   �� 	 �� Path$	 IzabranaAkcija�67  �� 5   
   -   5        $ btnPrikaziNamestajPopust��5      $��Prikazi namestaj��63   $
��Left=�6N   $��31��6i   $��
20,244,0,0q�6u   $	��Top=�6�   $	��110��6�   ���	#FF27FA07���	#FF5EF011
�������6�   �� 5   
   $��	Sortirati��6   $��14(�6$   $
��Left=�62   $��29��6M   $��237,255,0,0q�6Y   $	��Top=�6n   $��64��6�   �� 5   
   -   5        
 ��Name$
 cbSortAkcije��5      $
��Left=�6)   $��29��6D   $��216,292,0,0q�6P   $	��Top=�6e   $	��108��6}   6�   �� 5   
   -   5         ��Name$ tbPretragaAkcija��5      $
��Left=�6,   $��32��6G   $��443,255,0,0q�6S    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��139��6�   �� 5   
   -	   5        $ btnPretragaAkcija��5      $��Pretraga��6,   $
��Left=�6?   $��29��6Z   $��456,292,0,0q�6f   $	��Top=�6{   $	��113��6�   
����������	#FF52F00A���	#FF3FEB096�   �� 5   
   -
   5        $ btnOsveziAkciju��5      $��Osvezi��6*   $
��Left=�6;   $��25��6V   $��456,326,0,0q�6b   $	��Top=�6w   $	��113��6�   
����������	#FF03D905���	#FF00E71C6�   5      5      