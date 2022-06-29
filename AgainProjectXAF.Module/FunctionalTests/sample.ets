;#DropDB AgainProjectXAFEasyTest

#Application AgainProjectXAFWin
#Application AgainProjectXAFWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef AgainProjectXAFWin

*Action About...
 
*Action OK

#EndIf

#IfDef AgainProjectXAFWeb
*Action Navigation(My Details)
#EndIf
