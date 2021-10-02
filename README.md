# *Lab1Compiladores_MarcelaEstrada*
Scanner y parser descendiente para calcular el valor de una expresion algebraica.

**Gramática utilizada**\
E -> T | E+T | E-T\
T -> F | T*F | T/F\
F -> numberF | (E)\

**Gramática v2** \
E -> TE'\
First(E) -> First(T) -> {-, number, (}\

E' -> +TE' | -TE'\
First(E') -> {+,-}

T -> FT'\
First(T) -> First(F) -> {-, number, (}

T' -> *FT' | /FT'\
First(T') -> {*,/}

F -> numberF' | (E)\
First(F) -> {-, number, (}
