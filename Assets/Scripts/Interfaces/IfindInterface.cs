using System.Collections;
using System.Collections.Generic;

interface IfindInterface 
{
    
    Chave findChaveName(string name);
    int findChaveIndexByName(string name);
    Disjuntor findDisjuntorName(string name);
    int findDisjuntorIndexByName(string name);
}
