   M S B A M L   `   `   `  ����M  IPOP-SF-40-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_40_2016_GUI.UIPOP_SF_40_2016_GUI.UI  5   	   ,    &POP_SF_40_2016_GUI.UI.EditAkcijeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_40_2016_GUI.UI     5   	     � Title$  EditAkcijeWindow��5   	   $��390.4��6"   $	��920��61    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterScreen=�6S   
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $
��236* �6   �� 5      $	��65* �6   .+�5   
   �� $��Datum pocetka:��6   $
��Left=�6)   $��33��6D   $��	20,26,0,0q�6P   $	��Top=�6c   $	��150��6{   $��20(�6�   �� 5   
   $��Datum zavrsetka:��6   $
��Left=�6+   $��33��6F   $��	20,72,0,0q�6R   $	��Top=�6e   $	��163��6}   $��20(�6�   �� 5   
   $��Namestaj na popustu��6   $
��Left=�6.   $��43��6I   $��
601,26,0,0q�6U   $	��Top=�6i   $	��203��6�   $��20(�6�   �� 5   
   $��Popust:��6   $
��Left=�6"   $��38��6=   $��
20,209,0,0q�6I   $	��Top=�6]   $	��102��6u   $��20(�6�   �� 5   
   -   5         ��Name$ 
btnZatvori��5      $��Zatvori��6%   $
��Left=�67   $��33��6R   $��20,23.8,0,0q�6^   $	��Top=�6s   $	��120��6�   $��18(�6�   $��1��6�   
�������
���  ��
���  ��6�   �� 5   
   -   5        $ 
btnSacuvaj��5      $��Sacuvaj��6%   $
��Left=�67   $��33��6R   $��784,23.8,0,0q�6^   $��1��6t   $	��Top=�6�   $	��120��6�   $��18(�6�   
����������	#FF0DF107���	#FF05FD086�   �� 5   
   -   5         ��Name$ tbPopust��5      $
��Left=�6$   $��38��6?   $��142,209,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��199��6�   .��6�   ��5      �� 5       �� Path$ Popust�6    �� UpdateSourceTrigger$ PropertyChanged=�6(   	 �� ValidationRules	 5      ,  &POP_SF_40_2016_GUI.UI.ValidationPopust  5      5      .��5      5      (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$
 tbDatumP��5      $
��Left=�6S   $��33��6n   $��
204,26,0,0q�6z   $	��Top=�6�   $	��266��6�      SelectedDate 6'   �� $ DatumPocetka�6�     5   
   -   5        $
 tbDatumZ��5      $
��Left=�6V   $��33��6q   $��
204,72,0,0q�6}   $	��Top=�6�   $	��266��6�    6(   �� $ DatumZavrsetka�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgNamestajPopust��5         AutoGenerateColumns .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6w      CanUserAddRows .  $
��Left=�6�   $	��134��6�   $��
522,69,0,0q�6�   $	��Top=�6�   $	��373��6�      
IsReadOnly . ��6H   �� $ NamestajNaPopustu�6<  �� 5    
   -   5        $ btnIzaberiNamestajPopust��5       $��Izaberi��63   $
��Left=�6E   $��18��6`   $��601,209,0,0q�6l   $	��Top=�6�   $	��174��6�   ���	#FF05FA08���	#FF00FF0C
�������6�   �� 5!   
   -   5        $ btnUkloniNamestajPopust��5!      $��X��62   $
��Left=�6>   $��18��6Y   $��794,209,0,0q�6e   $	��Top=�6z   $��33��6�   
����������	#FFFC1E03
���  ��6�   5#      5$      