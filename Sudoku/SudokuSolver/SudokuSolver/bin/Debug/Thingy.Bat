Echo Off
set row1="0,0,0, 0,0,3, 9,0,0,"
set row2="0,0,0, 9,1,0, 0,0,6,"
set row3="7,0,0, 0,0,2, 0,0,5,"

set row4="0,0,0, 0,0,0, 7,3,0,"
set row5="1,9,0, 0,0,0, 0,5,2,"
set row6="0,3,2, 0,0,0, 0,0,0,"

set row7="8,0,0, 2,0,0, 0,0,4,"
set row8="2,0,0, 0,4,5, 0,0,0,"
set row9="0,0,3, 8,0,0, 0,0,0"





SudokuSolver.exe %row1%, %row2%, %row3%, %row4%, %row5%, %row6%, %row7%, %row8%, %row9%