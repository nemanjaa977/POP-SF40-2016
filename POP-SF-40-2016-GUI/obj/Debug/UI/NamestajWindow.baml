   M S B A M L   `   `   `  ����M  IPOP-SF-40-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_40_2016_GUI.UIPOP_SF_40_2016_GUI.UI  5   	   *    $POP_SF_40_2016_GUI.UI.NamestajWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_40_2016_GUI.UI     5   	     � Title$  NamestajWindow��5   	   $��470.186��6    $��795.282��61    � 
ResizeMode$ NoResize=�6A    � WindowStartupLocation$ CenterScreen=�6W   ���	#FFA9D0CE.��5	      � .+�5   
   �� -   5         ��Name$ btnDodaj��5      $��Dodaj��6#   $
��Left=�63   $��35��6N   $��
10,396,0,0q�6Z   $	��Top=�6n   $��71��6�   ���	#FFFFFBFB���	#FF06FF00���	#FF46FF006�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dgNamestaj��5   �   $
��Left=�6      CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .  $	��214��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��769��6�      
IsReadOnly . 
������� �� SelectedItem 6�   �� 	 �� Path$	 IzabranNamestaj�6n  �� 5   
   -   5        $ 	btnIzmeni��5      $��Izmeni��6$   $
��Left=�65   $��35��6P   $��
86,396,0,0q�6\   $	��Top=�6p   $��71��6�   
����������	#FF75FA05���	#FF41F6086�   �� 5   
   -   5        $ 
btnIzbrisi��5      $��Izbrisi��6%   $
��Left=�67   $��35��6R   $��162,396,0,0q�6^   $	��Top=�6s   $��71��6�   
 J� RenderTransformOrigin$
 0.544,0.543&�6�   
����������	#FFF00606���	#FFF408086�   �� 5   
   -   5        $ 
btnZatvori��5      $��Zatvori��6%   $
��Left=�67   $��35��6R   $��708,396,0,0q�6^   $	��Top=�6s   $��71��6�   
����������	#FFF60707���	#FFF706066�   �� 5   
   -   5        $ 
btnPreuzmi��5      $��Preuzmi��6%   $
��Left=�67   $��35��6R   $��632,396,0,0q�6^   $	��Top=�6s   $��71��6�   $
 0.442,0.537&�6�   ���	#FF1EF607���	#FF49F707
�������6  �� 5   
   -   5         ��Name$ labKolicina��5      $��	Kolicina:��6%   $
��Left=�69   $��38��6T   $��264,247,0,0q�6`   $	��Top=�6u   $��98��6�   $��20(�6�   
���   �6�   �� 5   
   -   5         ��Name$ 
tbKolicina��5      $
��Left=�6&   $��38��6A   $��376,247,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��114��6�   $��20(�6�   �� 5   
   -	   5        $��labSort��5   2   $��	Sortirati��6   $��15(�6$   $
��Left=�6A   $��33��6\   $��470,313,0,0q�6h   $	��Top=�6}   $��65��6�   �� 5   
   -
   5         ��Name$ cbSortiranjeNAmestaj��5      $
��Left=�61   $��33��6L   $��552,313,0,0q�6X   $	��Top=�6m   $	��167��6�   6�   �� 5   
   -   5        $��tbPretragaNamestaj��5   i   $
��Left=�6   $��33��6-   $��
10,313,0,0q�69   $
 Wrap=�6M   $�� ��6a   $	��Top=�6�   $	��158��6�   �� 5   
   -   5        $ btnPretragaNamestaj��5      $��Pretraga��6.   $
��Left=�6A   $��33��6\   $��173,313,0,0q�6h   $	��Top=�6}   $	��109��6�   
����������	#FF06F700���	#FF00F0036�   �� 5   
   -   5        $ btnOsveziNamestaj��5      $��Osvezi��6,   $
��Left=�6=   $��33��6X   $��287,313,0,0q�6d   $	��Top=�6y   $	��100��6�   
����������	#FF26E500���	#FF15D3096�   5      5      