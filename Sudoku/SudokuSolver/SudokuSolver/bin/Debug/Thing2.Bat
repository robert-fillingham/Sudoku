Echo Off
set row1="4,0,0, 6,0,0, 0,0,0,"
set row2="0,0,2, 0,3,0, 0,0,0,"
set row3="0,0,0, 0,0,9, 8,2,7,"

set row4="8,0,0, 4,1,0, 0,0,0,"
set row5="9,0,0, 0,0,0, 0,0,5,"
set row6="0,6,0, 0,0,0, 0,7,0,"

set row7="0,3,0, 0,0,0, 4,0,6,"
set row8="0,0,0, 0,9,6, 2,0,0,"
set row9="0,9,0, 0,0,0, 0,5,0"





SudokuSolver.exe %row1%, %row2%, %row3%, %row4%, %row5%, %row6%, %row7%, %row8%, %row9%