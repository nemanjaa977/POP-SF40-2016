   M S B A M L   `   `   `  ����M  IPOP-SF-40-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_40_2016_GUI.UIPOP_SF_40_2016_GUI.UI  5   	   .    (POP_SF_40_2016_GUI.UI.EditNamestajWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_40_2016_GUI.UI     5   	     � Title$  EditNamestajWindow��5   	   $��294.97��6$   $��508.121��64    � WindowStartupLocation$ CenterScreen=�6D    � 
ResizeMode$ NoResize=�6i   
�������.��5	      �  � RowDefinitions 5   
   �� 5      $
��124* �6   �� 5      $	��23* �6   .+�5   
   �� -   5         ��Name$ 
labelNaziv��5      $��Naziv:��6$   $
��Left=�65   $��28��6P   $��	10,10,0,0q�6\   $	��Top=�6o   $��72��6�   $��15(�6�   
���   �
�������6�   �� 5   
   -   5        $��tbNaziv��5   �   $
��Left=�6   $��28��6-   $��
174,10,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6}   $	��314��6�   $��2��6�   ��6a   ��  �� Path$ Naziv�6�   �� 5   
   -   5         ��Name$ 
btnZatvori��5      $��Zatvori��6%   $
��Left=�67   $��23��6R   $��
22,232,0,0q�6^   $	��Top=�6r   $��80��6�   
����������	#FFF70606���	#FFF30D0D$��2��6�   �� 5   
   -   5        $ 
btnSacuvaj��5      $��Sacuvaj��6%   $
��Left=�67   $��23��6R   $��392,232,0,0q�6^   $	��Top=�6s   $��80��6�   
����������	#FF2FF607���	#FF4BF60A$��2��6�   �� 5   
   -   5        $ 	labelCena��5      $��Jedinicna Cena:��6#   $
��Left=�6=   $��35��6X   $��	10,59,0,0q�6d   $	��Top=�6w   $	��116��6�   $��15(�6�   
���   �6�   �� 5   
   -   5        $ labelKolicina��5      $��Kolicina u magacinu:��6'   $
��Left=�6F   $��31��6a   $��
10,111,0,0q�6m   $	��Top=�6�   $	��146��6�   $��15(�6�   
���   �6�   �� 5   
   -   5        $ labelTipNam��5      $��Tip namestaja:��6%   $
��Left=�6>   $��28��6Y   $��
10,169,0,0q�6e   $	��Top=�6y   $	��116��6�   $��15(�6�   
���   �6�   �� 5   
   -   5        $��tbNazivi��5   �   $
��Left=�6   $��28��6-   $��
174,59,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $	��314��6y   .��6�   ��5      �� 5      $ JedinicnaCena�6    �� ValidationRules 5      ,  &POP_SF_40_2016_GUI.UI.ValidationDouble  5      5      .��5      5      �� 5    
   -	   5        $��	tbNazivii��5    �   $
��Left=�6   $��28��6-   $��174,114,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��314��6z   .��6�   ��5!      �� 5"      $ KolicinaUMagacinu�6   	 �� UpdateSourceTrigger$	 PropertyChanged=�63    5#      )  #POP_SF_40_2016_GUI.UI.ValidationInt  5$      5&      .��5'      5(      �� 5)   
   -
   5        
 ��Name$
 cbTipNamestaja��5)      $
��Left=�6+   $��28��6F   $��174,169,0,0q�6R   $	��Top=�6g   $	��314��6    �� SelectedItem 6�   �� $ TipNamestaja�5+      5,      