Echo Off
set row1="0,1,0, 0,7,0, 5,0,0,"
set row2="6,0,0, 0,1,0, 0,3,2,"
set row3="0,0,7, 5,9,0, 0,0,0,"

set row4= "0,0,0, 0,0,7, 0,8,0,"
set row5= "0,2,0, 4,0,3, 0,1,0,"
set row6="0,8,0, 1,0,0, 0,0,0,"

set row7= "0,0,0, 0,3,5, 1,0,0,"
set row8= "3,9,0, 0,4,0, 0,0,5,"
set row9= "0,0,5, 0,6,0, 4,0,0"





SudokuSolver.exe %row1%, %row2%, %row3%, %row4%, %row5%, %row6%, %row7%, %row8%, %row9%