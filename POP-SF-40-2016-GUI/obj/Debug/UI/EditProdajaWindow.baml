   M S B A M L   `   `   `  ����M  IPOP-SF-40-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_40_2016_GUI.UIPOP_SF_40_2016_GUI.UI  5   	   -    'POP_SF_40_2016_GUI.UI.EditProdajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_40_2016_GUI.UI     5   	     � Title$  EditProdajaWindow��5   	   $��486.445��6#   $��730.161��64    � 
ResizeMode$ NoResize=�6D    � WindowStartupLocation$ CenterScreen=�6Z   .��5	      � .+�5
   
   �� $��Datum prodaje:��6   $
��Left=�6)   $��31��6D   $��	10,31,0,0q�6P   $	��Top=�6c   $	��110��6{   $��14(�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDatumProdaje��5      $
��Left=�6Y   $��31��6t   $��
125,31,0,0q�6�   $	��Top=�6�   $	��243��6�   $ 0.498,0.561&�6�      SelectedDate 6-   ��  �� Path$ DatumProdaje�6�   �� 5   
   $��Kupac:��6   $
��Left=�6!   $��33��6<   $��	10,91,0,0q�6H   $	��Top=�6[   $	��110��6s   $��14(�6   �� 5   
   -   5         ��Name$ tbKupac��5      $
��Left=�6#   $��33��6>   $��
125,91,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6�   $	��243��6�   ��6r   �� $ Kupac�6�   �� 5   
   -   5        	 ��Name$	 btnZavoriProzor��5      $��Zatvori��6*   $
��Left=�6<   $��28��6W   $��587,417,0,0q�6c   $	��Top=�6x   $	��127��6�   
���  ��
���  ��
�������6�   �� 5   
   -   5        $	 btnSacuvajProzor��5      $��Sacuvaj��6+   $
��Left=�6=   $��28��6X   $��587,367,0,0q�6d   $	��Top=�6y   $	��127��6�   
����������	#FF00FF03���	#FF00FF0C6�   �� 5   
   $��Dodatne Usluge��6   $
��Left=�6)   $��34��6D   $��
485,31,0,0q�6P   $	��Top=�6d   $	��143��6|   $��18(�6�   �� 5   
   -   5        $	 btnIzaberiUslugu��5      $��Izaberi��6+   $
��Left=�6=   $��23��6X   $��495,202,0,0q�6d   $	��Top=�6y   $	��112��6�   
����������	#FF00FF15���	#FF06FF006�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dgDodUsluge��5         AutoGenerateColumns .    
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6U      CanUserAddRows .  $
��Left=�6�   $	��130��6�   $��
416,67,0,0q�6�   $	��Top=�6�   $	��264��6�   ��6|   ��  �� Source$ DodatneUsluge��6	  �� 5   
   $��Namestaj��6   $
��Left=�6#   $��41��6>   $��159,212,0,0q�6J   $	��Top=�6_   $	��115��6w   $��25(�6�   $ 0.505,0.488&�6�     5   
   -   5        $
 dgNamestajj��5       . $ * 6t    .  $
��Left=�6�   $	��154��6�   $��
25,258,0,0q�6�   $	��Top=�6�   $	��387��6�    . ��6(   �� $ NamestajNaProdaja��63  �� 5   
   -   5        $	 btnIzaberiNamestaj��5      $��Izaberi��6-   $
��Left=�6?   $��20��6Z   $��100,417,0,0q�6f   $	��Top=�6{   $	��189��6�   ���	#FF00FF0C���	#FF00FF0C
�������6�   �� 5   
   -	   5        $	 btnUkloniNamestaj��5      $��X��6,   $
��Left=�68   $��20��6S   $��294,417,0,0q�6_   $	��Top=�6t   $��29��6�   
�������
���  ��
���  ��6�   �� 5   
   -
   5        $	 btnUkloniUslugu��5      $��X��6*   $
��Left=�66   $��23��6Q   $��612,202,0,0q�6]   $	��Top=�6r   $��28��6�   
�������
���  ��
���  ��6�   5      5      